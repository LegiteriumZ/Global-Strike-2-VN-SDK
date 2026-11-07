using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Assets.Sources.Chat;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.BattleServer;
using Assets.Sources.Components.Chat;
using Assets.Sources.Components.Interface.Info.Chat;
using Assets.Sources.Components.Time;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Entitas;
using I2.Loc;
using NetData;
using NotifyEvent;
using RapidXml;
using SSJJBase.Logger;
using SSJJBase.SimpleJson;
using SSJJBase.Utility;
using Sharpen;

namespace Assets.Sources.Modules.Ui.Chat;

public class ChatJobSystem : IPlaybackSystem
{
	private readonly RapidXmlParser _rapidXmlJob = new RapidXmlParser();

	private readonly XmlDocument _xmlJob = new XmlDocument();

	private bool _rapidEnable = true;

	private readonly ChatJobHistroyComponent _chatJobHistroyComponent;

	private readonly BattleServerComponent _battleServerComponent;

	private readonly LobbyInfoComponent _lobbyInfoComponent;

	private readonly RoomDataComponent _roomData;

	private readonly PlayerContext _playerContext;

	private readonly TimeComponent _time;

	private readonly BattleRoomContext _roomContext;

	private readonly List<object> _sendListCache;

	private IAllOfMatcher<PlayerEntity> _allmatcher = PlayerMatcher.AllOf(PlayerMatcher.Skill, PlayerMatcher.BasicInfo);

	public ChatJobSystem(Contexts contexts)
	{
		ChatContext chat = contexts.chat;
		_chatJobHistroyComponent = chat.chatJobHistroy;
		_battleServerComponent = contexts.battleServer.battleServer;
		_lobbyInfoComponent = contexts.battleRoom.lobbyInfo;
		_roomData = contexts.battleRoom.roomData;
		_playerContext = contexts.player;
		_time = contexts.time.time;
		_roomContext = contexts.battleRoom;
		_sendListCache = new List<object>
		{
			new Dictionary<string, string>()
		};
	}

	public void OnPlayback()
	{
		if (_chatJobHistroyComponent != null)
		{
			CheckInputData(ref _chatJobHistroyComponent.InputData);
			CheckHononAryData(_chatJobHistroyComponent.Tips.Group);
			CheckAssembleData(_chatJobHistroyComponent.ContentReceived);
		}
	}

	private void CheckHononAryData(List<IChatHononaryData> hononaryList)
	{
		for (int i = 0; i < hononaryList.Count; i++)
		{
			ChatHononaryData data = (ChatHononaryData)(object)hononaryList[i];
			if (CheckHononaryLoginData(ref data) || CheckHononaryLogoutData(ref data))
			{
				hononaryList[i] = data;
			}
		}
		for (int num = hononaryList.Count - 1; num >= 0; num--)
		{
			ChatHononaryData chatHononaryData = (ChatHononaryData)(object)hononaryList[num];
			if (string.IsNullOrEmpty(chatHononaryData.LegendWeapon) && string.IsNullOrEmpty(chatHononaryData.HeroWeapon) && string.IsNullOrEmpty(chatHononaryData.WeaponName) && chatHononaryData.VipLevel < HononaryData.ShowViphononaryLevel)
			{
				hononaryList.RemoveAt(num);
			}
		}
	}

	private bool CheckHononaryLoginData(ref ChatHononaryData data)
	{
		if (data.Changed && data.MsgType == "playerlogin")
		{
			if (data.Wait > 0)
			{
				data.Wait -= _time.FrameInterval;
				return true;
			}
			bool value = false;
			if (_lobbyInfoComponent.Id2CidDic.TryGetValue(data.Id, out var value2))
			{
				_lobbyInfoComponent.Cid2FriendlyDic.TryGetValue(value2, out value);
			}
			ChatHistroyData data2 = default(ChatHistroyData);
			data2.AlphaData.RemainTime = 6000;
			data2.AlphaData.AlphaRemainTime = 100;
			data2.MsgType = "playerlogin";
			data2.PlayerCid = data.Cid.ToString();
			data2.SenderBody = (data2.AssembleBody = PrintfUtility.Printf(ScriptLocalization.Get("Entergame"), data.PlayerName));
			data2.Friendly = value;
			AddToChatList(ref data2);
			data.Changed = false;
			return true;
		}
		return false;
	}

	private bool CheckHononaryLogoutData(ref ChatHononaryData data)
	{
		if (data.Changed && data.MsgType == "playerlogout")
		{
			ChatHistroyData data2 = default(ChatHistroyData);
			data2.AlphaData.RemainTime = 6000;
			data2.AlphaData.AlphaRemainTime = 100;
			data2.MsgType = "playerlogout";
			data2.SenderBody = (data2.AssembleBody = PrintfUtility.Printf(ScriptLocalization.Get("Leavegame"), data.PlayerName));
			AddToChatList(ref data2);
			data.Changed = false;
			return true;
		}
		return false;
	}

	private void AddToChatList(ref ChatHistroyData data)
	{
		if (_chatJobHistroyComponent != null)
		{
			_chatJobHistroyComponent.ChatList.Group.AddFirst(data);
			if (_chatJobHistroyComponent.ChatList.Group.Count > 6)
			{
				_chatJobHistroyComponent.ChatList.Group.RemoveLast();
			}
			_chatJobHistroyComponent.ChatList.Mark = true;
			NotifyManager.ForceInvoke(73);
		}
	}

	private void CheckAssembleData(Queue<string> receivedqueue)
	{
		while (receivedqueue != null && receivedqueue.Count > 0)
		{
			string text = receivedqueue.Dequeue();
			if (!string.IsNullOrEmpty(text) && ParseChatXml(text, out var chatdata))
			{
				chatdata.AlphaData.RemainTime = 6000;
				chatdata.AlphaData.AlphaRemainTime = 100;
				OnRecvChatInfo(ref chatdata);
			}
		}
	}

	private void OnRecvChatInfo(ref ChatHistroyData data)
	{
		if (_chatJobHistroyComponent == null)
		{
			return;
		}
		AddDefineChatHistory(ref data);
		if (ChattingType.IsBigHornChattingType(data.MsgType))
		{
			_chatJobHistroyComponent.BigHornList.Group.Add(data);
			_chatJobHistroyComponent.BigHornList.Mark = true;
		}
		else if (ChattingType.IsLiveChattingType(data.MsgType))
		{
			_chatJobHistroyComponent.LiveList.Group.Add(data);
			_chatJobHistroyComponent.LiveList.Mark = true;
		}
		else if (ChattingType.IsObserverAllChattingType(data.MsgType))
		{
			if (_playerContext.myPlayerEntity.IsObserver())
			{
				AddToChatList(ref data);
			}
		}
		else if (ChattingType.IsCampPlayerChattingType(data.MsgType))
		{
			if (RuleUtilty.isRpgDuelDianfeng(_roomContext.roomData.Data.RaceType))
			{
				PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
				PlayerEntity playerByCid = GetPlayerByCid(data.SenderCid);
				if (myPlayerEntity != null && playerByCid != null && myPlayerEntity.GetTeam() != playerByCid.GetTeam())
				{
					return;
				}
			}
			AddToChatList(ref data);
		}
		else
		{
			AddToChatList(ref data);
		}
	}

	public PlayerEntity GetPlayerByCid(string cid)
	{
		foreach (PlayerEntity item in Contexts.sharedInstance.player.GetGroup(_allmatcher))
		{
			if (item.basicInfo.Cid.ToString().EndsWith(cid))
			{
				return item;
			}
		}
		return null;
	}

	private void AddDefineChatHistory(ref ChatHistroyData data)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		string text = data.SendHead + ScriptLocalization.Get("Speak");
		if (!string.IsNullOrEmpty(data.SenderCid) && myPlayerEntity.hasBasicInfo && myPlayerEntity.basicInfo.Cid.ToString().EndsWith(data.SenderCid))
		{
			text = ScriptLocalization.Get("MY") + ScriptLocalization.Get("Speak");
		}
		if (data.MsgType == "battle_all")
		{
			data.AssembleHead = ScriptLocalization.Get("All") + text;
			data.AssembleBody = data.SenderBody;
		}
		else if (data.MsgType == "battle_observer_all")
		{
			data.AssembleHead = ScriptLocalization.Get("All") + text;
			data.AssembleBody = data.SenderBody;
		}
		else if (data.MsgType == "battle_team")
		{
			data.AssembleHead = ScriptLocalization.Get("Camp") + text;
			data.AssembleBody = data.SenderBody;
		}
		else if (data.MsgType == "team")
		{
			data.AssembleHead = ScriptLocalization.Get("Team") + text;
			data.AssembleBody = data.SenderBody;
		}
		else if (data.MsgType == "battle_observer_all")
		{
			data.AssembleHead = ScriptLocalization.Get("ObserverAllChannel") + text;
			data.AssembleBody = data.SenderBody;
		}
		else if (data.MsgType == "personal")
		{
			if (myPlayerEntity == null)
			{
				data.AssembleHead = ScriptLocalization.Get("Whisper") + data.SendHead + ScriptLocalization.Get("WhisperYou");
				data.AssembleBody = data.SenderBody;
			}
			else if (myPlayerEntity.hasBasicInfo && !myPlayerEntity.basicInfo.Cid.ToString().EndsWith(data.SenderCid))
			{
				data.AssembleHead = ScriptLocalization.Get("Whisper") + data.SendHead + ScriptLocalization.Get("WhisperYou");
				data.AssembleBody = data.SenderBody;
			}
			else
			{
				data.AssembleHead = ScriptLocalization.Get("Whisper") + ScriptLocalization.Get("You") + data.ReceiverName + ScriptLocalization.Get("Speak");
				data.AssembleBody = data.SenderBody;
			}
		}
		else if (data.MsgType == "system")
		{
			data.AssembleBody = ScriptLocalization.Get("System") + data.SenderBody;
		}
		else if (data.MsgType == "prompt")
		{
			data.AssembleBody = ScriptLocalization.Get("Prompt") + data.SenderBody;
		}
		else if (data.MsgType == "tacticsSound")
		{
			data.AssembleHead = ScriptLocalization.Get("Tacticssound") + data.SendHead + ScriptLocalization.Get("Speak");
			data.AssembleBody = data.SenderBody;
		}
		else
		{
			data.AssembleBody = data.SenderBody;
		}
		if (data.RpgVip && _roomData != null && RuleUtilty.IsRpg(_roomData.Data.RaceType))
		{
			data.AssembleRpgVipText = ScriptLocalization.Get("Vip");
			data.AssembleHead = data.AssembleRpgVipText + data.AssembleHead;
			data.AssembleBody = data.SenderBody;
		}
	}

	private void CheckInputData(ref IChatInputData inputData)
	{
		ChatInputData inputData2 = (ChatInputData)(object)inputData;
		if (!string.IsNullOrEmpty(inputData2.SenderInputContent))
		{
			SendChatInfo(ref inputData2);
			inputData2.SenderInputContent = null;
		}
		inputData = inputData2;
	}

	private void SendChatInfo(ref ChatInputData inputData)
	{
		if (!(_sendListCache[0] is Dictionary<string, string> dictionary))
		{
			this.LogError("chat missing");
			return;
		}
		dictionary["content"] = inputData.SenderInputContent;
		dictionary["type"] = inputData.SenderType;
		dictionary["to"] = inputData.ReceiverName;
		dictionary["toCid"] = inputData.ReceiverCid;
		string s = JsonEncoder.Encode(_sendListCache);
		this.Info(inputData.SenderInputContent);
		UnityProxyData unityProxyData = new UnityProxyData
		{
			Type = UnityProxyType.CALLMSG,
			Func = "sendBattleChatMessage",
			Key = TplManager.Instance.GameBootConfig.Sign
		};
		unityProxyData.Params.Add(Encoding.Default.GetBytes(s));
		_battleServerComponent.Server.SendTcpMessage(23, unityProxyData);
	}

	private string StripNonValidXMLChars(string info)
	{
		if (string.IsNullOrEmpty(info))
		{
			return info;
		}
		return Regex.Replace(info, "[\\x00-\\x08\\x0b-\\x0c\\x0e-\\x1f]", "");
	}

	private string ReplaceInvalid(string xml, string start, string end)
	{
		int num = xml.IndexOf(start, StringComparison.Ordinal);
		if (num > 0)
		{
			num += start.Length;
			int num2 = xml.IndexOf(end, num, StringComparison.Ordinal);
			string text = xml.Substring(num, num2 - num);
			text = text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")
				.Replace("\"", "&quot;")
				.Replace("'", "&apos;");
			xml = xml.Substring(0, num) + text + xml.Substring(num2);
		}
		return xml;
	}

	private bool ParseChatXml(string xml, out ChatHistroyData chatdata)
	{
		try
		{
			xml = StripNonValidXMLChars(xml);
			if (_rapidEnable)
			{
				_rapidXmlJob.Dispose();
				_rapidXmlJob.Load(xml);
			}
			else
			{
				_xmlJob.LoadXml(xml);
			}
		}
		catch (Exception ex)
		{
			if (ex is DllNotFoundException)
			{
				this.LogError(ex);
				_rapidEnable = false;
			}
			try
			{
				xml = ReplaceInvalid(xml, " from=\"", "\" ");
				xml = ReplaceInvalid(xml, " to=\"", "\" ");
				xml = ReplaceInvalid(xml, "<body>", "</body>");
				if (_rapidEnable)
				{
					_rapidXmlJob.Load(xml);
				}
				else
				{
					_xmlJob.LoadXml(xml);
				}
			}
			catch (Exception ex2)
			{
				this.LogErrorFormat("ChatMessage XML error:{0}****** {1}", ex2.Message, xml);
			}
		}
		if (_rapidEnable)
		{
			return RapidParse(out chatdata);
		}
		return SystemParse(out chatdata);
	}

	private bool RapidParse(out ChatHistroyData chat)
	{
		chat = default(ChatHistroyData);
		NodeElement nodeElement = _rapidXmlJob.FirstNode("message");
		NodeElement nodeElement2 = nodeElement;
		nodeElement2.ChildeNode("body");
		if (!nodeElement.IsValid() || !nodeElement2.IsValid())
		{
			return false;
		}
		string text = null;
		RapidXmlEnumator<NodeAttribute> attributeEnumerator = nodeElement.GetAttributeEnumerator();
		chat.ReceiverName = "";
		while (attributeEnumerator.MoveNext())
		{
			NodeAttribute current = attributeEnumerator.Current;
			switch (current.BetterGetName())
			{
			case "from":
				chat.SenderName = current.BetterGetValue();
				break;
			case "fromCid":
				chat.SenderCid = current.BetterGetValue();
				break;
			case "to":
				chat.ReceiverName = current.BetterGetValue();
				break;
			case "toCid":
				chat.ReceiverCid = current.BetterGetValue();
				break;
			case "type":
				chat.MsgType = current.BetterGetValue();
				break;
			case "rpgVip":
				chat.RpgVip = current.GetBool();
				break;
			case "vipLv":
				chat.VipLv = current.GetInt();
				break;
			case "fromDname":
				text = current.BetterGetValue();
				break;
			}
		}
		if (text != null)
		{
			chat.SendHead = text + "." + chat.SenderName;
		}
		else
		{
			chat.SendHead = chat.SenderName;
		}
		chat.SenderBody = nodeElement2.GetValue();
		return true;
	}

	private bool SystemParse(out ChatHistroyData chatdata)
	{
		chatdata = default(ChatHistroyData);
		if (_xmlJob == null)
		{
			return false;
		}
		XmlNode xmlNode = _xmlJob.SelectSingleNode("message");
		if (xmlNode == null)
		{
			return false;
		}
		string text = null;
		foreach (XmlAttribute attribute in xmlNode.Attributes)
		{
			switch (attribute.Name)
			{
			case "from":
				chatdata.SenderName = attribute.Value;
				break;
			case "fromCid":
				chatdata.SenderCid = attribute.Value;
				break;
			case "to":
				chatdata.ReceiverName = attribute.Value;
				break;
			case "toCid":
				chatdata.ReceiverCid = attribute.Value;
				break;
			case "type":
				chatdata.MsgType = attribute.Value;
				break;
			case "rpgVip":
				chatdata.RpgVip = bool.Parse(attribute.Value);
				break;
			case "vipLv":
				chatdata.VipLv = int.Parse(attribute.Value);
				break;
			case "fromDname":
				text = attribute.Value;
				break;
			}
		}
		if (text != null)
		{
			chatdata.SendHead = text + "." + chatdata.SenderName;
		}
		else
		{
			chatdata.SendHead = chatdata.SenderName;
		}
		chatdata.SenderBody = xmlNode.SelectSingleNode("body").InnerText;
		return true;
	}
}

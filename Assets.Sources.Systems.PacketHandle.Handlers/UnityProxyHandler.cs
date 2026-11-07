using System.Text;
using Assets.Sources.Chat;
using Assets.Sources.Components.Chat;
using Assets.Sources.Free.Auto;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Logger;
using SSJJBase.SimpleJson;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class UnityProxyHandler : ApcPacketHandler<UnityProxyData>
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(UnityProxyHandler));

	private BattleRoomContext _battleRoomContext;

	private ChatContext _chatContext;

	public UnityProxyHandler(Contexts contexts)
	{
		_chatContext = contexts.chat;
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 199;
	}

	private void OnGetRoomInfo(UnityProxyData data, string msg)
	{
		JObject jObject = JsonDecoder.Decode(msg);
		int num = 0;
		if (jObject.ObjectValue.TryGetValue("battleType", out var value))
		{
			num = value.IntValue;
		}
		string text = ((!jObject.ObjectValue.TryGetValue("channelName", out value)) ? "" : value.StringValue);
		if (num == 1 || !jObject.ObjectValue.TryGetValue("limitNumber", out var value2))
		{
			_battleRoomContext.roomData.LimitNum = _battleRoomContext.roomData.Data.PlayerNum;
		}
		else
		{
			int intValue = value2.IntValue;
			_battleRoomContext.roomData.LimitNum = intValue;
		}
		switch (num)
		{
		case 1:
			_battleRoomContext.roomData.RoomTitle = ScriptLocalization.Get("Match");
			break;
		case 2:
			_battleRoomContext.roomData.RoomTitle = ScriptLocalization.Get("Chanllenge");
			break;
		case 3:
			if (jObject.ObjectValue.TryGetValue("roomName", out value))
			{
				_battleRoomContext.roomData.RoomTitle = value.StringValue;
			}
			break;
		default:
			if (jObject.ObjectValue.TryGetValue("roomId", out value))
			{
				_battleRoomContext.roomData.RoomId = value.LongValue;
				_battleRoomContext.roomData.RoomTitle = text + string.Format(ScriptLocalization.Get("RoomNumber"), value.IntValue);
				AutoClientValue.roomInfo.Add("roomId", value.IntValue);
			}
			break;
		}
		AutoClientValue.roomInfo.Add("limitNumber", _battleRoomContext.roomData.LimitNum);
		AutoClientValue.roomInfo.Add("battleType", num);
		AutoClientValue.roomInfo.Add("channelName", text);
	}

	private void PackChatMsg(UnityProxyData data, string msg)
	{
		if (!msg.StartsWith("Logger") && _chatContext.hasChatJobHistroy)
		{
			_chatContext.chatJobHistroy.ContentReceived.Enqueue(msg);
		}
	}

	private void GetAce(UnityProxyData data, string msg)
	{
		this.Info("GetAce " + msg);
		_battleRoomContext.ace.IsRefresh = true;
	}

	private void GetAntiAddiction(UnityProxyData data, string msg)
	{
		this.Info("GetAntiAddiction " + msg);
		JObject jObject = JsonDecoder.Decode(msg);
		if (jObject != null)
		{
			_battleRoomContext.antiAddiction.IsRefresh = true;
			_battleRoomContext.antiAddiction.AntiJObject = jObject;
		}
	}

	private void GetFrientFlag(UnityProxyData data, string msg)
	{
		if (data.Params == null || data.Params.Count <= 0 || !_battleRoomContext.hasLobbyInfo)
		{
			return;
		}
		JObject jObject = JsonDecoder.Decode(Encoding.UTF8.GetString(data.Params[0]));
		long longValue = jObject.ObjectValue["Cid"].LongValue;
		bool booleanValue = jObject.ObjectValue["Friendly"].BooleanValue;
		_battleRoomContext.lobbyInfo.Cid2FriendlyDic[longValue] = booleanValue;
		if (!booleanValue)
		{
			return;
		}
		ChatJobHistroyComponent chatJobHistroy = _chatContext.chatJobHistroy;
		for (int i = 0; i < chatJobHistroy.ChatList.Group.Count; i++)
		{
			ChatHistroyData chatHistroyData = (ChatHistroyData)(object)chatJobHistroy.ChatList.Group[i];
			if (chatHistroyData.MsgType == "playerlogin" && chatHistroyData.PlayerCid == jObject.ObjectValue["Cid"].LongValue.ToString())
			{
				chatHistroyData.Friendly = true;
				chatJobHistroy.ChatList.Group[i] = chatHistroyData;
				chatJobHistroy.ChatList.Mark = true;
				NotifyManager.ForceInvoke(73);
				break;
			}
		}
	}

	public override void Handle(UnityProxyData data)
	{
		string text = null;
		text = ((data.Params == null || data.Params.Count <= 0) ? "" : Encoding.UTF8.GetString(data.Params[0]));
		switch (data.Func)
		{
		case "onGetRoomInfo":
			OnGetRoomInfo(data, text);
			break;
		case "packetBattleChatMessage":
			PackChatMsg(data, text);
			break;
		case "onGetFriendlyFlag":
			GetFrientFlag(data, text);
			break;
		case "addAntiAddictionMsg":
			GetAntiAddiction(data, text);
			break;
		case "aceMsg":
			GetAce(data, text);
			break;
		}
	}
}

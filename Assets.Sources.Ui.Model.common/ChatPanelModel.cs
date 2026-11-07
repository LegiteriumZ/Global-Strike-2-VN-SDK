using System.Collections;
using System.Collections.Generic;
using Assets.Sources.Chat;
using Assets.Sources.Components.Chat;
using Assets.Sources.Components.Interface.Info.Chat;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Free.Data;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using Res.Assets.Scripts.ExText;
using SSJJBase.Input;
using SSJJBase.Logger;
using SSJJBase.Thread;
using SSJJBase.Utility;
using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class ChatPanelModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ISetGameRuleContext
{
	private enum ChatTypeDef
	{
		Group,
		All,
		ObserverAll,
		Team,
		Whisper,
		Horn
	}

	private ChatPanelViewModel _viewModel;

	private PlayerContext _playerContext;

	private ChatAutoHideMessage _hideJob;

	private ChatAutoHideMessage _hideHornJob;

	private ChatJobHistroyComponent _chatJobHistroy;

	private List<int> _canuseChatTypes;

	private List<string> _whisperTargetList = new List<string>();

	private List<string> _whisperTargetCidList = new List<string>();

	private Dictionary<string, int> _chatHistoryTextTypeDic;

	private string _whisperPrefix = "";

	private int _whisperIndex;

	private int _chatTypeIndex;

	private string _inputContent = "";

	private bool _hasSetChatType;

	private bool _myIsObserver;

	private bool _inputvisible;

	private readonly string[] _chatType = new string[6] { "battle_team", "battle_all", "battle_observer_all", "team", "personal", "big_horn2" };

	private readonly string[] _chatTypeDesc = new string[6]
	{
		ScriptLocalization.Get("CampPlayerText"),
		ScriptLocalization.Get("AllPlayerText"),
		ScriptLocalization.Get("ObserverAllPlayerText"),
		ScriptLocalization.Get("TeamPlayerText"),
		ScriptLocalization.Get("WhisperPlayerText"),
		ScriptLocalization.Get("BighornPlayerText")
	};

	private readonly Color[] _chatTypeColor = new Color[6]
	{
		new Color(0f, 1f, 0f),
		Color.white,
		Color.white,
		new Color(0f, 1f, 1f),
		new Color(1f, 0.435f, 1f),
		Color.yellow
	};

	private GameRuleContext _gameRuleContext;

	private bool InputVisible
	{
		get
		{
			return _inputvisible;
		}
		set
		{
			if (value != _inputvisible)
			{
				_inputvisible = value;
				VisibleChange(value);
			}
		}
	}

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		SetUpChatTypes();
	}

	public override void CreateViewModel()
	{
		_viewModel = new ChatPanelViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			InputField inputField = _viewModel.UI.Get<InputField>("ChatInputTextInputField");
			if (inputField != null && _whisperPrefix != null && GetCurrentChatType() == ChatTypeDef.Whisper)
			{
				inputField.caretPosition = Mathf.Max(_whisperPrefix.Length, inputField.caretPosition);
			}
			UpdateChips();
		}
	}

	private void VisibleChange(bool value)
	{
		if (_chatJobHistroy == null)
		{
			return;
		}
		FpsDisplay.ChatInputVisible = value;
		if (value)
		{
			PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
			if (!_hasSetChatType || (myPlayerEntity != null && myPlayerEntity.IsObserver() != _myIsObserver))
			{
				_chatTypeIndex = 0;
				SetUpChatTypes();
				UpdateChatInfo();
			}
			_viewModel.InputPanelShow = true;
			_viewModel.ChatInputTextInputactive = true;
			_viewModel.ChatInputTextText = null;
			for (int i = 0; i < _chatJobHistroy.ChatList.Group.Count; i++)
			{
				_viewModel.SetgroupAlpha(i + 1, 1f);
			}
			return;
		}
		_viewModel.InputPanelShow = false;
		ChatInputData chatInputData = (ChatInputData)(object)_chatJobHistroy.InputData;
		chatInputData.SenderType = _chatType[(int)GetCurrentChatType()];
		if (string.IsNullOrEmpty(_viewModel.ChatInputTextText))
		{
			chatInputData.SenderInputContent = "";
		}
		else if (!string.IsNullOrEmpty(_whisperPrefix) && GetCurrentChatType() == ChatTypeDef.Whisper)
		{
			chatInputData.SenderInputContent = _viewModel.ChatInputTextText.Replace(_whisperPrefix, "");
			this.Info(" _chatJobHistroy.InputData.SenderInputContent  " + chatInputData.SenderInputContent + " " + _viewModel.ChatInputTextText.Replace(_whisperPrefix, ""));
		}
		else
		{
			chatInputData.SenderInputContent = _viewModel.ChatInputTextText;
			this.Info(" %%%%_chatJobHistroy.InputData.SenderInputContent  " + chatInputData.SenderInputContent + " " + _viewModel.ChatInputTextText);
		}
		chatInputData.ReceiverName = "";
		chatInputData.ReceiverCid = "";
		if (GetCurrentChatType() == ChatTypeDef.Whisper)
		{
			if (_whisperIndex >= 0 && _whisperIndex < _whisperTargetList.Count)
			{
				chatInputData.ReceiverName = _whisperTargetList[_whisperIndex];
			}
			if (_whisperIndex >= 0 && _whisperIndex < _whisperTargetCidList.Count)
			{
				chatInputData.ReceiverCid = _whisperTargetCidList[_whisperIndex];
			}
		}
		_chatJobHistroy.InputData = chatInputData;
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_chatJobHistroy = Contexts.sharedInstance.chat.chatJobHistroy;
		_playerContext = Contexts.sharedInstance.player;
		_hideJob = new ChatAutoHideMessage(_viewModel.SetgroupAlpha);
		_hideHornJob = new ChatAutoHideMessage(_viewModel.SethononaryGpAlpha);
		UpdateChatInfo();
		InputField inputField = _viewModel.UI.Get<InputField>("ChatInputTextInputField");
		if ((bool)inputField)
		{
			inputField.onValidateInput = InputCallBack;
			inputField.onValueChanged.AddListener(InputValueChange);
		}
		_chatHistoryTextTypeDic = new Dictionary<string, int>();
		_chatHistoryTextTypeDic["battle_all"] = 105;
		_chatHistoryTextTypeDic["battle_observer_all"] = 105;
		_chatHistoryTextTypeDic["battle_team"] = 106;
		_chatHistoryTextTypeDic["team"] = 107;
		_chatHistoryTextTypeDic["personal"] = 109;
		_chatHistoryTextTypeDic["system"] = 8;
		_chatHistoryTextTypeDic["hononary1"] = 8;
		_chatHistoryTextTypeDic["hononary2"] = 106;
		_chatHistoryTextTypeDic["prompt"] = 110;
		_chatHistoryTextTypeDic["tacticsSound"] = 108;
		_chatHistoryTextTypeDic["playerlogin"] = 111;
		_chatHistoryTextTypeDic["playerlogout"] = 112;
		_chatHistoryTextTypeDic["vip"] = 142;
		VisibleChange(value: false);
		NotifyManager.MakeNotify(73, Get_chatHistroyChange, SetChatList, initinvoke: true);
		NotifyManager.MakeNotify(74, Get_chatHonChange, HornChange, initinvoke: true);
	}

	private bool Get_chatHistroyChange()
	{
		return _chatJobHistroy.ChatList.Mark;
	}

	private bool Get_chatHonChange()
	{
		return _chatJobHistroy.Tips.Mark;
	}

	private void SetUpChatTypes()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		_hasSetChatType = myPlayerEntity != null;
		if (myPlayerEntity != null)
		{
			_myIsObserver = myPlayerEntity.IsObserver();
		}
		if (myPlayerEntity != null && myPlayerEntity.IsObserver() && RuleUtilty.isRpgDuelDianfeng(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			if (_canuseChatTypes == null)
			{
				_canuseChatTypes = new List<int>();
			}
			else
			{
				_canuseChatTypes.Clear();
			}
			_canuseChatTypes.Add(2);
			_canuseChatTypes.Add(5);
			return;
		}
		if (GameModelLocator.GetInstance().GameModel.IsObserver)
		{
			if (_canuseChatTypes == null)
			{
				_canuseChatTypes = new List<int>();
			}
			else
			{
				_canuseChatTypes.Clear();
			}
			_canuseChatTypes.Add(1);
			_canuseChatTypes.Add(4);
			_canuseChatTypes.Add(5);
			return;
		}
		if (RuleUtilty.IsAvatarUltimateChallenge())
		{
			if (_canuseChatTypes == null)
			{
				_canuseChatTypes = new List<int>();
			}
			else
			{
				_canuseChatTypes.Clear();
			}
			_canuseChatTypes.Add(0);
			return;
		}
		if (GameModelLocator.GetInstance().GameModel.RoomData.RaceType == 15004)
		{
			if (_canuseChatTypes == null)
			{
				_canuseChatTypes = new List<int>();
			}
			else
			{
				_canuseChatTypes.Clear();
			}
			_canuseChatTypes.Add(0);
			_canuseChatTypes.Add(3);
			_canuseChatTypes.Add(4);
			_canuseChatTypes.Add(5);
			return;
		}
		if (GameModelLocator.GetInstance().GameModel.RoomData.RaceType == 25)
		{
			if (_canuseChatTypes == null)
			{
				_canuseChatTypes = new List<int>();
			}
			else
			{
				_canuseChatTypes.Clear();
			}
			_canuseChatTypes.Add(3);
			_canuseChatTypes.Add(5);
			return;
		}
		if (_whisperTargetList.Count == 0)
		{
			if (_canuseChatTypes == null)
			{
				_canuseChatTypes = new List<int>();
			}
			else
			{
				_canuseChatTypes.Clear();
			}
			_canuseChatTypes.Add(0);
			_canuseChatTypes.Add(1);
			_canuseChatTypes.Add(3);
			_canuseChatTypes.Add(5);
			return;
		}
		if (_canuseChatTypes == null)
		{
			_canuseChatTypes = new List<int>();
		}
		else
		{
			_canuseChatTypes.Clear();
		}
		_canuseChatTypes.Add(0);
		_canuseChatTypes.Add(1);
		_canuseChatTypes.Add(3);
		_canuseChatTypes.Add(4);
		_canuseChatTypes.Add(5);
	}

	private void UpdateWhisperPlayer()
	{
		int item = 4;
		if (!_canuseChatTypes.Contains(item))
		{
			ChatTypeDef currentChatType = GetCurrentChatType();
			SetUpChatTypes();
			_chatTypeIndex = _canuseChatTypes.IndexOf((int)currentChatType);
		}
	}

	private ChatTypeDef GetCurrentChatType()
	{
		return (ChatTypeDef)_canuseChatTypes[_chatTypeIndex];
	}

	private void InputValueChange(string info)
	{
		if (GetCurrentChatType() == ChatTypeDef.Whisper && !string.IsNullOrEmpty(_whisperPrefix))
		{
			if (info.Length < _whisperPrefix.Length)
			{
				info = _whisperPrefix;
				_inputContent = "";
				_viewModel.ChatInputTextText = info;
			}
			else
			{
				_inputContent = info.Substring(_whisperPrefix.Length);
			}
		}
		else
		{
			_inputContent = info;
		}
	}

	private char InputCallBack(string str, int i, char c)
	{
		if (c == '[' || c == ']')
		{
			c = '\0';
		}
		return c;
	}

	private void HornChange(bool old, bool newval)
	{
		if (newval && _chatJobHistroy != null)
		{
			for (int i = 0; i < _chatJobHistroy.Tips.Group.Count; i++)
			{
				ChatHononaryData data = (ChatHononaryData)(object)_chatJobHistroy.Tips.Group[i];
				ReceiveHornData(i + 1, ref data);
				_chatJobHistroy.Tips.Group[i] = data;
			}
			_chatJobHistroy.Tips.Mark = false;
		}
		if (_chatJobHistroy != null)
		{
			_chatJobHistroy.Tips.Mark = false;
		}
	}

	private void ReceiveHornData(int index, ref ChatHononaryData data)
	{
		TextStyleConfigParser.TextStyleDictionary.TryGetValue(139, out var _);
		string unityColor = GetUnityColor(139);
		string value2 = $"<color={unityColor}>{GetHornContext(ref data)}</color>";
		string text = null;
		string text2 = null;
		float num = 16f;
		if (data.Team == 1)
		{
			text2 = "hononary/backt";
			if (data.VipLevel >= 5)
			{
				text = "vip/chatvip" + data.VipLevel;
			}
			else if (data.LegendWeapon != "")
			{
				text = "hononary/legendt";
				num = 38f;
			}
			else if (data.HeroWeapon != "" || data.WeaponName != "")
			{
				text = "hononary/herot";
				num = 32f;
			}
		}
		else
		{
			text2 = "hononary/backct";
			if (data.VipLevel >= 5)
			{
				text = "vip/chatvip" + data.VipLevel;
			}
			else if (data.LegendWeapon != "")
			{
				text = "hononary/legendct";
				num = 38f;
			}
			else if (data.HeroWeapon != "" || data.WeaponName != "")
			{
				text = "hononary/heroct";
				num = 32f;
			}
		}
		base.Loader.RetriveSprite(UiAssetBundleUtils.UiBundleName, $"Assets/Res/Assets/ui/GameGUIRes/common/{text2}.png", _viewModel.GethbgImage(index), autosetnative: true);
		if (text != null)
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.UiBundleName, $"Assets/Res/Assets/ui/GameGUIRes/common/{text}.png", _viewModel.GethiconImage(index), autosetnative: true);
		}
		_viewModel.SethgtextString(index, value2);
		_viewModel.SethgtextAnchoredposition(index, new Vector2(num + 10f, 0f));
	}

	private string GetHornContext(ref ChatHononaryData data)
	{
		string text = null;
		if (!string.IsNullOrEmpty(data.LegendWeapon))
		{
			text = ((data.MsgType == "playerlogin") ? ScriptLocalization.Get("UselegendweaponLogin") : ScriptLocalization.Get("UselegendweaponLogout"));
			if (data.IsObserver)
			{
				text = ((data.MsgType == "playerlogin") ? ScriptLocalization.Get("UselegendweaponObserverLogin") : ScriptLocalization.Get("UselegendweaponObserverLogout"));
			}
			return PrintfUtility.Printf(text, new string[2]
			{
				data.PlayerName,
				LanguageUtils.GetWeaponCnName(data.LegendWeapon)
			});
		}
		if (!string.IsNullOrEmpty(data.HeroWeapon))
		{
			text = ((data.MsgType == "playerlogin") ? ScriptLocalization.Get("UseheroweaponLogin") : ScriptLocalization.Get("UseheroweaponLogout"));
			if (data.IsObserver)
			{
				text = ((data.MsgType == "playerlogin") ? ScriptLocalization.Get("UseheroweaponObserverLogin") : ScriptLocalization.Get("UseheroweaponObserverLogout"));
			}
			return PrintfUtility.Printf(text, new string[2]
			{
				data.PlayerName,
				LanguageUtils.GetWeaponCnName(data.HeroWeapon)
			});
		}
		if (!string.IsNullOrEmpty(data.WeaponName))
		{
			return string.Format(ScriptLocalization.Get("WEAPON_JOIN_MESSAGE"), data.PlayerName, LanguageUtils.GetWeaponCnName(data.WeaponName));
		}
		text = ((data.MsgType == "playerlogin") ? ScriptLocalization.Get("VipLogin") : ScriptLocalization.Get("VipLogout"));
		if (data.IsObserver)
		{
			text = ((data.MsgType == "playerlogin") ? ScriptLocalization.Get("VipObserverLogin") : ScriptLocalization.Get("VipObserverLogout"));
		}
		return PrintfUtility.Printf(text, data.PlayerName);
	}

	public void SetChatList(bool old, bool newval)
	{
		if (newval && _chatJobHistroy != null)
		{
			ShowChatStatus();
		}
		if (_chatJobHistroy != null)
		{
			_chatJobHistroy.ChatList.Mark = false;
		}
	}

	private void ShowChatStatus()
	{
		List<IChatHistroyData> group = _chatJobHistroy.ChatList.Group;
		if (GameSetting.Config.OpenChatting != 0)
		{
			for (int i = 0; i < group.Count; i++)
			{
				ChatHistroyData info = (ChatHistroyData)(object)group[i];
				BuildChatContent(i + 1, ref info);
			}
			UpdateChatChipWithInterval(0);
			for (int j = group.Count; j < 6; j++)
			{
				_viewModel.SetgroupAlpha(j + 1, 0f);
			}
		}
	}

	private void BuildChatContent(int index, ref ChatHistroyData info)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			if (info.MsgType == "personal" && !myPlayerEntity.basicInfo.Cid.ToString().EndsWith(info.SenderCid) && !_whisperTargetCidList.Contains(info.SenderCid))
			{
				_whisperTargetCidList.Add(info.SenderCid);
				_whisperTargetList.Add(info.SenderName);
				UpdateWhisperPlayer();
				this.InfoFormat("Add whisperTarget:{0}, cid:{1}, myCid:{2}", info.SenderName, info.SenderCid, myPlayerEntity.basicInfo.Cid);
			}
			_viewModel.SetvipiconShow(index, info.VipLv != 0);
			if (info.VipLv != 0)
			{
				Image img = _viewModel.GetvipiconImage(index);
				base.Loader.RetriveSprite(UiAssetBundleUtils.UiBundleName, $"Assets/Res/Assets/ui/GameGUIRes/common/vip/chatvip{info.VipLv}.png", img);
			}
			UpdateChatInfo(index, ref info);
		}
		else
		{
			_viewModel.SetvipiconShow(index, value: false);
		}
	}

	private string GetUnityColor(int textStyleId)
	{
		if (TextStyleConfigParser.TextStyleDictionary.TryGetValue(textStyleId, out var value))
		{
			return value.UnityRichColor;
		}
		return "#FFFFFFFF";
	}

	private void UpdateChatInfo(int index, ref ChatHistroyData info)
	{
		int value = 0;
		if (!_chatHistoryTextTypeDic.TryGetValue(info.MsgType, out value))
		{
			value = 105;
		}
		string unityColor = GetUnityColor(value);
		string unityColor2 = GetUnityColor(143);
		if (!ColorUtility.TryParseHtmlString(unityColor, out var color))
		{
			color = Color.white;
		}
		_viewModel.SetchattextTextcolor(index, color);
		if (!string.IsNullOrEmpty(info.SenderName))
		{
			if (!string.IsNullOrEmpty(info.AssembleRpgVipText))
			{
				info.AssembleHead = $"<color=#FF0000>{info.AssembleRpgVipText}</color><color={unityColor2}>{info.AssembleHead.Substring(info.AssembleRpgVipText.Length)}</color>";
			}
			else
			{
				info.AssembleHead = $"<color={unityColor2}>{info.AssembleHead}</color>";
			}
		}
		ExChatText exChatText = _viewModel.UI.Get<ExChatText>($"chattext{index}");
		if ((bool)exChatText)
		{
			exChatText.color = color;
			exChatText.HeadText = info.AssembleHead;
			exChatText.text = (info.Friendly ? ScriptLocalization.Get("Friendly") : "") + info.AssembleBody;
			BaseAsyncManager.Instance.StartCoRoutine(ChatTe(exChatText));
		}
	}

	private IEnumerator ChatTe(ExChatText chatText)
	{
		yield return Yielders.EndOfFrame;
		chatText.SetVerticesDirty();
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		UpdateChatChipWithInterval(_timeComponent.FrameInterval);
	}

	private void UpdateChatChipWithInterval(int interval)
	{
		if (_chatJobHistroy == null || InputVisible)
		{
			return;
		}
		if (!_chatJobHistroy.ChatList.Mark)
		{
			for (int i = 0; i < _chatJobHistroy.ChatList.Group.Count; i++)
			{
				ChatHistroyData chatHistroyData = (ChatHistroyData)(object)_chatJobHistroy.ChatList.Group[i];
				_hideJob.Update(i + 1, ref chatHistroyData.AlphaData, interval);
				_chatJobHistroy.ChatList.Group[i] = chatHistroyData;
			}
		}
		if (!_chatJobHistroy.Tips.Mark)
		{
			for (int j = 0; j < _chatJobHistroy.Tips.Group.Count; j++)
			{
				ChatHononaryData chatHononaryData = (ChatHononaryData)(object)_chatJobHistroy.Tips.Group[j];
				_hideHornJob.Update(j + 1, ref chatHononaryData.AlphaData, interval);
				_chatJobHistroy.Tips.Group[j] = chatHononaryData;
			}
		}
	}

	private void UpdateChatInfo()
	{
		int currentChatType = (int)GetCurrentChatType();
		_viewModel.ChatTypeTextString = _chatTypeDesc[currentChatType];
		_viewModel.ChatTypeTextTextcolor = _chatTypeColor[currentChatType];
	}

	private void UpdateWhisperInfo()
	{
		if (GetCurrentChatType() == ChatTypeDef.Whisper)
		{
			if (_whisperIndex >= 0 && _whisperIndex < _whisperTargetList.Count)
			{
				_whisperPrefix = ScriptLocalization.Get("You") + _whisperTargetList[_whisperIndex] + ScriptLocalization.Get("Speak");
				_viewModel.ChatInputTextText = _whisperPrefix + _inputContent;
			}
		}
		else
		{
			_whisperPrefix = "";
			_viewModel.ChatInputTextText = _inputContent;
		}
	}

	private void IncreaseValueWithList<T>(ref int value, List<T> list)
	{
		if (value == list.Count - 1)
		{
			value = 0;
		}
		else
		{
			value = (value + 1) % list.Count;
		}
	}

	private void DecreaseValueWithList<T>(ref int value, List<T> list)
	{
		if (value == 0)
		{
			value = list.Count - 1;
		}
		else
		{
			value = (value - 1) % list.Count;
		}
	}

	private bool HideChatPanel(PlayerEntity entity)
	{
		return TplManager.Instance.GameBootConfig.isGolbalRoom;
	}

	public bool OnKeyDown(KeyCode key)
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		switch (key)
		{
		case KeyCode.Return:
		case KeyCode.KeypadEnter:
			if (!HideChatPanel(myPlayerEntity))
			{
				InputVisible = !InputVisible;
			}
			break;
		case KeyCode.LeftBracket:
			DecreaseValueWithList(ref _chatTypeIndex, _canuseChatTypes);
			UpdateChatInfo();
			UpdateWhisperInfo();
			break;
		case KeyCode.RightBracket:
			IncreaseValueWithList(ref _chatTypeIndex, _canuseChatTypes);
			UpdateChatInfo();
			UpdateWhisperInfo();
			break;
		default:
			if (GetCurrentChatType() == ChatTypeDef.Whisper)
			{
				switch (key)
				{
				case KeyCode.UpArrow:
					IncreaseValueWithList(ref _whisperIndex, _whisperTargetList);
					UpdateWhisperInfo();
					break;
				case KeyCode.DownArrow:
					DecreaseValueWithList(ref _whisperIndex, _whisperTargetList);
					UpdateWhisperInfo();
					break;
				}
			}
			else if (key == KeyCode.Alpha3 && myPlayerEntity.HasStatus(PlayerInfoStatusConstant.CANNOT_CHANGE_CAREER_WEAPON.ID))
			{
				_chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>{1}</body></message>", "prompt", string.Format(ScriptLocalization.Get("NO_CHANGE_WEAPON"))));
			}
			else if (key == KeyCode.Alpha5 && myPlayerEntity.HasStatus(PlayerInfoStatusConstant.CANNOT_CHANGE_TACTICAL_WEAPON.ID))
			{
				_chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>{1}</body></message>", "prompt", string.Format(ScriptLocalization.Get("NO_CHANGE_TACTICAL_WEAPON"))));
			}
			break;
		}
		return InputVisible;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return InputVisible;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return InputVisible;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return InputVisible;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.Logger;
using SSJJBase.Thread;
using UnityEngine;
using agora_gaming_rtc;

namespace Assets.Sources.Ui.Model.Common;

public class VoiceModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetBattleRoomContext, IKeyboardResponder
{
	private enum VoiceState
	{
		Close,
		Keyboard,
		Free
	}

	private VoiceViewModel _viewModel;

	private readonly List<AudioVolumeInfo> _playerVolumeList = new List<AudioVolumeInfo>(16);

	private bool _isJoinSucc;

	private bool _initRtcEngineSucc;

	private int _speakerVolume = 100;

	private List<int> _ingoreList = new List<int> { 1, 18, 1008, 1009, 1010, 1011 };

	private BattleRoomContext _battleRoomContext;

	private PlayerContext _playerContext;

	private float _updateSpeakTime;

	private float _selfSpeakTime;

	private int _currTeam;

	private IRtcEngine _rtcEngine;

	private VoiceState _keyStates;

	private readonly int _initRtcEngineCount = 3;

	private int _checkFrame;

	private ActiveChip _statesActiveChip = new ActiveChip();

	private ActiveChip _tipsActiveChip = new ActiveChip();

	private ActiveChip _closeTipsActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new VoiceViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_playerContext.myPlayerEntity != null && _rtcEngine != null)
			{
				HideSpeaker();
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ContentShow = false;
		_viewModel.TipsShow = false;
		if (VoiceUtility.CheckVoiceIsForbiden(_battleRoomContext.roomData.Data.RaceType))
		{
			Destory();
			return;
		}
		if (VoiceUtility.IsOperatingSystemCanRunVoice())
		{
			BaseAsyncManager.Instance.StartCoRoutine(InitRtcEngine());
			return;
		}
		_viewModel.TipsShow = true;
		_tipsActiveChip.Time = 5000;
	}

	private void InitViewShow()
	{
		_viewModel.ContentShow = true;
		for (int i = 0; i < 7; i++)
		{
			_viewModel.SetPlayerShow(i + 1, value: false);
		}
		InitStates();
		SetStates();
		_statesActiveChip.Time = 5000;
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiMyPlayer_PlayerName, SetMyPlayerName, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsSpeaking, SetMyPlayerSpeaking, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_Team, SetVoiceChannel, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetDead, null, initinvoke: true, isFrameSeparation: true);
	}

	private IEnumerator InitRtcEngine()
	{
		int tryCount = 1;
		while (tryCount < _initRtcEngineCount && !_initRtcEngineSucc)
		{
			try
			{
				if (_rtcEngine == null)
				{
					_rtcEngine = IRtcEngine.GetEngine("98d2e8d7a13d4b2192f7b39b507bc4ca");
				}
				_rtcEngine.OnJoinChannelSuccess = OnJoinChannelSuccess;
				_rtcEngine.OnReJoinChannelSuccess = OnJoinChannelSuccess;
				_rtcEngine.OnVolumeIndication = OnVolumeIndication;
				_rtcEngine.OnError = OnError;
				_rtcEngine.OnUserJoined = OnUserJoined;
				_rtcEngine.SetLogFilter(LOG_FILTER.ERROR);
				_rtcEngine.SetChannelProfile(CHANNEL_PROFILE.GAME_FREE_MODE);
				_rtcEngine.EnableAudioVolumeIndication(800, 3);
				VoiceUtility.AdjustVoiceVolume();
				_initRtcEngineSucc = true;
				InitViewShow();
				break;
			}
			catch (Exception arg)
			{
				this.LogErrorFormat("Try Count: {0}. Voice Error InitRtcEngine: {1}", tryCount, arg);
			}
			tryCount++;
			yield return Yielders.GetWaitForSeconds(3f);
		}
	}

	private void SetDead(bool arg1, bool arg2)
	{
		if (!(!arg1 && arg2) || !RuleUtilty.IsAvatarUltimateChallenge())
		{
			return;
		}
		_viewModel.ContentShow = false;
		if (_rtcEngine != null)
		{
			if (string.IsNullOrEmpty(_playerContext.myPlayerEntity.voice.ChannelName))
			{
				_rtcEngine.DisableVideo();
			}
			else
			{
				_rtcEngine.LeaveChannel();
			}
		}
	}

	private void SetVoiceChannel(int arg1, int arg2)
	{
		if (_currTeam != UiIEventCondition.Get_uiMyPlayer_Team() && _rtcEngine != null && _playerContext.myPlayerEntity != null)
		{
			_currTeam = UiIEventCondition.Get_uiMyPlayer_Team();
			if (string.IsNullOrEmpty(_playerContext.myPlayerEntity.voice.ChannelName))
			{
				_rtcEngine.DisableVideo();
			}
			else
			{
				_rtcEngine.LeaveChannel();
			}
			if (RuleUtilty.IsVoiceShowAndNoTeamDiff(_battleRoomContext.roomData.Data.RaceType))
			{
				_playerContext.myPlayerEntity.voice.ChannelName = $"{_battleRoomContext.roomData.Data.RaceType}_{_battleRoomContext.roomData.Data.RoomId}";
			}
			else
			{
				_playerContext.myPlayerEntity.voice.ChannelName = $"{_battleRoomContext.roomData.Data.RaceType}_{_battleRoomContext.roomData.Data.RoomId}_{_currTeam}";
			}
			_rtcEngine.JoinChannel(_playerContext.myPlayerEntity.voice.ChannelName, null, (uint)_playerContext.myPlayerEntity.entityId.Value);
			MutePlayer();
		}
	}

	private void MutePlayer()
	{
		Dictionary<uint, long> dictionary = new Dictionary<uint, long>();
		foreach (KeyValuePair<uint, long> item in _battleRoomContext.playerInfo.VoiceShieldDictionary)
		{
			foreach (PlayerEntity item2 in _playerContext)
			{
				if (item.Value == item2.basicInfo.Cid)
				{
					_rtcEngine.MuteRemoteAudioStream((uint)item2.entityId.Value, mute: true);
					dictionary.Add((uint)item2.entityId.Value, item2.basicInfo.Cid);
				}
			}
		}
		_battleRoomContext.playerInfo.VoiceShieldDictionary.Clear();
		foreach (KeyValuePair<uint, long> item3 in dictionary)
		{
			_battleRoomContext.playerInfo.VoiceShieldDictionary.Add(item3.Key, item3.Value);
		}
	}

	private void SetMyPlayerSpeaking(bool arg1, bool arg2)
	{
		_viewModel.SelfPlayerShow = arg2;
	}

	private void SetMyPlayerName(string arg1, string arg2)
	{
		string uiMyPlayer_PlayerName = UiIEventCondition.Get_uiMyPlayer_PlayerName();
		if (!string.IsNullOrEmpty(uiMyPlayer_PlayerName))
		{
			_viewModel.SelfNameString = uiMyPlayer_PlayerName;
		}
	}

	private void SetSpeakVolume(int arg1, int arg2)
	{
		if (_isJoinSucc && _rtcEngine != null)
		{
			_rtcEngine.SetSpeakerphoneVolume(_speakerVolume);
		}
	}

	private void OnWarning(int warn, string msg)
	{
		this.LogWarnFormat("Voice Warning, warn: {0} msg:{1}", warn, msg);
	}

	private void OnVolumeIndication(AudioVolumeInfo[] speakers, int speakerNumber, int totalVolume)
	{
		UpdateSpeaks(speakers);
	}

	public void UpdateSpeaks(AudioVolumeInfo[] speakers)
	{
		if (speakers.Length == 1 && speakers[0].uid == 0)
		{
			if (_playerContext.myPlayerEntity != null)
			{
				_playerContext.myPlayerEntity.voice.Speaking = speakers[0].volume > 30;
				_selfSpeakTime = Time.time;
			}
			return;
		}
		_updateSpeakTime = Time.time;
		_playerVolumeList.Clear();
		for (int i = 0; i < speakers.Length; i++)
		{
			if (speakers[i].volume > 30 && _playerContext.GetEntityWithEntityId((int)speakers[i].uid) != null)
			{
				_playerVolumeList.Add(speakers[i]);
			}
		}
		int num = ((_playerVolumeList.Count > 7) ? (_playerVolumeList.Count - 7) : 0);
		int count = _playerVolumeList.Count;
		for (int j = 0; j < count - num; j++)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId((int)_playerVolumeList[j + num].uid);
			_viewModel.SetPlayerShow(j + 1, value: true);
			_viewModel.SetNameString(j + 1, entityWithEntityId.basicInfo.PlayerName);
		}
		for (int k = count - num; k < 7; k++)
		{
			_viewModel.SetPlayerShow(k + 1, value: false);
		}
	}

	private void HideSpeaker()
	{
		_checkFrame++;
		if (_checkFrame != 150)
		{
			return;
		}
		_checkFrame = 0;
		if (Time.time - _updateSpeakTime > 0.5f)
		{
			for (int i = 0; i < 7; i++)
			{
				_viewModel.SetPlayerShow(i + 1, value: false);
			}
		}
		if (Time.time - _selfSpeakTime > 0.5f)
		{
			_playerContext.myPlayerEntity.voice.Speaking = false;
		}
	}

	private void OnUserJoined(uint uid, int elapsed)
	{
		int num = 0;
		long num2 = 0L;
		uint num3 = 0u;
		foreach (PlayerEntity item in _playerContext)
		{
			if (item == null || item.entityId.Value != uid)
			{
				continue;
			}
			num2 = item.basicInfo.Cid;
			foreach (KeyValuePair<uint, long> item2 in _battleRoomContext.playerInfo.VoiceShieldDictionary)
			{
				if (item2.Value == num2)
				{
					_rtcEngine.MuteRemoteAudioStream(item2.Key, mute: true);
					num = item.entityId.Value;
					num3 = item2.Key;
					break;
				}
			}
			break;
		}
		if (num != 0 && num3 != 0 && _battleRoomContext.playerInfo.VoiceShieldDictionary.Remove(num3))
		{
			_battleRoomContext.playerInfo.VoiceShieldDictionary.Add((uint)num, num2);
		}
	}

	private void OnJoinChannelSuccess(string channelName, uint uid, int elapsed)
	{
		_isJoinSucc = true;
		this.InfoFormat("VoiceOnJoinChannelSuccess, channelName: {0} uid:{1}", channelName, uid);
	}

	private void OnError(int error, string msg)
	{
		if (!_ingoreList.Contains(error))
		{
			this.LogErrorFormat("VoiceError, error: {0} msg:{1}", error, msg);
		}
	}

	private void InitChips()
	{
		_statesActiveChip.Time = 0;
		_tipsActiveChip.Time = 0;
		_closeTipsActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.StatesShow = _statesActiveChip.Update(_timeComponent);
		_viewModel.TipsShow = _tipsActiveChip.Update(_timeComponent);
		_viewModel.CloseTipsShow = _closeTipsActiveChip.Update(_timeComponent);
	}

	private void InitStates()
	{
		_keyStates = (VoiceState)PlayerPrefs.GetInt("VoiceStates", 0);
	}

	private void SaveStates()
	{
		PlayerPrefs.SetInt("VoiceStates", (int)_keyStates);
		PlayerPrefs.Save();
	}

	private void SetStates()
	{
		switch (_keyStates)
		{
		case VoiceState.Keyboard:
			_viewModel.IconSprite = base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/shieldspeak/group.png", delegate(Sprite sprite)
			{
				_viewModel.IconSprite = sprite;
			});
			if (_rtcEngine != null)
			{
				_rtcEngine.EnableAudio();
				_rtcEngine.MuteLocalAudioStream(mute: true);
			}
			if (_playerContext.isMyPlayer)
			{
				_playerContext.myPlayerEntity.voice.Speaking = false;
			}
			break;
		case VoiceState.Free:
			_viewModel.IconSprite = base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/shieldspeak/free.png", delegate(Sprite sprite)
			{
				_viewModel.IconSprite = sprite;
			});
			if (_rtcEngine != null)
			{
				_rtcEngine.EnableAudio();
				_rtcEngine.MuteLocalAudioStream(mute: false);
			}
			break;
		case VoiceState.Close:
			_viewModel.IconSprite = base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/shieldspeak/close.png", delegate(Sprite sprite)
			{
				_viewModel.IconSprite = sprite;
			});
			if (_rtcEngine != null)
			{
				_rtcEngine.DisableAudio();
			}
			if (_playerContext.isMyPlayer)
			{
				_playerContext.myPlayerEntity.voice.Speaking = false;
			}
			break;
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		switch (key)
		{
		case KeyCode.K:
			if (_isJoinSucc)
			{
				_keyStates = (VoiceState)((int)(_keyStates + 1) % 3);
				if (_keyStates == VoiceState.Close && _battleRoomContext.playerInfo.VoiceFlag == 0)
				{
					_battleRoomContext.playerInfo.VoiceFlag = 1;
					_closeTipsActiveChip.Time = 5000;
					_statesActiveChip.Time = 0;
				}
				SetStates();
				SaveStates();
			}
			break;
		case KeyCode.J:
			if (_keyStates == VoiceState.Keyboard && _isJoinSucc && _rtcEngine != null)
			{
				_rtcEngine.MuteLocalAudioStream(mute: false);
			}
			break;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (key == KeyCode.J && _keyStates == VoiceState.Keyboard && _isJoinSucc)
		{
			if (_rtcEngine != null)
			{
				_rtcEngine.MuteLocalAudioStream(mute: true);
			}
			if (_playerContext.isMyPlayer)
			{
				_playerContext.myPlayerEntity.voice.Speaking = false;
			}
		}
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}
}

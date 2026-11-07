using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using agora_gaming_rtc;

namespace Assets.Sources.Ui.Model.Common;

public class VoiceShieldModel : AbstractModel, IPlaybackSystem, ICursorControl, IKeyboardResponder, ISetPlayerContext, ISetBattleRoomContext
{
	private VoiceShieldViewModel _viewModel;

	private List<VoiceShieldCellModel> _playerCellList;

	private IListNotify _notifyListener;

	private readonly List<uint> _shieldList = new List<uint>(32);

	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new VoiceShieldViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.CenterRootshow = false;
		if (VoiceUtility.CheckVoiceIsForbiden(_battleRoomContext.roomData.Data.RaceType))
		{
			Destory();
			return;
		}
		_notifyListener = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allPlayerEntity_SelfSideList);
		_playerCellList = new List<VoiceShieldCellModel>(32);
		for (int i = 0; i < 16; i++)
		{
			CreateOrGetCellModel(i);
		}
		NotifyManager.MakeNotify(31, UiIEventCondition.Get_gameSetting_ShowVoiceShield, SetShowVoiceShield);
		_viewModel.OkTextString = ScriptLocalization.Get("okbutton");
		_viewModel.TitleString = ScriptLocalization.Get("shieldTitle");
		_viewModel.OkButtonClicked.AddListener(OnOkButtonClicked);
		_viewModel.CenterRootshow = false;
	}

	private void OnOkButtonClicked()
	{
		_viewModel.CenterRootshow = false;
		IRtcEngine rtcEngine = IRtcEngine.QueryEngine();
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (rtcEngine == null || myPlayerEntity == null)
		{
			return;
		}
		int num = 0;
		_shieldList.Clear();
		List<PlayerEntity> allPlayerEntity_SelfSideList = UiIEventCondition.Get_allPlayerEntity_SelfSideList();
		foreach (uint key in _battleRoomContext.playerInfo.VoiceShieldDictionary.Keys)
		{
			_shieldList.Add(key);
		}
		_battleRoomContext.playerInfo.VoiceShieldDictionary.Clear();
		foreach (PlayerEntity item in allPlayerEntity_SelfSideList)
		{
			if (CreateOrGetCellModel(num++).CheckToggleIsOn())
			{
				_battleRoomContext.playerInfo.VoiceShieldDictionary.Add((uint)item.entityId.Value, item.basicInfo.Cid);
			}
		}
		for (int i = 0; i < _shieldList.Count; i++)
		{
			if (!IsInDictionary(_shieldList[i], _battleRoomContext.playerInfo.VoiceShieldDictionary))
			{
				rtcEngine.MuteRemoteAudioStream(_shieldList[i], mute: false);
			}
		}
		foreach (KeyValuePair<uint, long> item2 in _battleRoomContext.playerInfo.VoiceShieldDictionary)
		{
			rtcEngine.MuteRemoteAudioStream(item2.Key, mute: true);
		}
	}

	private bool IsInDictionary(uint id, Dictionary<uint, long> dictionary)
	{
		foreach (KeyValuePair<uint, long> item in dictionary)
		{
			if (item.Key == id)
			{
				return true;
			}
		}
		return false;
	}

	private VoiceShieldCellModel CreateOrGetCellModel(int idx)
	{
		if (_playerCellList.Count <= idx)
		{
			_playerCellList.Add(new VoiceShieldCellModel());
			_playerCellList[idx].SetContainerAndListener(_viewModel.ContentObj, _notifyListener, idx);
			_playerCellList[idx].SetPlayerContext(_playerContext);
			_playerCellList[idx].Initialize();
		}
		return _playerCellList[idx];
	}

	private void SetShowVoiceShield(bool ov, bool show)
	{
		_viewModel.CenterRootshow = false;
		if (show)
		{
			_viewModel.CenterRootshow = true;
			List<PlayerEntity> allPlayerEntity_SelfSideList = UiIEventCondition.Get_allPlayerEntity_SelfSideList();
			for (int i = 0; i < allPlayerEntity_SelfSideList.Count; i++)
			{
				CreateOrGetCellModel(i).Show();
			}
			for (int j = allPlayerEntity_SelfSideList.Count; j < _playerCellList.Count; j++)
			{
				_playerCellList[j].Hide();
			}
		}
	}

	public int GetCursorState()
	{
		if (!_viewModel.CenterRootshow && CloseDelay <= 0)
		{
			return 0;
		}
		return 128;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			_viewModel.CenterRootshow = false;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
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

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

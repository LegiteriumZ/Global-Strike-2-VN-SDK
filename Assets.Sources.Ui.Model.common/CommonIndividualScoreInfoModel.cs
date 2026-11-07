using System;
using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Free.Data;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class CommonIndividualScoreInfoModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetGameRuleContext, ISetBattleRoomContext, IKeyboardResponder, ICursorControl
{
	private float _timeToNextMission;

	protected IPlayerScoreCell[] _playerCells;

	protected CommonIndividualScoreInfoViewModel _viewModel;

	protected int TeamNum = 2;

	protected int TeamMember = 8;

	protected Type CellClass;

	protected bool IsStrike;

	protected NotifyGroup _notifyGroup = new NotifyGroup();

	private bool _rewardChanged;

	protected PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	protected int RaceType;

	protected BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CommonIndividualScoreInfoViewModel();
		CellClass = typeof(CommonIndividualScoreCellModel);
	}

	protected override void DoSubscribe()
	{
		if (GameModelLocator.GetInstance().GameModel.IsMatch)
		{
			_viewModel.ViewGameObjectShow = false;
		}
		if (UiIEventCondition.Get_RoomData_IsStrike() != IsStrike)
		{
			_viewModel.ShowShow = false;
			return;
		}
		for (int i = 0; i < 7; i++)
		{
			_viewModel.SetExtraExpShow(i + 1, value: false);
		}
		for (int j = 0; j < 4; j++)
		{
			_viewModel.SetExtraGpShow(j + 1, value: false);
		}
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gameMessageData_MessageData, SetMessageData, null, initinvoke: true);
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_profit_TotalAllExp, SetTotalAllExp, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_profit_TotalAllGp, SetTotalAllGp, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_profit_TotalCrystal, SetTotalCrystal, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiRoomData_RoomTitle, SetRoomTitle, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_allKillInfo_ObserverList, SetObserverList, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_IsObserver, SetIsObserver, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_allKillInfo_AllCount, SetAllCount, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_LimitNum, SetLimitNum, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_IsMatch, SetMatchBack, null, initinvoke: true));
		InitButtonCallbacks();
		CreateCells();
		SetVisible(value: false);
	}

	protected virtual void SetMatchBack(bool ov, bool flag)
	{
		_viewModel.ResultBgShow = !flag;
	}

	private void SetLimitNum(int arg1, int arg2)
	{
		AddUpdateHandler(SetPlayerNum);
	}

	private void SetAllCount(int arg1, int arg2)
	{
		AddUpdateHandler(SetPlayerNum);
	}

	protected virtual void SetPlayerNum(int idx)
	{
		_viewModel.PlayerNumberString = UiIEventCondition.Get_allKillInfo_AllCount() + "/" + UiIEventCondition.Get_uiRoomData_LimitNum();
	}

	protected virtual void SetRoomTitle(string arg1, string arg2)
	{
		_viewModel.RoomString = arg2;
	}

	private void SetTotalCrystal(int arg1, int arg2)
	{
		_rewardChanged = true;
	}

	private void SetTotalAllGp(int arg1, int arg2)
	{
		_rewardChanged = true;
	}

	private void SetTotalAllExp(int arg1, int arg2)
	{
		_rewardChanged = true;
	}

	protected virtual void SetIsObserver(bool ov, bool flag)
	{
		_viewModel.ResultBgShow = !flag;
	}

	protected virtual void SetObserverList(List<string> ov, List<string> list)
	{
		_viewModel.ObserverBackShow = list.Count > 0;
		for (int i = 0; i < 15; i++)
		{
			_viewModel.SetObserverString(i + 1, (i < list.Count) ? list[i] : "");
		}
	}

	private void SetMessageData(GameMessageData ov, GameMessageData messageData)
	{
		if (messageData != null)
		{
			GameMessageType type = messageData.Type;
			if (type == GameMessageType.SHOWNEXTBATTLE)
			{
				_timeToNextMission = _timeComponent.ClientRealTime + messageData.Time;
				SetVisible(value: true);
			}
		}
	}

	private void InitButtonCallbacks()
	{
		_viewModel.ButtonContinueClicked.AddListener(OnContinue);
		_viewModel.ButtonContinueClicked.AddListener(OnExit);
	}

	private void OnContinue()
	{
		SetVisible(value: false);
	}

	private void SetVisible(bool value)
	{
		_viewModel.ShowShow = value;
		_gameRuleContext.individualVisible.IndividualVisible = value;
		_notifyGroup.SetSuspend(!value);
	}

	private void OnExit()
	{
	}

	private void ShowReward()
	{
		ProfitModel profitModel = GameModelLocator.GetInstance().GameModel.ProfitModel.GetProfitModel();
		_viewModel.CurrentExpString = profitModel.totalExp.ToString();
		_viewModel.CurrentCrystalString = profitModel.totalCrystal.ToString();
		_viewModel.CurrentExpPercentString = profitModel.totalExpPer.ToString();
		_viewModel.CurrentGpString = profitModel.totalGp.ToString();
		_viewModel.CurrentGpPercentString = profitModel.totalGpPer.ToString();
		for (int i = 0; i < profitModel.expPlusList.Count; i++)
		{
			int num = profitModel.expPlusList[i];
			if (num > 0)
			{
				_viewModel.SetExtraExpShow(i + 1, value: true);
				_viewModel.SetExtraExpString(i + 1, num.ToString());
				if (i != 6)
				{
					continue;
				}
				int uiMyPlayer_VipLevel = UiIEventCondition.Get_uiMyPlayer_VipLevel();
				if (uiMyPlayer_VipLevel > 0)
				{
					base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/vip/expvip" + uiMyPlayer_VipLevel + ".png", delegate(Sprite sprite)
					{
						_viewModel.VipExpTitleSprite = sprite;
					});
				}
			}
			else
			{
				_viewModel.SetExtraExpShow(i + 1, value: false);
			}
		}
		for (int j = 0; j < profitModel.gpPlusList.Count; j++)
		{
			int num2 = profitModel.gpPlusList[j];
			if (num2 > 0)
			{
				_viewModel.SetExtraGpShow(j + 1, value: true);
				_viewModel.SetExtraGpString(j + 1, num2.ToString());
			}
			else
			{
				_viewModel.SetExtraGpShow(j + 1, value: false);
			}
		}
	}

	private void LerpResultShow()
	{
		if (!_viewModel.ShowShow)
		{
			_viewModel.ResultShow = false;
		}
		else if (!((double)_timeToNextMission < 0.001))
		{
			float num = _timeToNextMission - (float)_timeComponent.ClientRealTime;
			if (num < 0f)
			{
				_timeToNextMission = 0f;
				SetVisible(value: false);
			}
			_viewModel.ResultShow = !_battleRoomContext.roomData.IsObserver;
			_viewModel.CountDownString = Mathf.FloorToInt(num / 1000f).ToString();
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (UiIEventCondition.Get_RoomData_IsStrike() != IsStrike)
		{
			return false;
		}
		if (key == KeyCode.Tab)
		{
			if (_viewModel.ResultShow)
			{
				return false;
			}
			SetVisible(value: true);
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (UiIEventCondition.Get_RoomData_IsStrike() != IsStrike)
		{
			return false;
		}
		if (key == KeyCode.Tab)
		{
			if (_viewModel.ResultShow)
			{
				return false;
			}
			SetVisible(value: false);
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

	public int GetCursorState()
	{
		if (UiIEventCondition.Get_RoomData_IsStrike() != IsStrike)
		{
			return 0;
		}
		if (!_viewModel.ResultShow)
		{
			return 0;
		}
		return 32;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	protected virtual void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamNum * TeamMember];
		if (TeamNum == 2)
		{
			IListNotify listNotify = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allKillInfo_Team1);
			IListNotify listNotify2 = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allKillInfo_Team2);
			for (int i = 0; i < _playerCells.Length; i++)
			{
				_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
				_playerCells[i].Container = ((i < TeamMember) ? _viewModel.TeamGridObj1 : _viewModel.TeamGridObj2);
				_playerCells[i].Listener = ((i < TeamMember) ? listNotify : listNotify2);
				_playerCells[i].Index = ((i < TeamMember) ? i : (i - TeamMember));
				_playerCells[i].SetPlayerContext(_playerContext);
				_playerCells[i].Initialize();
			}
			_notifyGroup.Add(listNotify.Id);
			_notifyGroup.Add(listNotify2.Id);
		}
		else
		{
			IListNotify listNotify3 = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allKillInfo_All);
			for (int j = 0; j < _playerCells.Length; j++)
			{
				_playerCells[j] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
				_playerCells[j].Container = _viewModel.TeamGridObj1;
				_playerCells[j].Listener = listNotify3;
				_playerCells[j].Index = j;
				_playerCells[j].SetPlayerContext(_playerContext);
				_playerCells[j].Initialize();
			}
			_notifyGroup.Add(listNotify3.Id);
		}
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		LerpResultShow();
		if (_rewardChanged)
		{
			ShowReward();
			_rewardChanged = false;
		}
		if (_playerCells != null)
		{
			for (int i = 0; i < _playerCells.Length; i++)
			{
				_playerCells[i].OnPlayback();
			}
		}
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		RaceType = _battleRoomContext.roomData.Data.RaceType;
	}
}

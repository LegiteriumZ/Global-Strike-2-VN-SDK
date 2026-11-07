using System;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.UltimateChallenge;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.UltimateChallenge;

[GameUiTest]
public class ExtremewipeoutscoreinfoModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, IKeyboardResponder
{
	private ExtremewipeoutscoreinfoViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private new TimeComponent _timeComponent;

	private IPlayerScoreCell[] _playerCells;

	private IPlayerScoreCell _redPlayerScoreCell;

	private IPlayerScoreCell _bluePlayerScoreCell;

	private PlayerContext _playerContext;

	private int TeamNum = 2;

	private int TeamMember = 8;

	private Type CellClass;

	private Type SelfCellClass;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new ExtremewipeoutscoreinfoViewModel();
		CellClass = typeof(ExtremewipeoutScoreCellModel);
		SelfCellClass = typeof(SelfExtremewipeoutScoreCellModel);
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
			for (int i = 0; i < _playerCells.Length; i++)
			{
				_playerCells[i].OnPlayback();
			}
			if (_redPlayerScoreCell != null)
			{
				_redPlayerScoreCell.OnPlayback();
			}
			if (_bluePlayerScoreCell != null)
			{
				_bluePlayerScoreCell.OnPlayback();
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		CreateCells();
		CreateCellBySelf();
		SetVisible(value: false);
	}

	private void SetVisible(bool value)
	{
		_viewModel.ShowShow = value;
		_gameRuleContext.individualVisible.IndividualVisible = value;
		_notifyGroup.SetSuspend(!value);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.B)
		{
			SetVisible(!_viewModel.ShowShow);
		}
		return _viewModel.ShowShow;
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

	private void CreateCellBySelf()
	{
		for (int i = 0; i < UiIEventCondition.Get_allKillInfo_Team1().Count; i++)
		{
			if (UiIEventCondition.Get_uiMyPlayer_CID() == UiIEventCondition.Get_allKillInfo_Team1()[i].Id)
			{
				IListNotify listNotify = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allKillInfo_Team1);
				_bluePlayerScoreCell = (IPlayerScoreCell)Activator.CreateInstance(SelfCellClass);
				_bluePlayerScoreCell.Container = _viewModel.BlueExtremewipeoutScoreCellObj;
				_bluePlayerScoreCell.Listener = listNotify;
				_bluePlayerScoreCell.SetPlayerContext(_playerContext);
				_bluePlayerScoreCell.Index = i;
				_bluePlayerScoreCell.Initialize();
				_notifyGroup.Add(listNotify.Id);
			}
		}
		for (int j = 0; j < UiIEventCondition.Get_allKillInfo_Team2().Count; j++)
		{
			if (UiIEventCondition.Get_uiMyPlayer_CID() == UiIEventCondition.Get_allKillInfo_Team2()[j].Id)
			{
				IListNotify listNotify2 = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allKillInfo_Team2);
				_redPlayerScoreCell = (IPlayerScoreCell)Activator.CreateInstance(SelfCellClass);
				_redPlayerScoreCell.Container = _viewModel.RedExtremewipeoutScoreCellObj;
				_redPlayerScoreCell.Listener = listNotify2;
				_redPlayerScoreCell.SetPlayerContext(_playerContext);
				_redPlayerScoreCell.Index = j;
				_redPlayerScoreCell.Initialize();
				_notifyGroup.Add(listNotify2.Id);
			}
		}
	}

	private void CreateCells()
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
}

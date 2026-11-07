using System;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgQuestBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgQuestBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	protected IPlayerScoreCell[] _playerCells;

	protected Type CellClass;

	protected int QusetNum = 2;

	protected IListNotify _listener;

	protected NotifyGroup _notifyGroup = new NotifyGroup();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		_playerContext = Contexts.sharedInstance.player;
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgQuestBoardViewModel();
		CellClass = typeof(AcgQuestGridModel);
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
			IPlayerScoreCell[] playerCells = _playerCells;
			for (int i = 0; i < playerCells.Length; i++)
			{
				playerCells[i].OnPlayback();
			}
		}
	}

	protected override void DoSubscribe()
	{
		CreateCells();
	}

	protected virtual void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[QusetNum];
		_listener = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_AcgQuestList);
		for (int i = 0; i < _playerCells.Length; i++)
		{
			_playerCells[i] = (IPlayerScoreCell)Activator.CreateInstance(CellClass);
			_playerCells[i].Container = _viewModel.GridObj;
			_playerCells[i].Listener = _listener;
			_playerCells[i].Index = i;
			_playerCells[i].SetPlayerContext(_playerContext);
			_playerCells[i].Initialize();
		}
		_notifyGroup.Add(_listener.Id);
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}

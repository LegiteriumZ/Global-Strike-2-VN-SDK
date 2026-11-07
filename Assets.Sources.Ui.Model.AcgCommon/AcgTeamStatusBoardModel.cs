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
public class AcgTeamStatusBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgTeamStatusBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	protected IPlayerScoreCell[] _playerCells;

	protected Type CellClass;

	protected int TeamMemberNum = 2;

	protected IListNotify _listener;

	protected NotifyGroup _notifyGroup = new NotifyGroup();

	protected bool _hasSubscribed;

	private int _cameraTeamId;

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
		if (_playerContext.cameraOwnerEntity != null)
		{
			_cameraTeamId = _playerContext.cameraOwnerEntity.basicInfo.Current.Id;
		}
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgTeamStatusBoardViewModel();
		CellClass = typeof(AcgMemberGridModel);
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips(_timeComponent);
		_hasSubscribed = true;
		IPlayerScoreCell[] playerCells = _playerCells;
		for (int i = 0; i < playerCells.Length; i++)
		{
			if (!playerCells[i].HasSubscribed())
			{
				_hasSubscribed = false;
			}
		}
		_notifyGroup.SetSuspend(!_hasSubscribed);
	}

	protected override void DoSubscribe()
	{
		CreateCells();
	}

	protected virtual void CreateCells()
	{
		_playerCells = new IPlayerScoreCell[TeamMemberNum];
		_listener = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_AcgTeamPlayerEntity, 105);
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
		_notifyGroup.SetSuspend(suspend: true);
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}

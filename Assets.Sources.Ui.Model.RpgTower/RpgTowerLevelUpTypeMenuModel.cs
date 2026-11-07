using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgTower;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.RpgTower;

[GameUiTest]
public class RpgTowerLevelUpTypeMenuModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl, ISetMessageContext
{
	private RpgTowerLevelUpTypeMenuViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

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
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgTowerLevelUpTypeMenuViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		_viewModel.CreateTriggerEntry(_viewModel.CloseTriggers, EventTriggerType.PointerClick, delegate
		{
			Close();
		});
		_viewModel.CreateTriggerEntry(_viewModel.MoveTriggers, EventTriggerType.PointerClick, delegate
		{
			Move();
		});
		_viewModel.CreateTriggerEntry(_viewModel.SaleTriggers, EventTriggerType.PointerClick, delegate
		{
			Sale();
		});
		_viewModel.CreateTriggerEntry(_viewModel.LevelUpHavePersonTriggers, EventTriggerType.PointerClick, delegate
		{
			LevelUp();
		});
		_viewModel.CreateTriggerEntry(_viewModel.LevelUpNoPersonTriggers, EventTriggerType.PointerClick, delegate
		{
			CannotLevelUp();
		});
		NotifyManager.MakeTempNotify(GetShow, SetShow, null, initinvoke: true);
	}

	private bool GetShow()
	{
		return _gameRuleContext.rpgTower.RpgTowerSurfaceType == RpgTowerSurfaceType.LevelUpTypeMain;
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private void Close()
	{
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.None;
	}

	private void Sale()
	{
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpTypeSale;
	}

	private void Move()
	{
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpTypeMove;
	}

	private void CannotLevelUp()
	{
		_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("RPG_TOWER_NO_OPEN"), 2000);
		NotifyManager.ForceInvoke(38);
	}

	private void LevelUp()
	{
		RpgTowerArgsData message = new RpgTowerArgsData
		{
			TowerId = _gameRuleContext.rpgTower.TowerId,
			ActionType = 3
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(116, message);
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.None;
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 32768;
	}

	public int GetForbidButtons()
	{
		return 175;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}

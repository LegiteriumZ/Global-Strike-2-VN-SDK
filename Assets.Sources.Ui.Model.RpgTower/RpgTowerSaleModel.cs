using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgTower;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.Logger;
using SSJJBase.String;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.RpgTower;

[GameUiTest]
public class RpgTowerSaleModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl
{
	private RpgTowerSaleViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

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
		_viewModel = new RpgTowerSaleViewModel();
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
		NotifyManager.MakeTempNotify(GetShow, SetShow, null, initinvoke: true);
		_viewModel.CreateTriggerEntry(_viewModel.CloseTriggers, EventTriggerType.PointerClick, delegate
		{
			Close();
		});
		_viewModel.CreateTriggerEntry(_viewModel.ComfirmTriggers, EventTriggerType.PointerClick, delegate
		{
			Confirm();
		});
		_viewModel.CreateTriggerEntry(_viewModel.CancelTriggers, EventTriggerType.PointerClick, delegate
		{
			Cancel();
		});
	}

	private void Confirm()
	{
		this.Info("Confirm " + _gameRuleContext.rpgTower.TowerId);
		RpgTowerArgsData message = new RpgTowerArgsData
		{
			TowerId = _gameRuleContext.rpgTower.TowerId,
			ActionType = 1
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(116, message);
		Close();
	}

	private void Cancel()
	{
		if (_gameRuleContext.rpgTower.RpgTowerSurfaceType == RpgTowerSurfaceType.LevelUpPropertySale)
		{
			_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpPropertyMain;
		}
		if (_gameRuleContext.rpgTower.RpgTowerSurfaceType == RpgTowerSurfaceType.LevelUpTypeSale)
		{
			_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.LevelUpTypeMain;
		}
	}

	private void Close()
	{
		_gameRuleContext.rpgTower.RpgTowerSurfaceType = RpgTowerSurfaceType.None;
	}

	private bool GetShow()
	{
		if (_gameRuleContext.rpgTower.RpgTowerSurfaceType != RpgTowerSurfaceType.LevelUpPropertySale)
		{
			return _gameRuleContext.rpgTower.RpgTowerSurfaceType == RpgTowerSurfaceType.LevelUpTypeSale;
		}
		return true;
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		_viewModel.DesString = ScriptLocalization.Get("RPG_TOWER_SALE");
		_viewModel.CostString = StringCache.IntToString(_gameRuleContext.rpgTower.SaleCost);
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
}

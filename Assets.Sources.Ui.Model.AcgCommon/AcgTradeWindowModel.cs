using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgTradeWindowModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ICursorControl
{
	private AcgTradeWindowViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private BattleServerContext _battleServerContext;

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
		_battleServerContext = Contexts.sharedInstance.battleServer;
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgTradeWindowViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow = false;
		base.DoSubscribe();
		NotifyManager.MakeNotify(108, GetWindowShow, SetWindowShow);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_AcgCoin, SetAcgCoin, null, initinvoke: true);
		_viewModel.CreateTriggerEntry(_viewModel.CloseAreaTriggers, EventTriggerType.PointerClick, delegate
		{
			InitPanelRequest message4 = new InitPanelRequest();
			_battleServerContext.battleServer.Server.SendTcpMessage(133, message4);
			_viewModel.ShowShow = false;
		});
		_viewModel.CreateTriggerEntry(_viewModel.HealTriggers, EventTriggerType.PointerClick, delegate
		{
			if (_gameRuleContext.acgPowerUp.ShowHeal || Input.GetMouseButtonDown(1))
			{
				BuyBloodRequest message3 = new BuyBloodRequest();
				_battleServerContext.battleServer.Server.SendTcpMessage(132, message3);
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PowerUpTriggers, EventTriggerType.PointerClick, delegate
		{
			if (_gameRuleContext.acgPowerUp.ShowPowerUp || Input.GetMouseButtonDown(1))
			{
				BuySkillRequest message2 = new BuySkillRequest();
				_battleServerContext.battleServer.Server.SendTcpMessage(130, message2);
				_viewModel.ShowShow = false;
			}
		});
		_viewModel.CloseButtonButton.onClick.AddListener(delegate
		{
			InitPanelRequest message = new InitPanelRequest();
			_battleServerContext.battleServer.Server.SendTcpMessage(133, message);
			_viewModel.ShowShow = false;
		});
	}

	private bool GetWindowShow()
	{
		return _gameRuleContext.acgPowerUp.CanShow;
	}

	private void SetWindowShow(bool oldBool, bool newBool)
	{
		_viewModel.ShowShow = newBool;
		_viewModel.HealDisabledShow = !_gameRuleContext.acgPowerUp.ShowHeal;
		_viewModel.PowerUpDisabledShow = !_gameRuleContext.acgPowerUp.ShowPowerUp;
		_viewModel.HealPriceString = _gameRuleContext.acgPowerUp.HealPrice.ToString();
		_viewModel.PowerUpPriceString = _gameRuleContext.acgPowerUp.PowerUpPrice.ToString();
	}

	private void SetAcgCoin(int oldInt, int newInt)
	{
		_viewModel.CoinNumberString = newInt.ToString();
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow && CloseDelay <= 0)
		{
			return 0;
		}
		return 1;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}

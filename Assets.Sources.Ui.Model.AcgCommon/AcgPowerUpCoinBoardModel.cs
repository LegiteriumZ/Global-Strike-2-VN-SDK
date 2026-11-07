using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Sources.Utils.Timer;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgPowerUpCoinBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgPowerUpCoinBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private TimeContext _timeContext;

	private ISSJJTimer _timer;

	private Vector2 _scale = new Vector2(1.3f, 1.3f);

	private Color _color = new Color(0.9f, 0.65f, 0.9f);

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
		_timeContext = Contexts.sharedInstance.time;
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgPowerUpCoinBoardViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
			if (_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_GET_COIN", out _timer))
			{
				_viewModel.CoinNumberScale = Vector2.Lerp(Vector2.one, _scale, _timer.GetPassedTime());
				_viewModel.CoinNumberTextcolor = Color.Lerp(Color.white, _color, _timer.GetPassedTime());
			}
			else
			{
				_viewModel.CoinNumberScale = Vector2.one;
				_viewModel.CoinNumberTextcolor = Color.white;
			}
		}
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_AcgCoin, SetAcgCoin, null, initinvoke: true);
	}

	private void SetAcgCoin(int oldInt, int newInt)
	{
		_viewModel.CoinNumberString = newInt.ToString();
		SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "ACG_GET_COIN", new SSJJTimer(500));
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}

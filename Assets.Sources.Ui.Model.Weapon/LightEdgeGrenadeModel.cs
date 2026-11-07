using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class LightEdgeGrenadeModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private LightEdgeGrenadeViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

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
	}

	public override void CreateViewModel()
	{
		_viewModel = new LightEdgeGrenadeViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CurrentWeapon_RpgMaxPower, SetRpgMaxPower, null, initinvoke: true);
	}

	private void SetRpgMaxPower(int arg1, int arg2)
	{
		_viewModel.ShowShow = ((arg2 != 0) ? true : false);
		_viewModel.NumString = arg2.ToString();
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

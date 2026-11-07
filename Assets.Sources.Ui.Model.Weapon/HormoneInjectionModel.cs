using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class HormoneInjectionModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private HormoneInjectionViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

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
	}

	public override void CreateViewModel()
	{
		_viewModel = new HormoneInjectionViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null)
		{
			_ = _viewModel.IsInited;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		_viewModel.NumberString = "0";
		NotifyManager.MakeTempNotify(GetVisiable, SetVisiable, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPower, SetPower, null, initinvoke: true);
	}

	private int GetPower()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0;
		}
		return currentWeaponEntity.power.Power;
	}

	private void SetPower(int arg1, int arg2)
	{
		_viewModel.NumberString = StringCache.IntToString(arg2);
	}

	private bool GetVisiable()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasSpecial)
		{
			return false;
		}
		return currentWeaponEntity.special.SpecialMode;
	}

	private void SetVisiable(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}

using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class TwinsIinfinitySkillModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, ISetPlayerContext
{
	private TwinsIinfinitySkillViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
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
		_viewModel = new TwinsIinfinitySkillViewModel();
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
		NotifyManager.MakeTempNotify(GetDunProgress, SetDunProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetCanUse, SetCanUse, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetProgress, SetProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetVisable, SetVisable, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunVisable, SetDunVisable, null, initinvoke: true);
	}

	private void SetDunVisable(bool arg1, bool arg2)
	{
		_viewModel.dunShow = arg2;
	}

	private bool GetDunVisable()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo && (currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity1" || currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity2") && RuleUtilty.IsGeneralPve(UiIEventCondition.Get_uiRoomData_RaceType()))
		{
			return true;
		}
		return false;
	}

	private void SetVisable(bool arg1, bool arg2)
	{
		_viewModel.RightBottomShow = arg2;
	}

	private bool GetVisable()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && ((currentWeaponEntity.hasBasicInfo && currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity1") || currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity2") && (RuleUtilty.IsPve(UiIEventCondition.Get_uiRoomData_RaceType()) || RuleUtilty.IsBioMode(UiIEventCondition.Get_uiRoomData_RaceType())))
		{
			return true;
		}
		return false;
	}

	private void SetCanUse(bool arg1, bool arg2)
	{
		_viewModel.SkillbgShow = arg2;
	}

	private bool GetCanUse()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && ((currentWeaponEntity.hasBasicInfo && currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity1") || currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity2") && currentWeaponEntity.basicInfo.Data.MaxPower2 == 1)
		{
			return true;
		}
		return false;
	}

	private void SetDunProgress(float arg1, float arg2)
	{
		_viewModel.DunProgressFillamount = arg2;
	}

	private float GetDunProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		if (currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity1" || currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity2")
		{
			return (float)currentWeaponEntity.power.MaxPower / 100f;
		}
		return 0f;
	}

	private void SetProgress(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount = arg2;
	}

	private float GetProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		if (currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity1" || currentWeaponEntity.basicInfo.Data.WeaponName == "twins_infinity2")
		{
			return (float)currentWeaponEntity.power.Power / 100f;
		}
		return 0f;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

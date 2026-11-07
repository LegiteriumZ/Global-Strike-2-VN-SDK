using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class CrystalBowSkillModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetWeaponContext
{
	private CrystalBowSkillViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
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

	private float GetProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return 0f;
		}
		if (currentWeaponEntity.basicInfo.Info.Name == "end_bow" && currentWeaponEntity.hasPower)
		{
			return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
		}
		if (currentWeaponEntity.clip.Clip2 < 0 || currentWeaponEntity.clip.CarryClip2 <= 0)
		{
			return 0f;
		}
		return (float)currentWeaponEntity.clip.Clip2 / (float)currentWeaponEntity.clip.CarryClip2;
	}

	public override void CreateViewModel()
	{
		_viewModel = new CrystalBowSkillViewModel();
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
		_viewModel.RightBottomShow = false;
		NotifyManager.MakeTempNotify(GetProgress, SetProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetWeaponSpecialMode, SetWeaponSpecialMode, null, initinvoke: true);
	}

	private bool GetWeaponSpecialMode()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return false;
		}
		if (currentWeaponEntity.basicInfo.Info.Name == "end_bow")
		{
			if ((currentWeaponEntity.special.EffectLevel & 4) > 0 && (currentWeaponEntity.special.EffectLevel & 0x40) > 0 && currentWeaponEntity.hasPower)
			{
				return currentWeaponEntity.power.Power > 0;
			}
			return false;
		}
		if (currentWeaponEntity.clip.Clip2 < 0 || currentWeaponEntity.clip.CarryClip2 <= 0)
		{
			return false;
		}
		return (float)currentWeaponEntity.clip.Clip2 / (float)currentWeaponEntity.clip.CarryClip2 > 0f;
	}

	private void SetWeaponSpecialMode(bool arg1, bool arg2)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && (RuleUtilty.IsBigHeadModel(UiIEventCondition.Get_uiRoomData_RaceType()) || RuleUtilty.IsPve(UiIEventCondition.Get_uiRoomData_RaceType()) || RuleUtilty.IsBioMode(UiIEventCondition.Get_uiRoomData_RaceType())))
		{
			if ((currentWeaponEntity.basicInfo.Data.EffectLevel & 1) > 0 && arg2)
			{
				_viewModel.RightBottomShow = true;
			}
			else if (UiIEventCondition.Get_uiCross_SpecialMode() && arg2)
			{
				_viewModel.RightBottomShow = true;
			}
			else
			{
				_viewModel.RightBottomShow = arg2;
			}
		}
	}

	private void SetProgress(float arg1, float arg2)
	{
		_viewModel.DunProgressFillamount = arg2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

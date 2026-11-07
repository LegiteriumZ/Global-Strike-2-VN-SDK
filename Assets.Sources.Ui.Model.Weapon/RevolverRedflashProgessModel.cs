using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class RevolverRedflashProgessModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private BowprogressViewModel _viewModel;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new BowprogressViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ProgressBackPosition = Vector3.zero;
		_viewModel.ProgressPosition = Vector3.zero;
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true);
	}

	private void SetPercent(float arg1, float percent)
	{
		if (!(percent > 0f) || !(percent < _viewModel.ProgressFillamount))
		{
			_viewModel.ProgressFillamount = percent;
			_viewModel.ShowShow = percent > 0f;
		}
	}

	private float GetPercent()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return 0f;
		}
		switch (currentWeaponEntity.basicInfo.Data.WeaponName)
		{
		case "infinite_hand1_change_1":
		case "infinite_hand2_change_1":
		case "infinite_hand3_change_1":
		{
			float num2 = ((currentWeaponEntity.hasAttack && currentWeaponEntity.hasPower) ? ((currentWeaponEntity.attack.NextSecondaryAttackTimer - 500f) / (float)(currentWeaponEntity.power.MaxPower2 - 500)) : 0f);
			if (!(num2 >= 1f))
			{
				return num2 * 0.75f;
			}
			return 1f;
		}
		default:
			if (currentWeaponEntity.hasPower)
			{
				float num = ((currentWeaponEntity.power.MaxPower2 < 500) ? 0f : ((currentWeaponEntity.power.MaxPower2 > currentWeaponEntity.power.RpgMaxPower + 500) ? 1f : ((float)(currentWeaponEntity.power.MaxPower2 - 500) / (float)currentWeaponEntity.power.RpgMaxPower)));
				if (!(num >= 1f))
				{
					return num * 0.75f;
				}
				return 1f;
			}
			return 0f;
		}
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_viewModel.ProgressSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "crossprogress"), delegate(Sprite sprite)
			{
				_viewModel.ProgressSprite = sprite;
				_viewModel.ProgressNtvsize();
			});
			_viewModel.ProgressBackSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "crossprogressback"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBackSprite = sprite;
				_viewModel.ProgressBackNtvsize();
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

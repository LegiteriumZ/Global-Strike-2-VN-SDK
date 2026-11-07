using System;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class JusticeFromAboveCrossModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private JusticeFromAboveCrossViewModel _viewModel;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new JusticeFromAboveCrossViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.CenterShow)
		{
			WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
			if (currentWeaponEntity.hasPower)
			{
				_viewModel.LocalTimeString = Math.Floor((float)currentWeaponEntity.power.Power2 / 1000f).ToString();
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_SpecialMode, SetSpecialMode, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPower2, SetPower2, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetMaxPower2, SetMaxPower2, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_WeaponLevel, SetWeaponLevel, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetProgress, SetProgress, null, initinvoke: true);
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "main"), delegate(Sprite sprite)
			{
				_viewModel.BackSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "progress_bg"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBackSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "progress_active"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBarSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "progress_unactive"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBackUnactiveSprite = sprite;
			});
		}
	}

	private void SetProgress(float arg1, float arg2)
	{
		_viewModel.ProgressBarObj.GetComponent<CircleProgressImage>().fillAmount = arg2;
	}

	private float GetProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			if (currentWeaponEntity.power.MaxPower <= 0)
			{
				return 0f;
			}
			return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
		}
		return 0f;
	}

	private void SetWeaponLevel(int arg1, int arg2)
	{
		_viewModel.BulletNumString = arg2.ToString();
	}

	private void SetMaxPower2(int arg1, int arg2)
	{
		_viewModel.GlobalTimeString = Math.Floor((float)arg2 / 1000f).ToString();
	}

	private int GetMaxPower2()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			return currentWeaponEntity.power.MaxPower2;
		}
		return 0;
	}

	private void SetPower2(int arg1, int arg2)
	{
		_viewModel.LocalTimeString = Math.Floor((float)arg2 / 1000f).ToString();
	}

	private int GetPower2()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			return currentWeaponEntity.power.Power2;
		}
		return 0;
	}

	private void SetSpecialMode(bool arg1, bool arg2)
	{
		_viewModel.CenterShow = arg2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}

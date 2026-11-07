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
public class AwmStrikeCrossModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private AwmStrikeCrossViewModel _viewModel;

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
		_viewModel = new AwmStrikeCrossViewModel();
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
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetSpecialImage, SetSpecialImage, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetSpecialVisible, SetSpecialVisible, null, initinvoke: true);
	}

	private void SetSpecialVisible(bool arg1, bool arg2)
	{
		_viewModel.SpecialShow = arg2;
	}

	private bool GetSpecialVisible()
	{
		return UiIEventCondition.Get_uiCross_WeaponLevel() > 0;
	}

	private void SetSpecialImage(int arg1, int arg2)
	{
		if (arg2 != 0)
		{
			string weaponName = _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName;
			string arg3 = ((arg2 == 2) ? "cross2p" : "cross2");
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, $"{weaponName}_{arg3}"), delegate(Sprite sprite)
			{
				_viewModel.SpecialSprite = sprite;
			});
			arg3 = ((arg2 == 2) ? "cross1" : "cross0");
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, $"{weaponName}_{arg3}"), delegate(Sprite sprite)
			{
				_viewModel.AwpSprite = sprite;
			});
		}
	}

	private int GetSpecialImage()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return 0;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity.hasPower && currentWeaponEntity.power.Power2 == 1)
		{
			return 2;
		}
		return 1;
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private bool GetVisible()
	{
		if (!UiIEventCondition.Get_uiCross_HideCross())
		{
			return UiIEventCondition.Get_uiCross_AwpVisible();
		}
		return false;
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

using Assets.Generated.Table;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class G36CCrossModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private G36CCrossViewModel _viewModel;

	private WeaponCrossTable.Row _crossConfig;

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
		_viewModel = new G36CCrossViewModel();
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
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiCross_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_AwpVisible, SetAwpVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_HideCross, SetHideCross, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetCenterVisible, SetCenterVisible, null, initinvoke: true);
	}

	private void SetCenterVisible(bool arg1, bool arg2)
	{
		_viewModel.SpecialCenterShow = !arg2;
	}

	private bool GetCenterVisible()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return false;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		switch (currentWeaponEntity.basicInfo.Data.WeaponName)
		{
		case "qbz95_1st":
		case "qbz95_1st1":
		case "qbz95_1st2":
			return false;
		default:
			return currentWeaponEntity.basicInfo.Data.EffectLevel > 0;
		}
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		_crossConfig = (string.IsNullOrEmpty(weaponName) ? null : WeaponCrossLoader.Instance.Table.Find_Name(weaponName));
		if (_crossConfig != null)
		{
			_viewModel.SpecialSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, weaponName + "_cross"), delegate(Sprite sprite)
			{
				_viewModel.SpecialSprite = sprite;
				_viewModel.SpecialNtvsize();
			});
			_viewModel.SpecialCenterSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "cross2"), delegate(Sprite sprite)
			{
				_viewModel.SpecialCenterSprite = sprite;
				_viewModel.SpecialCenterScale = Vector3.one * 0.5f;
				_viewModel.SpecialCenterNtvsize();
			});
		}
	}

	private void SetAwpVisible(bool ov, bool awpVisible)
	{
		_viewModel.SpecialEnabled = awpVisible;
	}

	private void SetHideCross(bool ov, bool value)
	{
		_viewModel.ShowShow = !value;
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

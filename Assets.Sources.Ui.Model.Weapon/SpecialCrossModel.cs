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

public class SpecialCrossModel : AbstractModel, IPlaybackSystem
{
	private SpecialCrossViewModel _viewModel;

	private WeaponCrossTable.Row _crossConfig;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new SpecialCrossViewModel();
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
	}

	private void SetHideCross(bool ov, bool value)
	{
		CheckVisible();
	}

	private void SetAwpVisible(bool ov, bool awpVisible)
	{
		CheckVisible();
	}

	private void CheckVisible()
	{
		if (UiIEventCondition.Get_uiCross_HideCross())
		{
			_viewModel.ShowShow = false;
		}
		else
		{
			_viewModel.ShowShow = UiIEventCondition.Get_uiCross_AwpVisible();
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
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

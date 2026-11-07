using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class M96ProgressModel : AbstractModel, IPlaybackSystem
{
	private M96ProgressViewModel _viewModel;

	private int _capacityTime;

	private int _currLevel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new M96ProgressViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.ShowShow)
		{
			return;
		}
		string uiCross_WeaponName = UiIEventCondition.Get_uiCross_WeaponName();
		_capacityTime += _timeComponent.FrameInterval;
		int num = (_capacityTime - 300) / 1000;
		num = ((num > 3) ? 3 : num);
		if (num > 0)
		{
			_viewModel.CapacityBarHere = true;
			if (_currLevel != num)
			{
				_currLevel = num;
				_viewModel.CapacityBarSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(uiCross_WeaponName), UiAssetBundleUtils.GetWeaponTexturePath(uiCross_WeaponName, "storagecapacity" + num), delegate(Sprite sprite)
				{
					_viewModel.CapacityBarSprite = sprite;
					_viewModel.CapacityBarNtvsize();
				});
			}
		}
		else
		{
			_viewModel.CapacityBarHere = false;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiCross_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_HideCross, SetHideCross, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_AwpVisible, SetAwpVisible, null, initinvoke: true);
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		_viewModel.CapacityBackSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "storagecapacityback"), delegate(Sprite sprite)
		{
			_viewModel.CapacityBackSprite = sprite;
			_viewModel.CapacityBackNtvsize();
		});
	}

	private void SetAwpVisible(bool ov, bool value)
	{
		CheckVisible();
	}

	private void SetHideCross(bool ov, bool value)
	{
		CheckVisible();
	}

	private void CheckVisible()
	{
		_capacityTime = 0;
		if (UiIEventCondition.Get_uiCross_HideCross())
		{
			_viewModel.ShowShow = false;
		}
		else
		{
			_viewModel.ShowShow = UiIEventCondition.Get_uiCross_AwpVisible();
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

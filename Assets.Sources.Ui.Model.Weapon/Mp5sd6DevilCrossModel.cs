using System.Collections.Generic;
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

public class Mp5sd6DevilCrossModel : AbstractModel, IPlaybackSystem
{
	private Mp5sd6DevilCrossViewModel _viewModel;

	private WeaponCrossTable.Row _crossConfig;

	private List<int> _fovs = new List<int>();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Mp5sd6DevilCrossViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_Fov, SetFov, null, initinvoke: true);
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		if (string.IsNullOrEmpty(weaponName))
		{
			_viewModel.ShowShow = false;
			return;
		}
		_crossConfig = WeaponCrossLoader.Instance.Table.Find_Name(weaponName);
		if (_crossConfig == null || string.IsNullOrEmpty(_crossConfig.Fov1))
		{
			_viewModel.ShowShow = false;
			return;
		}
		CheckVisible();
		_fovs.Clear();
		_viewModel.SpecialSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, _crossConfig.Fov1), delegate(Sprite sprite)
		{
			_viewModel.SpecialSprite = sprite;
			_viewModel.SpecialScale = Vector3.one * 0.35f;
			_viewModel.SpecialNtvsize();
		});
		_viewModel.AwpSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, _crossConfig.Fov2), delegate(Sprite sprite)
		{
			_viewModel.AwpSprite = sprite;
			SetImagePosition();
		});
	}

	private void SetFov(int ov, int fov)
	{
		if (fov <= 0 || fov >= 90)
		{
			return;
		}
		AddFov(fov);
		if (_crossConfig != null)
		{
			if (!string.IsNullOrEmpty(_crossConfig.Fov1) && _fovs.Count > 0 && fov == _fovs[0])
			{
				_viewModel.SpecialShow = true;
				_viewModel.AwpShow = false;
			}
			else if (!string.IsNullOrEmpty(_crossConfig.Fov2) && _fovs.Count > 1 && fov == _fovs[1])
			{
				_viewModel.SpecialShow = false;
				_viewModel.AwpShow = true;
			}
		}
	}

	private void AddFov(int fov)
	{
		if (!_fovs.Contains(fov))
		{
			int i;
			for (i = 0; i < _fovs.Count && _fovs[i] >= fov; i++)
			{
			}
			_fovs.Insert(i, fov);
		}
	}

	private void SetImagePosition()
	{
		Rect rect = _viewModel.AwpObj.GetComponent<RectTransform>().rect;
		_viewModel.ImageLeftPosition = new Vector3((0f - rect.height) / 540f * 960f / 2f, 0f);
		_viewModel.ImageRightPosition = new Vector3(rect.height / 540f * 960f / 2f, 0f);
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

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

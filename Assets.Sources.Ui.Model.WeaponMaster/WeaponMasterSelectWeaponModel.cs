using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.WeaponMaster;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.WeaponMaster;

public class WeaponMasterSelectWeaponModel : AbstractModel, IPlaybackSystem, IKeyboardResponder
{
	private WeaponMasterSelectWeaponViewModel _viewModel;

	private ActiveChip _bottomActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new WeaponMasterSelectWeaponViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.BottomShow)
			{
				_viewModel.TimeTextString = string.Concat(_bottomActiveChip.Time / 1000);
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_selectWeapon_WeaponNameList, SetWeaponNameList, null, initinvoke: true);
	}

	private void SetWeaponNameList(List<string> olist, List<string> list)
	{
		if (list.Count == 0)
		{
			return;
		}
		_bottomActiveChip.Time = 5000;
		for (int j = 0; j < 5; j++)
		{
			if (j < list.Count && !string.IsNullOrEmpty(list[j]))
			{
				_viewModel.SetWeaponShow(j + 1, value: true);
				int i1 = j;
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(list[j]), UiAssetBundleUtils.GetWeaponFullPath() + list[j] + "/ui/" + list[j] + "-2.png", delegate(Sprite sprite)
				{
					_viewModel.SetImageSprite(i1 + 1, sprite);
				});
			}
			else
			{
				_viewModel.SetWeaponShow(j + 1, value: false);
			}
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (_viewModel.BottomShow)
		{
			List<string> selectWeapon_WeaponNameList = UiIEventCondition.Get_selectWeapon_WeaponNameList();
			int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
			if (alphaOrKeypadDiff < 1 || alphaOrKeypadDiff > 5)
			{
				return false;
			}
			if (selectWeapon_WeaponNameList.Count <= alphaOrKeypadDiff - 1 || string.IsNullOrEmpty(selectWeapon_WeaponNameList[0]))
			{
				return false;
			}
			_bottomActiveChip.Time = 0;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	private void InitChips()
	{
		_bottomActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.BottomShow = _bottomActiveChip.Update(_timeComponent);
	}
}

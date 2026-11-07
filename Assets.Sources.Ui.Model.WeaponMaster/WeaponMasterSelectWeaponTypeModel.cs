using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.WeaponMaster;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.WeaponMaster;

public class WeaponMasterSelectWeaponTypeModel : AbstractModel, IPlaybackSystem, IKeyboardResponder
{
	private WeaponMasterSelectWeaponTypeViewModel _viewModel;

	private string[] _typeImage = new string[5] { "Secondary", "SubmachineGun", "Shotgun", "Rifle", "SniperRifle" };

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
		_viewModel = new WeaponMasterSelectWeaponTypeViewModel();
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
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_selectWeaponType_WeaponTypeList, SetWeaponTypeList, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_selectWeapon_WeaponNameList, SetWeaponNameList, null, initinvoke: true);
	}

	private void SetWeaponNameList(List<string> olist, List<string> list)
	{
		if (list.Count > 0 && _bottomActiveChip.Time > 0)
		{
			_bottomActiveChip.Time = 0;
		}
	}

	private void SetWeaponTypeList(List<bool> olist, List<bool> list)
	{
		if (list.Count == 0)
		{
			return;
		}
		_bottomActiveChip.Time = 10000;
		for (int j = 0; j < 5; j++)
		{
			int num = ((j < list.Count && list[j]) ? 1 : 2);
			int i1 = j;
			base.Loader.RetriveSprite("ui/weaponmastermodel", $"Assets/Res/Assets/ui/GameGUIRes/weaponMasterModel/weaponTypeSelect/{_typeImage[j]}{num}.png", delegate(Sprite sprite)
			{
				_viewModel.SetTypeSprite(i1 + 1, sprite);
			});
		}
	}

	private void InitChips()
	{
		_bottomActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.BottomShow = _bottomActiveChip.Update(_timeComponent);
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (_viewModel.BottomShow)
		{
			List<bool> selectWeaponType_WeaponTypeList = UiIEventCondition.Get_selectWeaponType_WeaponTypeList();
			int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
			if (alphaOrKeypadDiff < 1 || alphaOrKeypadDiff > 5)
			{
				return false;
			}
			if (selectWeaponType_WeaponTypeList.Count <= alphaOrKeypadDiff - 1 || !selectWeaponType_WeaponTypeList[alphaOrKeypadDiff - 1])
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
}

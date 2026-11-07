using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GroupGunKing;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.GroupGunKing;

public class GroupGunKingWeaponSelectModel : AbstractModel, IPlaybackSystem, IKeyboardResponder
{
	private GroupGunKingWeaponSelectViewModel _viewModel;

	private ActiveChip _panelActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GroupGunKingWeaponSelectViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.PanelShow)
			{
				_viewModel.TimeString = string.Concat(_panelActiveChip.Time / 1000);
			}
		}
	}

	protected override void DoSubscribe()
	{
		for (int j = 0; j < 5; j++)
		{
			int i1 = j + 1;
			base.Loader.RetriveSprite("ui/groupgunkingmodel", $"Assets/Res/Assets/ui/GameGUIRes/groupGunkingModel/weaponSelect/weaponback{i1}.png", delegate(Sprite sprite)
			{
				_viewModel.SetWeaponItemSprite(i1, sprite);
			});
		}
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_selectWeapon_WeaponNameList, SetWeaponNameList, null, initinvoke: true);
	}

	private void SetWeaponNameList(List<string> ov, List<string> list)
	{
		if (list.Count == 0)
		{
			return;
		}
		List<string> selectWeapon_SecondWeaponNameList = UiIEventCondition.Get_selectWeapon_SecondWeaponNameList();
		_panelActiveChip.Time = 5000;
		for (int j = 0; j < 5; j++)
		{
			if (j < list.Count && !string.IsNullOrEmpty(list[j]))
			{
				_viewModel.SetWeaponItemShow(j + 1, value: true);
				int i1 = j;
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(list[j]), UiAssetBundleUtils.GetWeaponFullPath() + list[j] + "/ui/" + list[j] + "-2.png", delegate(Sprite sprite)
				{
					_viewModel.SetWeaponSprite(i1 + 1, sprite);
				});
				if (selectWeapon_SecondWeaponNameList != null && selectWeapon_SecondWeaponNameList.Count > 0)
				{
					_viewModel.SetSecondWeaponItemShow(j + 1, value: true);
					_viewModel.SetWeaponPosition(j + 1, new Vector3(-20f, -9f));
					_viewModel.SetSecondWeaponPosition(j + 1, new Vector3(60f, -9f));
					if (j < selectWeapon_SecondWeaponNameList.Count && !string.IsNullOrEmpty(selectWeapon_SecondWeaponNameList[j]))
					{
						base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(list[j]), UiAssetBundleUtils.GetWeaponFullPath() + list[j] + "/ui/" + list[j] + "-2.png", delegate(Sprite sprite)
						{
							_viewModel.SetSecondWeaponSprite(i1 + 1, sprite);
						});
					}
					else
					{
						_viewModel.SetSecondWeaponSprite(j + 1, UiResourcesLoader.DefaultSprite);
					}
				}
				else
				{
					_viewModel.SetSecondWeaponItemShow(j + 1, value: false);
					_viewModel.SetWeaponPosition(j + 1, new Vector3(0f, -9f));
				}
			}
			else
			{
				_viewModel.SetWeaponItemShow(j + 1, value: false);
			}
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (_viewModel.PanelShow)
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
			_panelActiveChip.Time = 0;
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
		_panelActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.PanelShow = _panelActiveChip.Update(_timeComponent);
	}
}

using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.String;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Ui.Model.Common;

public class WeaponStateModel : AbstractModel, IPlaybackSystem
{
	protected WeaponstateViewModel _viewModel;

	private AssetInfo[] _grenadeAssets = new AssetInfo[4];

	private AssetInfo _currWeaponAsset;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		_viewModel = new WeaponstateViewModel();
		if (Contexts.sharedInstance.gameRule.currentRule.Rule.IsRpg())
		{
			_viewModel.ResourceBundleName = "uiprefabs/pvecommon";
			_viewModel.ResourceAssetName = "PveWeaponState";
		}
		else if (RuleUtilty.IsBioUnion(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			_viewModel.ResourceBundleName = "uiprefabs/biounionbase";
			_viewModel.ResourceAssetName = "BioUnionBase_weaponstate";
		}
	}

	public void OnPlayback()
	{
		_ = _viewModel.IsInited;
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(GetIsHumanity, SetIsHumanity, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_SkinName, SetSkinName, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetCnWeaponName, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_ClipCount, SetClipCount, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_CurrentClip1, SetCurrentClip1, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_CarryClip1, SetCarryClip1, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_CurrentClip2, SetCurrentClip2, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_CarryClip2, SetCarryClip2, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_GrenadeName1, SetGrenadeName1, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_GrenadeName2, SetGrenadeName2, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_GrenadeName3, SetGrenadeName3, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_GrenadeNum1, SetGrenadeNum1, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_GrenadeNum2, SetGrenadeNum2, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_GrenadeNum3, SetGrenadeNum3, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_ClipCountFont, SetClipCountFont, null, initinvoke: true, isFrameSeparation: true);
	}

	private bool GetIsHumanity()
	{
		PlayerEntity cameraOwnerEntity = Contexts.sharedInstance.player.cameraOwnerEntity;
		if (cameraOwnerEntity == null)
		{
			return false;
		}
		string career = cameraOwnerEntity.basicInfo.Current.Career;
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		if (PlayerCareerConstantUtility.IsHumanity(career))
		{
			return !PlayerCareerUtil.IsMech2(career);
		}
		return false;
	}

	private void SetGrenadeNum1(int arg1, int arg2)
	{
		UpdateGenadeNum(1, arg2);
	}

	private void SetGrenadeNum2(int arg1, int arg2)
	{
		UpdateGenadeNum(2, arg2);
	}

	private void SetGrenadeNum3(int arg1, int arg2)
	{
		UpdateGenadeNum(3, arg2);
	}

	private void SetGrenadeName3(string arg1, string arg2)
	{
		UpdateGenadeName(3, arg2, UiIEventCondition.Get_weaponState_GrenadeSkin3());
	}

	private void SetGrenadeName2(string arg1, string arg2)
	{
		UpdateGenadeName(2, arg2, UiIEventCondition.Get_weaponState_GrenadeSkin2());
	}

	private void SetGrenadeName1(string arg1, string arg2)
	{
		UpdateGenadeName(1, arg2, UiIEventCondition.Get_weaponState_GrenadeSkin1());
	}

	private void SetCarryClip2(int arg1, int arg2)
	{
		_viewModel.CarryClipString2 = StringCache.IntToString(arg2);
		_viewModel.SlashImageShow2 = ShowCarryClip();
	}

	private void SetCurrentClip2(int arg1, int arg2)
	{
		_viewModel.CurrentClipString2 = StringCache.IntToString(arg2);
	}

	private bool ShowCarryClip()
	{
		WeaponEntity currentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return false;
		}
		int weaponType = currentWeaponEntity.basicInfo.Info.WeaponType;
		if (weaponType == 3 || weaponType == 14)
		{
			return false;
		}
		if (currentWeaponEntity.basicInfo.Data.WeaponName == "dawn_light_shotgun2" && RuleUtilty.IsPveModel(UiIEventCondition.Get_uiRoomData_RaceType()))
		{
			return false;
		}
		switch (currentWeaponEntity.basicInfo.Data.WeaponName)
		{
		case "g11_dg":
		case "glock_auto":
		case "glock_auto1":
		case "glock_auto2":
		case "trick_glass_darts":
			return false;
		default:
			if (currentWeaponEntity.basicInfo.Data.MaxCarryClip == 0)
			{
				return false;
			}
			return true;
		}
	}

	private void SetCarryClip1(int arg1, int arg2)
	{
		_viewModel.CarryClipString1 = StringCache.IntToString(arg2);
		_viewModel.SlashImageShow1 = ShowCarryClip();
	}

	private void SetCurrentClip1(int arg1, int arg2)
	{
		WeaponEntity currentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			_viewModel.CurrentClipString1 = ((currentWeaponEntity.basicInfo.Data.WeaponName.Contains("dawn_light_shotgun") && !ShowCarryClip()) ? "" : StringCache.IntToString(arg2));
		}
	}

	private void SetCnWeaponName(string arg1, string arg2)
	{
		_viewModel.WeaponNameString = LanguageUtils.GetWeaponCnName(arg2);
	}

	private void SetSkinName(string arg1, string arg2)
	{
		UpdatePrimaryWeapon(UiIEventCondition.Get_weaponState_WeaponName(), arg2);
	}

	private void SetWeaponName(string arg1, string arg2)
	{
		UpdatePrimaryWeapon(arg2, UiIEventCondition.Get_weaponState_SkinName());
	}

	private void SetIsHumanity(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private void SetClipCountFont(string ov, string font)
	{
		if (!string.IsNullOrEmpty(font))
		{
			base.Loader.Load("number", "Assets/Res/Assets/number/" + font + ".fontsettings", delegate(Object v)
			{
				WeaponstateViewModel viewModel = _viewModel;
				WeaponstateViewModel viewModel2 = _viewModel;
				WeaponstateViewModel viewModel3 = _viewModel;
				Font font3 = (_viewModel.CurrentClipTextfont2 = (Font)v);
				Font font5 = (viewModel3.CurrentClipTextfont1 = font3);
				Font carryClipTextfont = (viewModel2.CarryClipTextfont2 = font5);
				viewModel.CarryClipTextfont1 = carryClipTextfont;
			});
		}
	}

	private void UpdateGenadeNum(int index, int num)
	{
		_viewModel.SetGrenadeClipString(index, StringCache.IntToString(num));
	}

	private void UpdateGenadeName(int index, string grenadeName, string skinName)
	{
		if (string.IsNullOrEmpty(grenadeName))
		{
			_viewModel.SetGrenadeClipShow(index, value: false);
			_viewModel.SetGrenadeShow(index, value: false);
			return;
		}
		_viewModel.SetGrenadeClipShow(index, value: true);
		_viewModel.SetGrenadeShow(index, value: true);
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(grenadeName);
		if (weaponInfo == null)
		{
			return;
		}
		_viewModel.SetGrenadeShow(index, value: true);
		AssetInfo asset = weaponInfo.GetWeaponIconAssetInfo(skinName);
		if (!(_grenadeAssets[index] != asset))
		{
			return;
		}
		_grenadeAssets[index] = asset;
		_viewModel.SetGrenadeSprite(index, this.GetLoader().RetriveSprite(asset, delegate(Sprite v)
		{
			if (_grenadeAssets[index] == asset)
			{
				_viewModel.SetGrenadeSprite(index, v);
			}
		}));
	}

	private void UpdatePrimaryWeapon(string weaponName, string skinName)
	{
		if (string.IsNullOrEmpty(weaponName))
		{
			return;
		}
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weaponName);
		if (weaponInfo != null)
		{
			AssetInfo asset = (_currWeaponAsset = weaponInfo.GetWeaponIcon_2AssetInfo(skinName));
			_viewModel.WeaponSprite = this.GetLoader().RetriveSprite(_currWeaponAsset, delegate(Sprite v)
			{
				if (asset == _currWeaponAsset)
				{
					_viewModel.WeaponSprite = v;
					_viewModel.WeaponNtvsize();
				}
			});
		}
		_viewModel.SlashImageShow1 = ShowCarryClip();
		_viewModel.SlashImageShow2 = ShowCarryClip();
	}

	private void SetClipCount(int ov, int clipCount)
	{
		switch (clipCount)
		{
		case 0:
		{
			WeaponstateViewModel viewModel2 = _viewModel;
			bool weaponClipShow = (_viewModel.WeaponClipShow2 = false);
			viewModel2.WeaponClipShow1 = weaponClipShow;
			break;
		}
		case 1:
			_viewModel.WeaponClipShow1 = true;
			_viewModel.WeaponClipShow2 = false;
			break;
		case 2:
		{
			WeaponstateViewModel viewModel = _viewModel;
			bool weaponClipShow = (_viewModel.WeaponClipShow2 = true);
			viewModel.WeaponClipShow1 = weaponClipShow;
			break;
		}
		}
	}
}

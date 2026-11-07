using Assets.Generated.Table;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class RedpointModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private RedpointViewModel _viewModel;

	private WeaponCrossTable.Row _crossConfig;

	private bool _isUspDevil;

	private static AssetInfo _ad16Asset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/cross/ad16.png");

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
		_viewModel = new RedpointViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetShow, SetShow, null, initinvoke: true);
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_crossConfig = WeaponCrossLoader.Instance.Table.Find_Name(weaponName);
			_isUspDevil = weaponName == "usp45_devil" || weaponName == "usp45_devil1" || weaponName == "usp45_devil2";
		}
		else
		{
			_isUspDevil = false;
			_crossConfig = null;
		}
		if (_crossConfig != null && _crossConfig.InfraredGuid)
		{
			_viewModel.CenterSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, weaponName + "_cross"), delegate(Sprite sprite)
			{
				_viewModel.CenterSprite = sprite;
				_viewModel.CenterNtvsize();
			});
		}
		else
		{
			this.GetLoader().RetriveSprite(_ad16Asset, delegate(Sprite sprite)
			{
				_viewModel.CenterSprite = sprite;
				_viewModel.CenterNtvsize();
			});
		}
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.CenterShow = arg2;
	}

	private bool GetShow()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			if (_isUspDevil && (!currentWeaponEntity.hasSpecial || !currentWeaponEntity.special.SpecialMode))
			{
				return false;
			}
			if (_crossConfig != null && _crossConfig.InfraredGuid && (!currentWeaponEntity.hasSpecial || !currentWeaponEntity.special.SpecialMode))
			{
				return false;
			}
		}
		return !UiIEventCondition.Get_uiCross_HideCross();
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

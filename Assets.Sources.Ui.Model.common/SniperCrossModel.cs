using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.Common;

public class SniperCrossModel : AbstractModel, IPlaybackSystem
{
	private SniperCrossViewModel _viewModel;

	private static AssetInfo _defaultAwpCross = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/cross/awp.png");

	private WeaponCrossTable.Row _crossConfig;

	private Dictionary<string, WeaponCrossTable.Row> _crossDic = new Dictionary<string, WeaponCrossTable.Row>();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new SniperCrossViewModel();
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
		NotifyManager.MakeTempNotify(GetWeaponRes, SetWeaponRes, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
	}

	private void SetWeaponRes(BeforeJoinString arg1, BeforeJoinString arg2)
	{
		string uiCross_WeaponName = UiIEventCondition.Get_uiCross_WeaponName();
		if (_crossConfig != null)
		{
			string text = ((!_crossConfig.SniperLevelCross) ? "" : ((UiIEventCondition.Get_uiCross_WeaponLevel() > 0) ? "1" : "0"));
			if (_crossConfig.SniperCross == WeaponCrossTable.SniperCrossType.Weapon)
			{
				string weaponTexturePath = UiAssetBundleUtils.GetWeaponTexturePath(uiCross_WeaponName, uiCross_WeaponName + "_cross" + text);
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(uiCross_WeaponName), weaponTexturePath, _viewModel.AwpImage);
				return;
			}
			if (_crossConfig.SniperCross == WeaponCrossTable.SniperCrossType.Gold)
			{
				base.Loader.RetriveSprite(GetWeaponAssetInfo(uiCross_WeaponName, "goldsniper"), _viewModel.AwpImage);
				return;
			}
			if (_crossConfig.SniperCross == WeaponCrossTable.SniperCrossType.Dsr)
			{
				base.Loader.RetriveSprite(GetWeaponAssetInfo(uiCross_WeaponName, "dsrback"), _viewModel.AwpImage);
				return;
			}
		}
		base.Loader.RetriveSprite(_defaultAwpCross, _viewModel.AwpImage);
	}

	private BeforeJoinString GetWeaponRes()
	{
		_crossConfig = null;
		string uiCross_WeaponName = UiIEventCondition.Get_uiCross_WeaponName();
		if (!string.IsNullOrEmpty(uiCross_WeaponName) && !_crossDic.TryGetValue(uiCross_WeaponName, out _crossConfig))
		{
			WeaponCrossTable.Row row = WeaponCrossLoader.Instance.Table.Find_Name(uiCross_WeaponName);
			_crossDic.Add(uiCross_WeaponName, row);
			_crossConfig = row;
		}
		return new BeforeJoinString(uiCross_WeaponName, UiIEventCondition.Get_uiCross_WeaponLevel());
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.SniperCrossShow = arg2;
	}

	private bool GetVisible()
	{
		if (UiIEventCondition.Get_uiCross_HideCross())
		{
			return false;
		}
		if (UiIEventCondition.Get_uiCross_AwpVisible() && (_crossConfig == null || _crossConfig.SniperCross == WeaponCrossTable.SniperCrossType.Weapon || _crossConfig.SniperCross == WeaponCrossTable.SniperCrossType.Gold || _crossConfig.SniperCross == WeaponCrossTable.SniperCrossType.Dsr || _crossConfig.SniperCross == WeaponCrossTable.SniperCrossType.Awp))
		{
			return true;
		}
		return false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

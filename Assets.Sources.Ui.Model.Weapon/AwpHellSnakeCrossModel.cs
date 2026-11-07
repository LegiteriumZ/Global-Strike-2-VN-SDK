using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class AwpHellSnakeCrossModel : AbstractModel, IPlaybackSystem
{
	private AwpHellSnakeCrossViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new AwpHellSnakeCrossViewModel();
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
		_viewModel.CenterShow = false;
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_WeaponLevel, SetWeaponLevel, null, initinvoke: true);
	}

	private void SetWeaponLevel(int arg1, int level)
	{
		_viewModel.CenterShow = level > 0;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, weaponName + "_cross1"), delegate(Sprite sprite)
		{
			_viewModel.CenterSprite = sprite;
			_viewModel.CenterNtvsize();
		});
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

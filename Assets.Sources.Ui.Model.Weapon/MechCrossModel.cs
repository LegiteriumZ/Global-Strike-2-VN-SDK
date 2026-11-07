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
public class MechCrossModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	private MechCrossViewModel _viewModel;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MechCrossViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiCross_HideCross, SetHideCross, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.CenterShow = arg2;
	}

	private bool GetVisible()
	{
		if (UiIEventCondition.Get_uiCross_WeaponName() != "mechbomberman2")
		{
			return true;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.hasMove)
		{
			return !cameraOwnerEntity.move.ActThirdMove;
		}
		return false;
	}

	private void SetHideCross(bool arg1, bool arg2)
	{
		_viewModel.CenterShow = !arg2;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, weaponName + "_cross"), delegate(Sprite sprite)
			{
				_viewModel.CenterSprite = sprite;
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}

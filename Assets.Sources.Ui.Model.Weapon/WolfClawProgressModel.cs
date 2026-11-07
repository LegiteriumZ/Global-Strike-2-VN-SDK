using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class WolfClawProgressModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetWeaponContext
{
	private WolfclawprogressViewModel _viewModel;

	private PlayerContext _playerContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new WolfclawprogressViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_weaponContext.isCurrentWeapon)
		{
			WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
			_viewModel.showShow = WolfClawFrameAction.GetWolfClawDoublePct(currentWeaponEntity) > 0;
			_viewModel.bgShow = _viewModel.showShow;
			_viewModel.handleShow = _viewModel.showShow && !MikadukiSwordFrameAction.getDoublePctMustSucceed(currentWeaponEntity);
			if (_viewModel.showShow)
			{
				_viewModel.bgSlidervalue = WolfClawFrameAction.GetWolfClawDoublePctNow(currentWeaponEntity, _playerContext.myPlayerEntity.clientTime.ClientTime);
				_viewModel.handleSlidervalue = WolfClawFrameAction.GetWolfClawDoublePct(currentWeaponEntity);
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_viewModel.lianjibgSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "lianjibg"), delegate(Sprite sprite)
			{
				_viewModel.lianjibgSprite = sprite;
			});
			_viewModel.lianjiprogressSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "lianjiprogress"), delegate(Sprite sprite)
			{
				_viewModel.lianjiprogressSprite = sprite;
			});
			_viewModel.barSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "bar"), delegate(Sprite sprite)
			{
				_viewModel.barSprite = sprite;
			});
			_viewModel.noteSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "note"), delegate(Sprite sprite)
			{
				_viewModel.noteSprite = sprite;
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

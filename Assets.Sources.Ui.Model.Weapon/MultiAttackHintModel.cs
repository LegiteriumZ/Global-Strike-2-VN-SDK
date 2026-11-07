using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class MultiAttackHintModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetWeaponContext
{
	private MultiattackhintViewModel _viewModel;

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
		_viewModel = new MultiattackhintViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_playerContext.isMyPlayer)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		if (currentWeaponEntity.special.SpecialMode)
		{
			_viewModel.centerShow = true;
			if (PlayerAnimationUtility.IsViewAnimEqual(_playerContext.myPlayerEntity, 15))
			{
				_viewModel.clickRightShow = true;
				_viewModel.clickLeftShow = false;
			}
			else
			{
				_viewModel.clickRightShow = false;
				_viewModel.clickLeftShow = true;
			}
		}
		else
		{
			_viewModel.centerShow = false;
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
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "clickright"), delegate(Sprite sprite)
			{
				_viewModel.clickRightSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "clickleft"), delegate(Sprite sprite)
			{
				_viewModel.clickLeftSprite = sprite;
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

using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class AK47RedFlashModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetWeaponContext, ISetGameRuleContext
{
	private PlayerContext _playerContext;

	private BowprogressViewModel _viewModel;

	private WeaponContext _weaponContext;

	private bool _animationCheck;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new BowprogressViewModel();
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
		if (!_gameRuleContext.currentRule.Rule.IsBio())
		{
			_viewModel.ShowShow = false;
			return;
		}
		_viewModel.ProgressBackPosition = Vector3.zero;
		_viewModel.ProgressPosition = Vector3.zero;
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetAnimation, SetAnimation, null, initinvoke: true);
	}

	private void SetAnimation(bool arg1, bool arg2)
	{
		_animationCheck = arg2;
		CheckVisible();
	}

	private void CheckVisible()
	{
		_viewModel.ShowShow = _animationCheck && _viewModel.ProgressFillamount > 0f;
	}

	private bool GetAnimation()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity == null)
		{
			return false;
		}
		if (!PlayerAnimationUtility.IsViewAnimEqual(myPlayerEntity, 64) && !PlayerAnimationUtility.IsViewAnimEqual(myPlayerEntity, 63))
		{
			return false;
		}
		return true;
	}

	private void SetPercent(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount = arg2;
		CheckVisible();
	}

	private float GetPercent()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			float num = 3000f;
			int num2 = ((!(currentWeaponEntity.attack.NextSecondaryAttackTimer <= 500f)) ? ((!(currentWeaponEntity.attack.NextSecondaryAttackTimer > 3500f)) ? ((int)currentWeaponEntity.attack.NextSecondaryAttackTimer - 500) : 3000) : 0);
			if (!((float)num2 >= num))
			{
				return (float)num2 / num * 0.75f;
			}
			return 1f;
		}
		return 0f;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_viewModel.ProgressSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName("bow"), UiAssetBundleUtils.GetWeaponTexturePath("bow", "progress"), delegate(Sprite sprite)
			{
				_viewModel.ProgressSprite = sprite;
				_viewModel.ProgressNtvsize();
			});
			_viewModel.ProgressBackSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName("bow"), UiAssetBundleUtils.GetWeaponTexturePath("bow", "progressback"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBackSprite = sprite;
				_viewModel.ProgressBackNtvsize();
			});
		}
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}

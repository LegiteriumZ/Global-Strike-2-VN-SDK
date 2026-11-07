using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class BowProgressModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetWeaponContext, ISetGameRuleContext
{
	private PlayerContext _playerContext;

	private BowprogressViewModel _viewModel;

	private WeaponContext _weaponContext;

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
		_viewModel.ProgressBackPosition = Vector3.zero;
		_viewModel.ProgressPosition = Vector3.zero;
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true);
	}

	private void SetPercent(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount = arg2;
	}

	private float GetPercent()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return 0f;
		}
		float num = 1000f;
		if (_gameRuleContext.currentRule.Rule.IsPve())
		{
			num = 2000f;
		}
		if (currentWeaponEntity.basicInfo.Data.WeaponName == "photon_grenade_combination" || currentWeaponEntity.basicInfo.Data.WeaponName == "photon_grenade_combination1")
		{
			float num2 = ((currentWeaponEntity.hasPower && currentWeaponEntity.power.MaxPower > 0) ? ((float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower) : 0f);
			if (!(num2 >= 1f))
			{
				return num2 * 0.75f;
			}
			return 1f;
		}
		float num3 = 0f;
		if (currentWeaponEntity.basicInfo.Data.WeaponName == "bow" || currentWeaponEntity.basicInfo.Data.WeaponName == "bow_god" || currentWeaponEntity.basicInfo.Data.WeaponName == "bow_god1")
		{
			if (currentWeaponEntity.attach.Data is BowAttach bowAttach)
			{
				num3 = (int)(_playerContext.isMyPlayer ? (_playerContext.myPlayerEntity.clientTime.ClientTime - bowAttach.startAttackTime) : 0);
			}
		}
		else
		{
			num3 = ((_playerContext.isMyPlayer && currentWeaponEntity.hasAttack) ? ((int)((float)_playerContext.myPlayerEntity.clientTime.ClientTime - currentWeaponEntity.attack.NextAttackTimer)) : 0);
		}
		if (!(num3 >= num))
		{
			return num3 / num * 0.75f;
		}
		return 1f;
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private bool GetVisible()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return false;
		}
		if (currentWeaponEntity.basicInfo.Data.WeaponName == "photon_grenade_combination" || currentWeaponEntity.basicInfo.Data.WeaponName == "photon_grenade_combination1")
		{
			if (currentWeaponEntity.power.Power <= 0 || currentWeaponEntity.power.MaxPower <= 0)
			{
				return false;
			}
		}
		else if (currentWeaponEntity.attack.ShotsFired == 0)
		{
			return false;
		}
		if ((currentWeaponEntity.basicInfo.Data.WeaponName == "bow" || currentWeaponEntity.basicInfo.Data.WeaponName == "bow_god" || currentWeaponEntity.basicInfo.Data.WeaponName == "bow_god1") && currentWeaponEntity.attach.Data is BowAttach bowAttach && ((_playerContext.isMyPlayer && (int)(_playerContext.myPlayerEntity.clientTime.ClientTime - bowAttach.startAttackTime) != 0) ? 1 : 0) <= (false ? 1 : 0))
		{
			return false;
		}
		return true;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_viewModel.ProgressSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName("bow"), UiAssetBundleUtils.GetWeaponTexturePath("bow", "crossprogress"), delegate(Sprite sprite)
			{
				_viewModel.ProgressSprite = sprite;
				_viewModel.ProgressNtvsize();
			});
			_viewModel.ProgressBackSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName("bow"), UiAssetBundleUtils.GetWeaponTexturePath("bow", "crossprogressback"), delegate(Sprite sprite)
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

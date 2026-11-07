using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class BladeShieldSkillModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private BladeShieldSkillViewModel _viewModel;

	private int _progressState;

	private WeaponEntity _currentWeapon;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BladeShieldSkillViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
		if (!_viewModel.RightBottomShow || _currentWeapon == null)
		{
			return;
		}
		float num = 0f;
		if (_currentWeapon.hasPower && _currentWeapon.power.MaxPower2 > 0)
		{
			num = 1f * (float)_currentWeapon.power.Power2 / (float)_currentWeapon.power.MaxPower2;
		}
		_viewModel.ProgressImageFillamount = num;
		string weaponName = (_currentWeapon.hasBasicInfo ? _currentWeapon.basicInfo.Data.WeaponName : "bladeshield_g");
		if (num >= 1f)
		{
			if (_progressState != 1)
			{
				_progressState = 1;
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), "normalProgress_effect", delegate(Sprite sprite)
				{
					_viewModel.ProgressImageSprite = sprite;
				});
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), "activeBg_effect", delegate(Sprite sprite)
				{
					_viewModel.BackImageSprite = sprite;
				});
			}
			return;
		}
		if (_currentWeapon.hasSpecial && (_currentWeapon.special.EffectLevel & 2) > 0)
		{
			if (_progressState != 2)
			{
				_progressState = 2;
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), "normalProgress_effect", delegate(Sprite sprite)
				{
					_viewModel.ProgressImageSprite = sprite;
				});
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), "activeBg", delegate(Sprite sprite)
				{
					_viewModel.BackImageSprite = sprite;
				});
			}
			return;
		}
		float num2 = 0f;
		if (_currentWeapon.hasPower && _currentWeapon.power.RpgMaxPower > 0)
		{
			num2 = (float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() / (float)_currentWeapon.power.RpgMaxPower;
		}
		if (num2 >= 1f && CheckCd(_currentWeapon))
		{
			if (_progressState != 3)
			{
				_progressState = 3;
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), "normalProgress", delegate(Sprite sprite)
				{
					_viewModel.ProgressImageSprite = sprite;
				});
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), "activeBg", delegate(Sprite sprite)
				{
					_viewModel.BackImageSprite = sprite;
				});
			}
		}
		else if (_progressState != 4)
		{
			_progressState = 4;
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), "normalProgress", delegate(Sprite sprite)
			{
				_viewModel.ProgressImageSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), "unactiveBg", delegate(Sprite sprite)
			{
				_viewModel.BackImageSprite = sprite;
			});
		}
	}

	private bool CheckCd(WeaponEntity currentWeapon)
	{
		if (_timeComponent.ClientRealTime >= currentWeapon.basicInfo.Data.NextSkillTimer)
		{
			return true;
		}
		return false;
	}

	protected override void DoSubscribe()
	{
		if (!_gameRuleContext.currentRule.Rule.IsGeneralPve())
		{
			_viewModel.RightBottomShow = false;
			return;
		}
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		_progressState = 0;
		if (!string.IsNullOrEmpty(weaponName))
		{
			_currentWeapon = Contexts.sharedInstance.weapon.currentWeaponEntity;
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), "bar", delegate(Sprite sprite)
			{
				_viewModel.BarImageSprite = sprite;
			});
		}
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

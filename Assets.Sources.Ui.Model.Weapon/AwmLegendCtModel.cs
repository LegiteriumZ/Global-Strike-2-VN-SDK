using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class AwmLegendCtModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private BowprogressViewModel _viewModel;

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
		_viewModel.ProgressPosition = new Vector3(21f, -6f);
		_viewModel.ShowShow = false;
		if (!_gameRuleContext.currentRule.Rule.IsRpg() && !_gameRuleContext.currentRule.Rule.IsPve())
		{
			_viewModel.ProgressBackPosition = Vector3.zero;
			_viewModel.ProgressPosition = Vector3.zero;
			base.DoSubscribe();
			NotifyManager.MakeTempNotify(GetCurrentWeaponSpecial, SetCurrentWeaponSpecial, null, initinvoke: true);
			NotifyManager.MakeTempNotify(UiIEventCondition.Get_CurrentWeapon_PowerPercent, SetPowerPercent, null, initinvoke: true);
		}
	}

	private void SetPowerPercent(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount = arg2;
		_viewModel.ShowShow = arg2 > 0f;
	}

	private void SetCurrentWeaponSpecial(bool arg1, bool arg2)
	{
		WeaponEntity currentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		string weaponName = currentWeaponEntity.basicInfo.Data.WeaponName;
		if (arg2)
		{
			this.GetLoader().RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillBg_special"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBackSprite = sprite;
				_viewModel.ProgressBackNtvsize();
			});
			this.GetLoader().RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillProgress_special"), delegate(Sprite sprite)
			{
				_viewModel.ProgressSprite = sprite;
				_viewModel.ProgressNtvsize();
			});
		}
		else
		{
			this.GetLoader().RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillBg"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBackSprite = sprite;
				_viewModel.ProgressBackNtvsize();
			});
			this.GetLoader().RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillProgress"), delegate(Sprite sprite)
			{
				_viewModel.ProgressSprite = sprite;
				_viewModel.ProgressNtvsize();
			});
		}
	}

	private bool GetCurrentWeaponSpecial()
	{
		WeaponEntity currentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			return (currentWeaponEntity.basicInfo.Data.WeaponFlag & 1) > 0;
		}
		return false;
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

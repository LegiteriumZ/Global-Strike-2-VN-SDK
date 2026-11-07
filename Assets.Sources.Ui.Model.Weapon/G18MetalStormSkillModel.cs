using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class G18MetalStormSkillModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetWeaponContext
{
	private G18MetalStormSkillViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

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
		_viewModel = new G18MetalStormSkillViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.RightBottomShow)
		{
			WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
			if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
			{
				_viewModel.RightBottomShow = true;
				_viewModel.CurrentString = currentWeaponEntity.power.Power.ToString();
				_viewModel.TotalString = currentWeaponEntity.power.MaxPower.ToString();
				_viewModel.ProgressImageFillamount = ((currentWeaponEntity.power.MaxPower > 0) ? ((float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower) : 0f);
			}
		}
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
		if (!string.IsNullOrEmpty(weaponName))
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillBg"), delegate(Sprite sprite)
			{
				_viewModel.BackImageSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillProgress"), delegate(Sprite sprite)
			{
				_viewModel.ProgressImageSprite = sprite;
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

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}

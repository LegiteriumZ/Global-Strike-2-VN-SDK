using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class SawProgressModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private SawprogressViewModel _viewModel;

	private WeaponContext _weaponContext;

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
		_viewModel = new SawprogressViewModel();
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
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true);
	}

	private void SetPercent(float arg1, float percent)
	{
		_viewModel.ProgessFillamount = percent;
		_viewModel.WaitShow = percent <= 0f;
	}

	private float GetPercent()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			if (currentWeaponEntity.power.MaxPower <= 0)
			{
				return 0f;
			}
			return 1f * (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
		}
		return 0f;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_viewModel.ProgessSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "state"), delegate(Sprite sprite)
			{
				_viewModel.ProgessSprite = sprite;
			});
			_viewModel.ProgessBackSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "back"), delegate(Sprite sprite)
			{
				_viewModel.ProgessBackSprite = sprite;
			});
			_viewModel.WaitSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "wait"), delegate(Sprite sprite)
			{
				_viewModel.WaitSprite = sprite;
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

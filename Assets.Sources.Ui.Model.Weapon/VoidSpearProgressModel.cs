using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class VoidSpearProgressModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private BowprogressViewModel _viewModel;

	private WeaponContext _weaponContext;

	private NotifyGroup _notifyGroup = new NotifyGroup();

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
		_viewModel.ProgressPosition = new Vector3(21f, -6f);
		base.DoSubscribe();
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true));
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		_notifyGroup.SetSuspend(!arg2);
	}

	private bool GetVisible()
	{
		float percent = GetPercent();
		if (percent > 0f)
		{
			return percent < 1f;
		}
		return false;
	}

	private void SetPercent(float arg1, float percent)
	{
		_viewModel.ProgressFillamount = percent;
	}

	private float GetPercent()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			if (currentWeaponEntity.power.RpgMaxPower == 0)
			{
				return 0f;
			}
			return (float)currentWeaponEntity.basicInfo.Data.NextSkillTimer / (float)currentWeaponEntity.power.RpgMaxPower;
		}
		return 0f;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			_viewModel.ProgressSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillProgress"), delegate(Sprite sprite)
			{
				_viewModel.ProgressSprite = sprite;
				_viewModel.ProgressNtvsize();
			});
			_viewModel.ProgressBackSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillBg"), delegate(Sprite sprite)
			{
				_viewModel.ProgressBackSprite = sprite;
				_viewModel.ProgressBackNtvsize();
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

using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class SkillChangeModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private SkillChangeViewModel _viewModel;

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
		_viewModel = new SkillChangeViewModel();
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
		NotifyManager.MakeTempNotify(GetChange, SetChange, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunProgress, SetDunProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunVisible, SetDunVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetSkillCd, SetSkillCd, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetCanUse, SetCanUse, null, initinvoke: true);
	}

	private void SetCanUse(bool arg1, bool arg2)
	{
		_viewModel.SkillBackShow = arg2;
		_viewModel.BackEnabled = !arg2;
	}

	private bool GetCanUse()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasClip || !currentWeaponEntity.hasSpecial)
		{
			return false;
		}
		if (currentWeaponEntity.clip.Clip2 == 0)
		{
			return GetSkillCd() >= 1f;
		}
		return currentWeaponEntity.special.SpecialMode;
	}

	private void SetSkillCd(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount = arg2;
	}

	private float GetSkillCd()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return 0f;
		}
		TimeComponent time = Contexts.sharedInstance.time.time;
		return 1f - (float)(currentWeaponEntity.basicInfo.Data.NextSkillTimer - time.ClientRealTime) / 120000f;
	}

	private void SetDunVisible(bool arg1, bool arg2)
	{
		_viewModel.DunShow = arg2;
	}

	private bool GetDunVisible()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			return currentWeaponEntity.power.MaxPower > 0;
		}
		return false;
	}

	private void SetDunProgress(float arg1, float arg2)
	{
		_viewModel.DunProgressFillamount = arg2;
	}

	private float GetDunProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
	}

	private void SetChange(ComboValue<bool, string> arg1, ComboValue<bool, string> arg2)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		string weaponName = currentWeaponEntity.basicInfo.Data.WeaponName;
		if (arg2.Value0)
		{
			_viewModel.ProgressShow = false;
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "unactiveBg_special"), delegate(Sprite sprite)
			{
				_viewModel.BackSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "activeBg_special"), delegate(Sprite sprite)
			{
				_viewModel.SkillBackSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "dunbg"), delegate(Sprite sprite)
			{
				_viewModel.DunSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "dunprogress"), delegate(Sprite sprite)
			{
				_viewModel.DunProgressSprite = sprite;
			});
			return;
		}
		_viewModel.ProgressShow = true;
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "unactiveBg"), delegate(Sprite sprite)
		{
			_viewModel.BackSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "activeBg"), delegate(Sprite sprite)
		{
			_viewModel.SkillBackSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "normalProgress"), delegate(Sprite sprite)
		{
			_viewModel.ProgressSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "dunbg"), delegate(Sprite sprite)
		{
			_viewModel.DunSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "dunprogress"), delegate(Sprite sprite)
		{
			_viewModel.DunProgressSprite = sprite;
		});
	}

	private ComboValue<bool, string> GetChange()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			return new ComboValue<bool, string>(currentWeaponEntity != null && currentWeaponEntity.hasClip && currentWeaponEntity.clip.Clip2 > 0, currentWeaponEntity.basicInfo.Data.WeaponName);
		}
		return new ComboValue<bool, string>(value0: false, "");
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}

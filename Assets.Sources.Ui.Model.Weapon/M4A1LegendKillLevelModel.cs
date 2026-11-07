using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class M4A1LegendKillLevelModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private M4A1LegendKillLevelViewModel _viewModel;

	private WeaponContext _weaponContext;

	private FrameAnimaChip _effectFrameAnimaChip = new FrameAnimaChip();

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
		_viewModel = new M4A1LegendKillLevelViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited || !_viewModel.ShowShow)
		{
			return;
		}
		UpdateChips();
		if (!_effectFrameAnimaChip.Changed)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			string weaponName = currentWeaponEntity.basicInfo.Data.WeaponName;
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, _effectFrameAnimaChip.Value), delegate(Sprite sprite)
			{
				_viewModel.EffectSprite = sprite;
			});
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetEffectLevel, SetEffectLevel, null, initinvoke: true);
	}

	private void CheckVisible()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.basicInfo.Data.EffectLevel > 0 && currentWeaponEntity.hasPower && currentWeaponEntity.power.MaxPower2 > 0 && currentWeaponEntity.power.Power2 > 0)
		{
			_viewModel.ShowShow = true;
		}
		else
		{
			_viewModel.ShowShow = false;
		}
	}

	private void SetEffectLevel(int arg1, int arg2)
	{
		CheckVisible();
		if (arg2 <= 0)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			string weaponName = currentWeaponEntity.basicInfo.Data.WeaponName;
			int num = 1;
			if ((arg2 & 1) > 0)
			{
				_effectFrameAnimaChip.Path = "progressFxBlue";
				num = 1;
			}
			else if ((arg2 & 2) > 0)
			{
				_effectFrameAnimaChip.Path = "progressFxYellow";
				num = 2;
			}
			else if ((arg2 & 4) > 0)
			{
				_effectFrameAnimaChip.Path = "progressFxRed";
				num = 3;
			}
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, $"number{num}"), delegate(Sprite sprite)
			{
				_viewModel.NumberSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, $"number{num}_bg"), delegate(Sprite sprite)
			{
				_viewModel.ProgessBackSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, $"number{num}_progress"), delegate(Sprite sprite)
			{
				_viewModel.ProgessSprite = sprite;
			});
		}
	}

	private int GetEffectLevel()
	{
		return _weaponContext.currentWeaponEntity?.basicInfo.Data.EffectLevel ?? 0;
	}

	private void SetPercent(float arg1, float arg2)
	{
		CheckVisible();
		_viewModel.ProgessFillamount = arg2;
		_viewModel.EffectPosition = new Vector3(-108f + 215f * arg2, 0f);
	}

	private float GetPercent()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			if (currentWeaponEntity.power.MaxPower2 <= 0)
			{
				return 0f;
			}
			return (float)currentWeaponEntity.power.Power2 / (float)currentWeaponEntity.power.MaxPower2;
		}
		return 0f;
	}

	private void InitChips()
	{
		_effectFrameAnimaChip.Path = "progressFxBlue";
		_effectFrameAnimaChip.Delay = 100;
		_effectFrameAnimaChip.StartIndex = 1;
		_effectFrameAnimaChip.Count = 12;
		_effectFrameAnimaChip.Extension = "";
		_effectFrameAnimaChip.Format = "D2";
		_effectFrameAnimaChip.IsLoop = true;
		_effectFrameAnimaChip.Init();
	}

	private void UpdateChips()
	{
		_effectFrameAnimaChip.Update(_timeComponent);
	}
}

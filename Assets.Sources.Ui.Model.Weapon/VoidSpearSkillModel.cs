using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class VoidSpearSkillModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private M4A1LegendSphereNumViewModel _viewModel;

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
		_viewModel = new M4A1LegendSphereNumViewModel();
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
		_viewModel.GridPosition = new Vector3(-5f, 12f);
		_viewModel.BackEnabled = false;
		_viewModel.GridHspacing = -4f;
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetItemShow(i + 1, value: false);
		}
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetMaxClip2, SetMaxClip2, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetClip2, SetClip2, null, initinvoke: true);
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private bool GetVisible()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasSpecial && currentWeaponEntity.special.SpecialMode)
		{
			return (currentWeaponEntity.basicInfo.Data.EffectLevel & 8) > 0;
		}
		return false;
	}

	private void SetClip2(int arg1, int arg2)
	{
		for (int i = 0; i < 6; i++)
		{
			_viewModel.SetIconShow(i + 1, i < arg2);
		}
	}

	private int GetClip2()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasClip)
		{
			return currentWeaponEntity.clip.Clip2;
		}
		return 0;
	}

	private void SetMaxClip2(int arg1, int arg2)
	{
		for (int i = 0; i < 6; i++)
		{
			_viewModel.SetItemShow(i + 1, i < arg2);
		}
	}

	private int GetMaxClip2()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			return currentWeaponEntity.power.MaxPower2;
		}
		return 0;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (string.IsNullOrEmpty(weaponName))
		{
			return;
		}
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "numberActive"), delegate(Sprite sprite)
		{
			for (int j = 0; j < 6; j++)
			{
				_viewModel.SetItemSprite(j + 1, sprite);
				_viewModel.CallItemNtvsize(j + 1);
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "number"), delegate(Sprite sprite)
		{
			for (int i = 0; i < 6; i++)
			{
				_viewModel.SetIconSprite(i + 1, sprite);
				_viewModel.CallIconNtvsize(i + 1);
			}
		});
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

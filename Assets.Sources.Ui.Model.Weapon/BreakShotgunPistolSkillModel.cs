using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class BreakShotgunPistolSkillModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetGameRuleContext
{
	private M4A1LegendSphereNumViewModel _viewModel;

	private WeaponContext _weaponContext;

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
		_viewModel = new M4A1LegendSphereNumViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		if (!_gameRuleContext.currentRule.Rule.IsPve() && !_gameRuleContext.currentRule.Rule.IsBighead() && !_gameRuleContext.currentRule.Rule.IsBio())
		{
			_viewModel.ShowShow = false;
			return;
		}
		_viewModel.GridPosition = new Vector3(-5f, 3f);
		_viewModel.GridHspacing = 2f;
		base.DoSubscribe();
		SimpleNotify.Add(GetClip, SetClip);
		SimpleNotify.Add(GetCarryClip, SetCarryClip);
		SimpleNotify.Add(GetVisible, SetVisible);
		SimpleNotify.Add(GetWeaponName, SetWeaponName);
	}

	private void SetWeaponName(string weaponName, int arg2)
	{
		if (string.IsNullOrEmpty(weaponName))
		{
			return;
		}
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "number_bg"), delegate(Sprite sprite)
		{
			for (int j = 0; j < 10; j++)
			{
				_viewModel.SetItemSprite(j + 1, sprite);
				_viewModel.CallItemNtvsize(j + 1);
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "number"), delegate(Sprite sprite)
		{
			for (int i = 0; i < 10; i++)
			{
				_viewModel.SetIconSprite(i + 1, sprite);
				_viewModel.CallIconNtvsize(i + 1);
			}
		});
	}

	private string GetWeaponName(int arg1)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			return currentWeaponEntity.basicInfo.Data.WeaponName;
		}
		return string.Empty;
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.ShowShow = arg1;
	}

	private bool GetVisible(int arg1)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			return currentWeaponEntity.power.MaxPower != 0;
		}
		return false;
	}

	private void SetCarryClip(int arg1, int arg2)
	{
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetItemShow(i + 1, i < arg1);
		}
	}

	private int GetCarryClip(int arg1)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasClip)
		{
			return currentWeaponEntity.clip.CarryClip2;
		}
		return 0;
	}

	private void SetClip(int arg1, int arg2)
	{
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetIconShow(i + 1, i < arg1);
		}
	}

	private int GetClip(int arg1)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasClip)
		{
			return currentWeaponEntity.clip.Clip2;
		}
		return 0;
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

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}

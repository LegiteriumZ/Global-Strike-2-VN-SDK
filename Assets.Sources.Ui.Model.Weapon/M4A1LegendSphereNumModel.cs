using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class M4A1LegendSphereNumModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetWeaponContext
{
	private M4A1LegendSphereNumViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

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
		base.DoSubscribe();
		if (!_gameRuleContext.currentRule.Rule.IsGeneralPve())
		{
			_viewModel.ShowShow = false;
			return;
		}
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 1100)
		{
			_viewModel.ShowShow = false;
			return;
		}
		_viewModel.GridPosition = new Vector3(14f, -5f);
		_viewModel.BackEnabled = false;
		_viewModel.GridHspacing = -4f;
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetItemShow(i + 1, value: false);
		}
		NotifyManager.MakeTempNotify(GetSpecialMode, SetSpecialMode, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetClip2, SetClip2, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetCarryClip2, SetCarryClip2, null, initinvoke: true);
	}

	private void SetCarryClip2(int arg1, int arg2)
	{
		for (int i = 0; i < 6; i++)
		{
			_viewModel.SetItemShow(i + 1, i < arg2);
		}
	}

	private int GetCarryClip2()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasClip)
		{
			return currentWeaponEntity.clip.CarryClip2;
		}
		return 0;
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

	private void SetSpecialMode(bool arg1, bool arg2)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		string weaponName = currentWeaponEntity.basicInfo.Data.WeaponName;
		if (arg2)
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "lightBallActive"), delegate(Sprite sprite)
			{
				for (int l = 0; l < 6; l++)
				{
					_viewModel.SetIconSprite(l + 1, sprite);
					_viewModel.CallIconNtvsize(l + 1);
				}
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "lightBallUnactive"), delegate(Sprite sprite)
			{
				for (int k = 0; k < 6; k++)
				{
					_viewModel.SetItemSprite(k + 1, sprite);
					_viewModel.CallItemNtvsize(k + 1);
				}
			});
			return;
		}
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "eleBallActive"), delegate(Sprite sprite)
		{
			for (int j = 0; j < 6; j++)
			{
				_viewModel.SetIconSprite(j + 1, sprite);
				_viewModel.CallIconNtvsize(j + 1);
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "eleBallUnactive"), delegate(Sprite sprite)
		{
			for (int i = 0; i < 6; i++)
			{
				_viewModel.SetItemSprite(i + 1, sprite);
				_viewModel.CallItemNtvsize(i + 1);
			}
		});
	}

	private bool GetSpecialMode()
	{
		if (_weaponContext.isCurrentWeapon)
		{
			WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
			if (currentWeaponEntity.hasSpecial)
			{
				return currentWeaponEntity.special.SpecialMode;
			}
		}
		return false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

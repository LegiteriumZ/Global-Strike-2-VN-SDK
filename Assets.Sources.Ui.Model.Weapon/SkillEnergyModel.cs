using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class SkillEnergyModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetWeaponContext
{
	private float _maxHeatEnergy = 1000f;

	private SkillenergyViewModel _viewModel;

	private PlayerContext _playerContext;

	private WeaponContext _weaponContext;

	private int _status;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new SkillenergyViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_playerContext.isMyPlayer)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasBasicInfo)
		{
			return;
		}
		if (CheckVisible(currentWeaponEntity))
		{
			_viewModel.CenterShow = true;
			float progress = GetProgress(currentWeaponEntity);
			_viewModel.ProgressImageFillamount = progress;
			if (currentWeaponEntity.basicInfo.Info.Name.Equals("usp45_devil") || currentWeaponEntity.basicInfo.Info.Name.Equals("usp45_devil1") || currentWeaponEntity.basicInfo.Info.Name.Equals("usp45_devil2"))
			{
				if (_status != 1)
				{
					_viewModel.BackImageSprite = base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/weaaponEnergy/progressBack.png", delegate(Sprite v)
					{
						_viewModel.BackImageSprite = v;
					});
					_viewModel.ProgressImageSprite = base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/weaaponEnergy/whiteProgress.png", delegate(Sprite v)
					{
						_viewModel.ProgressImageSprite = v;
					});
					_status = 1;
				}
				return;
			}
			if (_status < 2)
			{
				_viewModel.BackImageSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(currentWeaponEntity.basicInfo.Info.Name), UiAssetBundleUtils.GetWeaponTexturePath(currentWeaponEntity.basicInfo.Info.Name, "progressBack"), delegate(Sprite v)
				{
					_viewModel.BackImageSprite = v;
				});
			}
			if ((double)progress <= 0.5)
			{
				if (_status != 2)
				{
					_viewModel.ProgressImageSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(currentWeaponEntity.basicInfo.Info.Name), UiAssetBundleUtils.GetWeaponTexturePath(currentWeaponEntity.basicInfo.Info.Name, "whiteProgress"), delegate(Sprite v)
					{
						_viewModel.ProgressImageSprite = v;
					});
					_status = 2;
				}
			}
			else if ((double)progress <= 0.8)
			{
				if (_status != 3)
				{
					_viewModel.ProgressImageSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(currentWeaponEntity.basicInfo.Info.Name), UiAssetBundleUtils.GetWeaponTexturePath(currentWeaponEntity.basicInfo.Info.Name, "yellowProgress"), delegate(Sprite v)
					{
						_viewModel.ProgressImageSprite = v;
					});
					_status = 3;
				}
			}
			else if (_status != 4)
			{
				_viewModel.ProgressImageSprite = base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(currentWeaponEntity.basicInfo.Info.Name), UiAssetBundleUtils.GetWeaponTexturePath(currentWeaponEntity.basicInfo.Info.Name, "redProgress"), delegate(Sprite v)
				{
					_viewModel.ProgressImageSprite = v;
				});
				_status = 4;
			}
		}
		else
		{
			_viewModel.CenterShow = false;
		}
	}

	private bool CheckVisible(WeaponEntity currentWeapon)
	{
		switch (currentWeapon.basicInfo.Info.Name)
		{
		case "qbz95_hero":
		case "qbz95_hero1":
			if (currentWeapon.hasSpecial)
			{
				return currentWeapon.special.Level == 1;
			}
			break;
		case "m60":
		case "m60_1":
		case "m60_2":
		case "m60_roadmaster":
		case "m60e6bloodanger":
		case "m60e6bloodanger1":
		case "m60e6_vampire":
		case "m60e6_vampire_1":
		case "m60e6_vampire_2":
			if (currentWeapon.hasSpecial)
			{
				return currentWeapon.special.Level >= 1;
			}
			break;
		case "usp45_devil":
		case "usp45_devil1":
		case "usp45_devil2":
			if (currentWeapon.hasSpecial)
			{
				return currentWeapon.special.SpecialMode;
			}
			break;
		}
		return false;
	}

	private float GetProgress(WeaponEntity currentWeapon)
	{
		_maxHeatEnergy = (currentWeapon.basicInfo.Info.Name.Equals("m60e6bloodanger") ? 800 : 1000);
		switch (currentWeapon.basicInfo.Info.Name)
		{
		case "qbz95_hero":
		case "qbz95_hero1":
			if (currentWeapon.power.MaxPower2 < 1)
			{
				return 0f;
			}
			return (float)currentWeapon.power.Power2 * 1f / (float)currentWeapon.power.MaxPower2;
		case "m60":
		case "m60_1":
		case "m60_2":
		case "m60_roadmaster":
		case "m60e6bloodanger":
		case "m60e6bloodanger1":
		case "m60e6bloodanger2":
		case "m60e6_vampire":
		case "m60e6_vampire_1":
		case "m60e6_vampire_2":
			if (currentWeapon.hasSpecial)
			{
				return (float)currentWeapon.special.Level / _maxHeatEnergy;
			}
			break;
		case "usp45_devil":
		case "usp45_devil1":
		case "usp45_devil2":
			if (currentWeapon.hasSpecial)
			{
				return (float)currentWeapon.power.Power / (float)currentWeapon.power.MaxPower;
			}
			break;
		}
		return 0f;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

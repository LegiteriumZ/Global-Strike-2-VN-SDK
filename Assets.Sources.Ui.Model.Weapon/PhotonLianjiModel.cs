using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class PhotonLianjiModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetGameRuleContext
{
	private M4A1LegendSphereNumViewModel _viewModel;

	private WeaponContext _weaponContext;

	private GameRuleContext _gameRuleContext;

	private FrameAnimaChip _animaChip;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
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
		if (_viewModel.IsInited && _weaponContext.isCurrentWeapon)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		if (!_gameRuleContext.currentRule.Rule.IsGeneralPve())
		{
			_viewModel.ShowShow = false;
			return;
		}
		_viewModel.GridHspacing = -14.6f;
		_viewModel.GridPosition = new Vector3(14f, -5f);
		_viewModel.BackEnabled = true;
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetItemShow(i + 1, value: false);
		}
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CurrentWeapon_SpecialLevel, SetSpecialLevel, null, initinvoke: true);
	}

	private void SetSpecialLevel(int arg1, int arg2)
	{
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetItemShow(i + 1, i < arg2);
		}
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (string.IsNullOrEmpty(weaponName))
		{
			return;
		}
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "encourageback"), delegate(Sprite sprite)
		{
			_viewModel.BackSprite = sprite;
			_viewModel.BackNtvsize();
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "encourageicon4"), delegate(Sprite sprite)
		{
			for (int i = 0; i < 10; i++)
			{
				_viewModel.SetIconSprite(i + 1, sprite);
				_viewModel.CallIconNtvsize(i + 1);
			}
		});
	}

	private void InitChips()
	{
		_animaChip = new FrameAnimaChip
		{
			Path = "encourageicon",
			Delay = 200,
			Count = 5,
			StartIndex = 0,
			IsLoop = true,
			Extension = ""
		};
	}

	private void UpdateChips()
	{
		if (!_viewModel.ShowShow)
		{
			return;
		}
		_animaChip.Update(_timeComponent);
		if (!_animaChip.Changed)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(currentWeaponEntity.basicInfo.Info.Name), UiAssetBundleUtils.GetWeaponTexturePath(currentWeaponEntity.basicInfo.Info.Name, _animaChip.Value), delegate(Sprite sprite)
		{
			for (int i = 0; i < 10; i++)
			{
				if (_viewModel.GetItemShow(i + 1))
				{
					_viewModel.SetIconSprite(i + 1, sprite);
				}
			}
		});
	}
}

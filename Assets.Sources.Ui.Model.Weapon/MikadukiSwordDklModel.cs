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
public class MikadukiSwordDklModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetWeaponContext
{
	private MikadukiSwordDklViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private float _percent2;

	private float _percent1;

	private const int Component1 = 512;

	private const int Component2 = 2048;

	private bool _component1Visible;

	private bool _component2Visible;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new MikadukiSwordDklViewModel();
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
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetPercent1, SetPercent1, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetPercent2, SetPercent2, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetActiveBgVisible, SetActiveBgVisible, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true));
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "activeBgSpecial"), delegate(Sprite sprite)
		{
			_viewModel.ActiveBgSpecialSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "activeBg"), delegate(Sprite sprite)
		{
			_viewModel.ActiveBgSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "unactiveBgSpecial"), delegate(Sprite sprite)
		{
			_viewModel.UnactiveBgSpecialSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "unactiveBg"), delegate(Sprite sprite)
		{
			_viewModel.UnactiveBgSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "normalProgress"), delegate(Sprite sprite)
		{
			_viewModel.ProgressSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "progressBgSpecial"), delegate(Sprite sprite)
		{
			_viewModel.EnergyBgSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "progress"), delegate(Sprite sprite)
		{
			_viewModel.EnergyProgressSprite = sprite;
		});
	}

	private void SetActiveBgVisible(bool arg1, bool arg2)
	{
		_viewModel.EnergyBgShow = _component2Visible;
		_viewModel.EnergyProgressShow = _component2Visible;
		_viewModel.ProgressShow = _component1Visible;
		if (_component1Visible)
		{
			_viewModel.ActiveBgSpecialShow = arg2;
			_viewModel.UnactiveBgSpecialShow = !arg2;
			_viewModel.ActiveBgShow = false;
			_viewModel.UnactiveBgShow = false;
		}
		else if (_component2Visible)
		{
			_viewModel.ActiveBgSpecialShow = false;
			_viewModel.UnactiveBgSpecialShow = false;
			_viewModel.ActiveBgShow = arg2;
			_viewModel.UnactiveBgShow = !arg2;
		}
		else
		{
			_viewModel.ActiveBgShow = false;
			_viewModel.UnactiveBgShow = false;
			_viewModel.ActiveBgSpecialShow = false;
			_viewModel.UnactiveBgSpecialShow = false;
		}
	}

	private bool GetActiveBgVisible()
	{
		if (_component1Visible && _component2Visible)
		{
			return _percent2 >= 1f;
		}
		if (_component1Visible)
		{
			return _percent2 >= 1f;
		}
		if (_component2Visible)
		{
			return _percent1 >= 1f;
		}
		return false;
	}

	private void SetPercent2(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount = arg2;
		_percent2 = arg2;
	}

	private float GetPercent2()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return 0f;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity.basicInfo.Data.Kill != 0)
		{
			return (float)_gameRuleContext.tdSkillStateData.CurrentMp / (float)currentWeaponEntity.basicInfo.Data.Kill;
		}
		return 0f;
	}

	private float GetPercent1()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return 0f;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (!currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		if (currentWeaponEntity.power.MaxPower != 0)
		{
			return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
		}
		return 0f;
	}

	private void SetPercent1(float arg1, float arg2)
	{
		_viewModel.EnergyProgressFillamount = arg2;
		_percent1 = arg2;
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.RightBottomShow = arg2;
		_notifyGroup.SetSuspend(!arg2);
	}

	private bool GetVisible()
	{
		GetComponent1Visible();
		GetComponent2Visible();
		if (!_component1Visible)
		{
			return _component2Visible;
		}
		return true;
	}

	private bool GetComponent1Visible()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return false;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		_component1Visible = (currentWeaponEntity.basicInfo.Data.EffectLevel & 0x200) > 0 && _gameRuleContext.currentRule.Rule.IsPve();
		return _component1Visible;
	}

	private bool GetComponent2Visible()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return false;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		_component2Visible = (currentWeaponEntity.basicInfo.Data.EffectLevel & 0x800) > 0;
		return _component2Visible;
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

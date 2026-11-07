using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class ShieldCannonModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetWeaponContext
{
	private M4A1LegendSphereNumViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		_viewModel = new M4A1LegendSphereNumViewModel();
	}

	public void OnPlayback()
	{
		_ = _viewModel.IsInited;
	}

	protected override void DoSubscribe()
	{
		if (!_gameRuleContext.currentRule.Rule.IsPve())
		{
			_viewModel.ShowShow = false;
			return;
		}
		_viewModel.ShowShow = true;
		_viewModel.GridHspacing = 0f;
		_viewModel.GridPosition = new Vector3(4f, 8f);
		_viewModel.BackEnabled = false;
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetItemShow(i + 1, value: false);
		}
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CurrentWeapon_MaxPower, SetMaxPower, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CurrentWeapon_Power, SetPower, null, initinvoke: true);
	}

	private void SetMaxPower(int arg1, int arg2)
	{
		for (int i = 0; i < 6; i++)
		{
			_viewModel.SetItemShow(i + 1, i < arg2);
		}
	}

	private void SetPower(int arg1, int arg2)
	{
		for (int i = 0; i < 6; i++)
		{
			_viewModel.SetIconShow(i + 1, i < arg2);
		}
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (string.IsNullOrEmpty(weaponName))
		{
			return;
		}
		_viewModel.GridHspacing = 0f;
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "number"), delegate(Sprite sprite)
		{
			for (int j = 0; j < 6; j++)
			{
				_viewModel.SetItemSprite(j + 1, sprite);
				_viewModel.CallItemNtvsize(j + 1);
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "numberActive"), delegate(Sprite sprite)
		{
			for (int i = 0; i < 6; i++)
			{
				_viewModel.SetIconSprite(i + 1, sprite);
				_viewModel.CallIconNtvsize(i + 1);
			}
		});
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}

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
public class RevolverBattleEnergyNumModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private M4A1LegendSphereNumViewModel _viewModel;

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
		if (_viewModel.IsInited)
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
		_viewModel.GridHspacing = -22f;
		_viewModel.GridPosition = new Vector3(6f, 3f);
		_viewModel.BackEnabled = true;
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetItemShow(i + 1, value: false);
		}
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CurrentWeapon_MaxPower, SetMaxPower, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (string.IsNullOrEmpty(weaponName))
		{
			return;
		}
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillBg"), delegate(Sprite sprite)
		{
			_viewModel.BackSprite = sprite;
			_viewModel.BackNtvsize();
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillActive"), delegate(Sprite sprite)
		{
			for (int i = 0; i < 10; i++)
			{
				_viewModel.SetIconSprite(i + 1, sprite);
				_viewModel.CallIconNtvsize(i + 1);
			}
		});
	}

	private void SetMaxPower(int arg1, int arg2)
	{
		for (int i = 0; i < 10; i++)
		{
			_viewModel.SetItemShow(i + 1, i < arg2);
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}

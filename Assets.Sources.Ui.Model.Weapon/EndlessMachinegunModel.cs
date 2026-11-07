using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class EndlessMachinegunModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetWeaponContext
{
	private M4A1LegendSphereNumViewModel _viewModel;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

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
		_raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsPve(_raceType) || RuleUtilty.IsBioMode(_raceType) || RuleUtilty.IsBigHeadModel(_raceType))
		{
			if (_weaponContext.currentWeaponEntity.hasSpecial && (_weaponContext.currentWeaponEntity.special.EffectLevel & 2) > 0)
			{
				_viewModel.ShowShow = true;
				_viewModel.GridHspacing = 0f;
				_viewModel.GridPosition = new Vector3(-5f, 3f);
				_viewModel.BackEnabled = false;
			}
			base.DoSubscribe();
			SetMaxPower(UiIEventCondition.Get_CurrentWeapon_MaxPower2());
			NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
			NotifyManager.MakeTempNotify(UiIEventCondition.Get_CurrentWeapon_MaxPower, SetPower, null, initinvoke: true);
		}
		else
		{
			_viewModel.ShowShow = false;
		}
	}

	private void SetMaxPower(int num)
	{
		for (int i = 0; i < 5; i++)
		{
			_viewModel.SetItemShow(i + 1, i < num);
		}
	}

	private void SetPower(int arg1, int arg2)
	{
		for (int i = 0; i < 5; i++)
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
			for (int j = 0; j < 5; j++)
			{
				_viewModel.SetItemSprite(j + 1, sprite);
				_viewModel.CallItemNtvsize(j + 1);
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "numberActive"), delegate(Sprite sprite)
		{
			for (int i = 0; i < 5; i++)
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

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}

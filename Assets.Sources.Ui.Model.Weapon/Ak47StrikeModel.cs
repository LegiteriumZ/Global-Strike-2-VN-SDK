using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class Ak47StrikeModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetGameRuleContext, ISetBattleRoomContext
{
	private Ak47StrikeViewModel _viewModel;

	private WeaponContext _weaponContext;

	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	private bool _commonBackCanShow;

	private string _assetWeapon1;

	private string _assetWeapon2;

	private string _currBack;

	private string _weaponName;

	private float _rate;

	private ScaleChip _iconImageScaleChip = new ScaleChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Ak47StrikeViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.RightBottomShow && !_commonBackCanShow && _rate >= 1f)
		{
			UpdateChips();
			if (_iconImageScaleChip.Scale.x >= 1.5f)
			{
				_iconImageScaleChip.Speed = new Vector3(-1f, -1f, -1f);
				_iconImageScaleChip.TargetScale = new Vector3(1f, 1f, 1f);
			}
			else if (_iconImageScaleChip.Scale.x <= 1f)
			{
				_iconImageScaleChip.Speed = new Vector3(1f, 1f, 1f);
				_iconImageScaleChip.TargetScale = new Vector3(1.5f, 1.5f, 1.5f);
			}
		}
	}

	protected override void DoSubscribe()
	{
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		_commonBackCanShow = !_gameRuleContext.currentRule.Rule.IsBio() && !_gameRuleContext.currentRule.Rule.IsGeneralPve() && raceType != 29 && raceType != 34;
		if (!_commonBackCanShow)
		{
			_viewModel.CommonBackImageShow = false;
			_viewModel.BackImageShow = true;
		}
		else
		{
			_viewModel.BackImageShow = false;
		}
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(GetAkHero, SetAkHero, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPercent, SetPercent, null, initinvoke: true);
	}

	private void SetPercent(float arg1, float arg2)
	{
		_rate = arg2;
		_viewModel.ProgressImageFillamount = 0.1f + 0.8f * arg2;
		if (arg2 >= 1f)
		{
			_viewModel.IconImageShow = true;
			string text = ((_weaponName == "ak47_strike") ? "ak47strikebioback2" : "ak47herobioback2");
			if (_assetWeapon1 != _weaponName || _currBack != text)
			{
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_weaponName), UiAssetBundleUtils.GetWeaponTexturePath(_weaponName, text), delegate(Sprite sprite)
				{
					_viewModel.BackImageSprite = sprite;
				});
				_currBack = text;
				_assetWeapon1 = _weaponName;
			}
			return;
		}
		_viewModel.IconImageShow = false;
		string text2 = ((_weaponName == "ak47_strike") ? "ak47strikebioback1" : "ak47herobioback1");
		if (_assetWeapon2 != _weaponName || _currBack != text2)
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_weaponName), UiAssetBundleUtils.GetWeaponTexturePath(_weaponName, text2), delegate(Sprite sprite)
			{
				_viewModel.BackImageSprite = sprite;
			});
			_assetWeapon2 = _weaponName;
			_currBack = text2;
		}
		_iconImageScaleChip.Scale = Vector3.one;
		_iconImageScaleChip.TargetScale = Vector3.one;
	}

	private float GetPercent()
	{
		if (_gameRuleContext.currentRule.Rule.IsGeneralPve())
		{
			return 0f;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			if (currentWeaponEntity.power.MaxPower < 1)
			{
				return 0f;
			}
			return (float)currentWeaponEntity.power.Power * 1f / (float)currentWeaponEntity.power.MaxPower;
		}
		return 0f;
	}

	private void SetAkHero(AKHeroRecord arg1, AKHeroRecord arg2)
	{
		if (arg2 == null)
		{
			_viewModel.KillCountShow = false;
			return;
		}
		_viewModel.KillCountShow = true;
		IGameRule rule = _gameRuleContext.currentRule.Rule;
		if (rule.IsPve())
		{
			_viewModel.KillCountString = arg2.Pve.Kill.ToString();
		}
		else if (rule.IsBio())
		{
			_viewModel.KillCountString = arg2.Bio.Kill.ToString();
		}
		else
		{
			_viewModel.KillCountString = arg2.Pvp.Kill.ToString();
		}
	}

	private AKHeroRecord GetAkHero()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return null;
		}
		return _weaponContext.currentWeaponEntity.basicInfo.Data.AkHero;
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		_viewModel.RightBottomShow = weaponName != "ak47_hero1" || !_gameRuleContext.currentRule.Rule.IsGeneralPve();
		_viewModel.CommonBackImageShow = _commonBackCanShow && weaponName != "ak47_strike";
		_weaponName = weaponName;
		if (!string.IsNullOrEmpty(_weaponName))
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_weaponName), UiAssetBundleUtils.GetWeaponTexturePath(_weaponName, "bioicon"), delegate(Sprite sprite)
			{
				_viewModel.IconImageSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_weaponName), UiAssetBundleUtils.GetWeaponTexturePath(_weaponName, "bioprogress"), delegate(Sprite sprite)
			{
				_viewModel.ProgressImageSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_weaponName), UiAssetBundleUtils.GetWeaponTexturePath(_weaponName, (_weaponName == "ak47_strike") ? "ak47strikeback" : "ak47heroback"), delegate(Sprite sprite)
			{
				_viewModel.CommonBackImageSprite = sprite;
			});
		}
	}

	private void InitChips()
	{
		_iconImageScaleChip.Scale = new Vector3(1f, 1f, 1f);
		_iconImageScaleChip.TargetScale = new Vector3(1.5f, 1.5f, 1.5f);
		_iconImageScaleChip.Speed = new Vector3(0f, 0f, 0f);
	}

	private void UpdateChips()
	{
		_viewModel.IconImageScale = _iconImageScaleChip.Update(_timeComponent);
	}
}

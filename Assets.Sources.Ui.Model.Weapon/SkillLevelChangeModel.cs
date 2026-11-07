using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class SkillLevelChangeModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetGameRuleContext
{
	private SkillLevelChangeViewModel _viewModel;

	private FrameAnimaChip _effectFrameAnimaChip = new FrameAnimaChip();

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
		_viewModel = new SkillLevelChangeViewModel();
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
		if (!_gameRuleContext.currentRule.Rule.IsPve())
		{
			_viewModel.RightBottomShow = false;
			return;
		}
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetChange, SetChange, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CurrentWeapon_MaxPower2, SetSpecialChange, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunProgress, SetDunProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunVisible, SetDunVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetProgress, SetProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetCanUse, SetCanUse, null, initinvoke: true);
		string weaponName = _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName;
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "normalProgress"), delegate(Sprite sprite)
		{
			_viewModel.ProgressSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillProgressBg"), delegate(Sprite sprite)
		{
			_viewModel.DunSprite = sprite;
		});
	}

	private void SetCanUse(bool arg1, bool arg2)
	{
		_viewModel.SkillBackShow = arg2;
		_viewModel.BackEnabled = !arg2;
	}

	private float GetSkillCd()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return 0f;
		}
		TimeComponent time = Contexts.sharedInstance.time.time;
		return 1f - (float)(currentWeaponEntity.basicInfo.Data.NextSkillTimer - time.ClientRealTime) / 120000f;
	}

	private bool GetCanUse()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return false;
		}
		if (GetSkillCd() < 1f)
		{
			return false;
		}
		if (currentWeaponEntity.power.MaxPower2 == 1)
		{
			if (_gameRuleContext.currentRule.Rule.IsGeneralPve())
			{
				if (10 + currentWeaponEntity.power.MaxPower * 5 / 100 <= _gameRuleContext.tdSkillStateData.CurrentMp)
				{
					return true;
				}
			}
			else if (currentWeaponEntity.power.Power >= 20)
			{
				return true;
			}
		}
		else if (_gameRuleContext.currentRule.Rule.IsGeneralPve())
		{
			if (1 + currentWeaponEntity.power.MaxPower * 2 / 100 <= _gameRuleContext.tdSkillStateData.CurrentMp)
			{
				return true;
			}
		}
		else if (1 + currentWeaponEntity.power.MaxPower * 2 / 100 <= currentWeaponEntity.power.Power)
		{
			return true;
		}
		return false;
	}

	private void SetProgress(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount = arg2;
	}

	private float GetProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower || currentWeaponEntity.power.MaxPower <= 0)
		{
			return 0f;
		}
		if (_gameRuleContext.currentRule.Rule.IsGeneralPve())
		{
			return (float)_gameRuleContext.tdSkillStateData.CurrentMp / (float)currentWeaponEntity.power.MaxPower;
		}
		return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
	}

	private void SetDunVisible(bool arg1, bool arg2)
	{
		_viewModel.DunShow = arg2;
	}

	private bool GetDunVisible()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			return currentWeaponEntity.basicInfo.Data.WeaponName != "dagger_bullet_burster";
		}
		return false;
	}

	private void SetDunProgress(float arg1, float arg2)
	{
		_viewModel.DunProgressFillamount = arg2;
		_viewModel.EffectPosition = new Vector3(-42f + 82f * arg2, 0f);
	}

	private float GetDunProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || currentWeaponEntity.basicInfo.Data.WeaponName == "dagger_bullet_burster")
		{
			return 0f;
		}
		int num = 14;
		int num2 = currentWeaponEntity.basicInfo.Data.Level;
		if (num2 > num)
		{
			num2 -= num;
			num = 20;
		}
		return (float)num2 / (float)num;
	}

	private void SetChange(int arg1, int arg2)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			string weaponName = currentWeaponEntity.basicInfo.Data.WeaponName;
			switch (arg2)
			{
			case 3:
				_viewModel.EffectShow = true;
				_effectFrameAnimaChip.Path = "progressFxRed";
				break;
			case 2:
				_viewModel.EffectShow = true;
				_effectFrameAnimaChip.Path = "progressFxYellow";
				break;
			default:
				_viewModel.EffectShow = false;
				break;
			}
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "skillProgress" + arg2), delegate(Sprite sprite)
			{
				_viewModel.DunProgressSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "unactiveBg"), delegate(Sprite sprite)
			{
				_viewModel.BackSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "activeBg"), delegate(Sprite sprite)
			{
				_viewModel.SkillBackSprite = sprite;
			});
		}
	}

	private void SetSpecialChange(int arg1, int arg2)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		string weaponName = currentWeaponEntity.basicInfo.Data.WeaponName;
		if (!(weaponName == "dagger_bullet_burster2"))
		{
			return;
		}
		if (currentWeaponEntity.hasPower && currentWeaponEntity.power.MaxPower2 == 0)
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "unactiveBg_pve"), delegate(Sprite sprite)
			{
				_viewModel.BackSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "activeBg_pve"), delegate(Sprite sprite)
			{
				_viewModel.SkillBackSprite = sprite;
			});
		}
		else
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "unactiveBg_special"), delegate(Sprite sprite)
			{
				_viewModel.BackSprite = sprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "activeBg_special"), delegate(Sprite sprite)
			{
				_viewModel.SkillBackSprite = sprite;
			});
		}
	}

	private int GetChange()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			if (currentWeaponEntity.basicInfo.Data.Level >= 35)
			{
				return 3;
			}
			if (currentWeaponEntity.basicInfo.Data.Level > 14)
			{
				return 2;
			}
		}
		return 1;
	}

	private void InitChips()
	{
		_effectFrameAnimaChip.IsLoop = true;
		_effectFrameAnimaChip.Count = 8;
		_effectFrameAnimaChip.Extension = "";
	}

	private void UpdateChips()
	{
		if (_viewModel.RightBottomShow && _viewModel.EffectShow)
		{
			_effectFrameAnimaChip.Update(_timeComponent);
			string weaponName = _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName;
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, _effectFrameAnimaChip.Value), delegate(Sprite sprite)
			{
				_viewModel.EffectSprite = sprite;
			});
		}
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

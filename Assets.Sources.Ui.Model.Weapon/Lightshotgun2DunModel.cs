using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class Lightshotgun2DunModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetGameRuleContext, ISetPlayerContext
{
	private Lightshotgun2DunViewModel _viewModel;

	private WeaponContext _weaponContext;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private bool isSpecial;

	private int COMPONENT_1 = 4;

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
		_viewModel = new Lightshotgun2DunViewModel();
	}

	private float GetDunProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasClip)
		{
			return 0f;
		}
		return (float)currentWeaponEntity.clip.Clip2 / (float)currentWeaponEntity.clip.CarryClip2;
	}

	private void SetDunProgress(float arg1, float arg2)
	{
		_viewModel.DunProgressFillamount = arg2;
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!GetSpecialMode())
		{
			base.Loader.RetriveSprite("weapon/dawn_light_shotgun2", "Assets/Res/Assets/weapon/dawn_light_shotgun2/ui/unactiveBg.png", delegate(Sprite sprite)
			{
				_viewModel.SkillbgSprite = sprite;
			});
			base.Loader.RetriveSprite("weapon/dawn_light_shotgun2", "Assets/Res/Assets/weapon/dawn_light_shotgun2/ui/activeBg.png", delegate(Sprite sprite)
			{
				_viewModel.SkillBackSprite = sprite;
			});
		}
		else if (!GetRule())
		{
			base.Loader.RetriveSprite("weapon/dawn_light_shotgun2", "Assets/Res/Assets/weapon/dawn_light_shotgun2/ui/unactiveBg.png", delegate(Sprite sprite)
			{
				_viewModel.SkillbgSprite = sprite;
			});
			base.Loader.RetriveSprite("weapon/dawn_light_shotgun2", "Assets/Res/Assets/weapon/dawn_light_shotgun2/ui/activeBg.png", delegate(Sprite sprite)
			{
				_viewModel.SkillBackSprite = sprite;
			});
		}
		else
		{
			base.Loader.RetriveSprite("weapon/dawn_light_shotgun2", "Assets/Res/Assets/weapon/dawn_light_shotgun2/ui/unactiveBg_pve.png", delegate(Sprite sprite)
			{
				_viewModel.SkillbgSprite = sprite;
			});
			base.Loader.RetriveSprite("weapon/dawn_light_shotgun2", "Assets/Res/Assets/weapon/dawn_light_shotgun2/ui/activeBg_pve.png", delegate(Sprite sprite)
			{
				_viewModel.SkillBackSprite = sprite;
			});
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetDunProgress, SetDunProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetProgress, SetProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetCanUse, SetCanUse, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetSpecialMode, SetSpecialMode, null, initinvoke: true);
		if (!RuleUtilty.IsPveModel(UiIEventCondition.Get_uiRoomData_RaceType()))
		{
			_viewModel.RightBottomShow = false;
		}
	}

	private bool GetSpecialMode()
	{
		if (_weaponContext.currentWeaponEntity == null || !_weaponContext.currentWeaponEntity.hasBasicInfo)
		{
			return false;
		}
		if (_weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName == "dawn_light_shotgun2")
		{
			if ((_weaponContext.currentWeaponEntity.basicInfo.Data.EffectLevel & COMPONENT_1) > 0)
			{
				return true;
			}
			return false;
		}
		return _weaponContext.currentWeaponEntity.basicInfo.Data.SpecialMode;
	}

	private void SetSpecialMode(bool arg1, bool arg2)
	{
	}

	private bool GetRule()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if ((RuleUtilty.IsGeneralPve(UiIEventCondition.Get_uiRoomData_RaceType()) && currentWeaponEntity.power.RpgMaxPower != 0) || currentWeaponEntity.basicInfo.Data.WeaponName == "dawn_light_shotgun2")
		{
			return true;
		}
		return false;
	}

	private void SetCanUse(bool arg1, bool arg2)
	{
		_viewModel.SkillbgShow = !arg2;
		_viewModel.SkillBackShow = arg2;
	}

	private bool GetCanUse()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		int num = 0;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo && currentWeaponEntity.hasPower && currentWeaponEntity.basicInfo.Data.WeaponName == "dawn_light_shotgun2")
		{
			num = (int)currentWeaponEntity.basicInfo.Data.NextSkillTimer - _playerContext.myPlayerEntity.clientTime.ClientTime;
			if (1 - num / 1 >= 1)
			{
				if (RuleUtilty.IsGeneralPve(UiIEventCondition.Get_uiRoomData_RaceType()) && (double)_gameRuleContext.tdSkillStateData.CurrentMp * 1.0 > (double)currentWeaponEntity.power.MaxPower)
				{
					return true;
				}
				if (RuleUtilty.IsOldPve(UiIEventCondition.Get_uiRoomData_RaceType()) && currentWeaponEntity.power.Power > currentWeaponEntity.power.MaxPower2)
				{
					return true;
				}
			}
			return false;
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
		if (RuleUtilty.IsGeneralPve(UiIEventCondition.Get_uiRoomData_RaceType()))
		{
			return (float)_gameRuleContext.tdSkillStateData.CurrentMp / (float)currentWeaponEntity.power.MaxPower2;
		}
		return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}

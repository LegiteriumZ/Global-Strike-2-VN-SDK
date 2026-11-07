using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class SkillCountDownModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetGameRuleContext, ISetPlayerContext
{
	private SkillCountDownViewModel _viewModel;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	private TimeContext _timeContext;

	private GameRuleContext _gameRuleContext;

	private int _raceType;

	private List<string> _weaponList = new List<string>();

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
		_weaponList.Add("shotgun_walker");
		_weaponList.Add("void_link");
		_weaponList.Add("phase_walker");
		_weaponList.Add("phase_walker1");
		_weaponList.Add("phase_walker2");
		_weaponList.Add("double_blade");
		_weaponList.Add("thunder_scepter");
		_weaponList.Add("mirage_dou_blade");
		_weaponList.Add("data_cube");
		_weaponList.Add("data_cube1");
		_weaponList.Add("data_cube2");
		_weaponList.Add("endless_machinegun");
		_weaponList.Add("end_bow");
	}

	public override void CreateViewModel()
	{
		_viewModel = new SkillCountDownViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null)
		{
			_ = _viewModel.IsInited;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.RightBottomShow = false;
		_raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		_timeContext = Contexts.sharedInstance.time;
		NotifyManager.MakeTempNotifyClass(GetWeaponName, SetWeaponUi, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunShow, SetDunShow, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunProgress, SetDunProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPowerNum, SetPowerNum, null, initinvoke: true);
	}

	private string GetWeaponName()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo && _weaponList.Contains(currentWeaponEntity.basicInfo.Info.Name))
		{
			return currentWeaponEntity.basicInfo.Info.Name;
		}
		return null;
	}

	private void SetWeaponUi(string arg1, string arg2)
	{
		if (!string.IsNullOrEmpty(arg2))
		{
			SetUi();
			if (arg2.Equals("thunder_scepter"))
			{
				_viewModel.DunProgressAnchoredposition = new Vector2(12f, 0f);
			}
			else if (arg2.Equals("mirage_dou_blade"))
			{
				_viewModel.DunProgressAnchoredposition = new Vector2(12f, -4f);
			}
			else if (arg2.Equals("data_cube") || arg2.Equals("data_cube1") || arg2.Equals("data_cube2"))
			{
				_viewModel.DunProgressAnchoredposition = new Vector2(10f, -2f);
			}
			else if (arg2.Equals("endless_machinegun"))
			{
				_viewModel.DunProgressAnchoredposition = new Vector2(15.5f, -3f);
			}
			else
			{
				_viewModel.DunProgressAnchoredposition = new Vector2(12f, -1f);
			}
			WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
			if (currentWeaponEntity.basicInfo.Info.Name.Equals("shotgun_walker") || currentWeaponEntity.basicInfo.Info.Name.Equals("void_link"))
			{
				_viewModel.PowerNumShow = true;
			}
			else
			{
				_viewModel.PowerNumShow = false;
			}
		}
	}

	private int GetPowerNum()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && (currentWeaponEntity.basicInfo.Info.Name == "shotgun_walker" || currentWeaponEntity.basicInfo.Info.Name == "void_link"))
		{
			if (!currentWeaponEntity.hasPower && currentWeaponEntity.power.Power2 != 0)
			{
				return 0;
			}
			return currentWeaponEntity.power.Power2;
		}
		return 0;
	}

	private void SetPowerNum(int arg1, int arg2)
	{
		_viewModel.PowerNumString = StringCache.IntToString(arg2);
	}

	private void SetUi()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo)
		{
			base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/progressBg.png", delegate(Sprite sprite)
			{
				_viewModel.dunSprite = sprite;
				_viewModel.dunNtvsize();
			});
			base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/progress.png", delegate(Sprite sprite)
			{
				_viewModel.DunProgressSprite = sprite;
				_viewModel.DunProgressNtvsize();
			});
		}
	}

	private bool GetDunShow()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo)
		{
			if (currentWeaponEntity.basicInfo.Info.Name == "phase_walker" || currentWeaponEntity.basicInfo.Info.Name == "phase_walker1" || currentWeaponEntity.basicInfo.Info.Name == "phase_walker2")
			{
				if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.MaxPower2 == 0)
				{
					return false;
				}
				return (float)currentWeaponEntity.power.Power2 / (float)currentWeaponEntity.power.MaxPower2 > 0f;
			}
			if (currentWeaponEntity.basicInfo.Info.Name == "shotgun_walker")
			{
				if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.MaxPower == 0)
				{
					return false;
				}
				return (float)currentWeaponEntity.clip.Clip2 / (float)currentWeaponEntity.power.MaxPower > 0f;
			}
			if (currentWeaponEntity.basicInfo.Info.Name == "void_link")
			{
				if (RuleUtilty.IsExplode(_raceType))
				{
					return false;
				}
				if (!currentWeaponEntity.hasPower)
				{
					return false;
				}
				if (currentWeaponEntity.power.Power2 > 0)
				{
					return true;
				}
				if (currentWeaponEntity.power.MaxPower != 0 && 1f * (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower > 0f)
				{
					return true;
				}
				return false;
			}
			if (currentWeaponEntity.basicInfo.Info.Name == "double_blade")
			{
				if (!currentWeaponEntity.hasPower || (currentWeaponEntity.power.MaxPower == 0 && currentWeaponEntity.power.MaxPower2 == 0))
				{
					return false;
				}
				if (currentWeaponEntity.hasPower && currentWeaponEntity.power.Power > 0 && _viewModel.DunProgressSprite.name != "progressBlue")
				{
					base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/progressBlue.png", delegate(Sprite sprite)
					{
						_viewModel.DunProgressSprite = sprite;
						_viewModel.DunProgressNtvsize();
					});
				}
				else if (currentWeaponEntity.hasPower && currentWeaponEntity.power.Power2 > 0 && _viewModel.DunProgressSprite.name != "progressRed")
				{
					base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/progressRed.png", delegate(Sprite sprite)
					{
						_viewModel.DunProgressSprite = sprite;
						_viewModel.DunProgressNtvsize();
					});
				}
				if (currentWeaponEntity.power.Power <= 0)
				{
					return currentWeaponEntity.power.Power2 > 0;
				}
				return true;
			}
			if (currentWeaponEntity.basicInfo.Info.Name == "thunder_scepter" && (RuleUtilty.IsPveModel(_raceType) || RuleUtilty.IsBioMode(_raceType) || RuleUtilty.IsBigHeadModel(_raceType) || RuleUtilty.isMechKingMode(_raceType)) && currentWeaponEntity.hasPower && currentWeaponEntity.power.RpgMaxPower > 0 && GetDunProgress() > 0f)
			{
				return true;
			}
			if (currentWeaponEntity.basicInfo.Info.Name == "mirage_dou_blade" && (currentWeaponEntity.special.EffectLevel & 8) > 0 && GetDunProgress() > 0f)
			{
				return true;
			}
			if ((currentWeaponEntity.basicInfo.Info.Name == "data_cube" || currentWeaponEntity.basicInfo.Info.Name == "data_cube1" || currentWeaponEntity.basicInfo.Info.Name == "data_cube2") && (RuleUtilty.IsPveModel(_raceType) || RuleUtilty.IsBioMode(_raceType) || RuleUtilty.IsBigHeadModel(_raceType)) && GetDunProgress() > 0f)
			{
				return true;
			}
			if (currentWeaponEntity.basicInfo.Info.Name == "endless_machinegun")
			{
				if (currentWeaponEntity.hasPower && currentWeaponEntity.power.Power >= 100 && _viewModel.DunProgressSprite.name != "skillProgress")
				{
					base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/skillProgress.png", delegate(Sprite sprite)
					{
						_viewModel.DunProgressSprite = sprite;
						_viewModel.DunProgressNtvsize();
					});
					base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/skillBg.png", delegate(Sprite sprite)
					{
						_viewModel.dunSprite = sprite;
						_viewModel.dunNtvsize();
					});
				}
				else if (currentWeaponEntity.hasPower && currentWeaponEntity.power.Power < 100 && _viewModel.DunProgressSprite.name != "skillProgressBlue")
				{
					base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/skillProgressBlue.png", delegate(Sprite sprite)
					{
						_viewModel.DunProgressSprite = sprite;
						_viewModel.DunProgressNtvsize();
					});
					base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/skillBgBlue.png", delegate(Sprite sprite)
					{
						_viewModel.dunSprite = sprite;
						_viewModel.dunNtvsize();
					});
				}
				if (currentWeaponEntity.hasSpecial && (currentWeaponEntity.special.EffectLevel & 0x10) > 0 && GetDunProgress() > 0f)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void SetDunShow(bool arg1, bool arg2)
	{
		_viewModel.RightBottomShow = arg2;
	}

	private float GetDunProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return 0f;
		}
		if (currentWeaponEntity.hasBasicInfo && (currentWeaponEntity.basicInfo.Info.Name == "phase_walker" || currentWeaponEntity.basicInfo.Info.Name == "phase_walker1" || currentWeaponEntity.basicInfo.Info.Name == "phase_walker2"))
		{
			if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.MaxPower2 == 0)
			{
				return 0f;
			}
			return (float)currentWeaponEntity.power.Power2 / (float)currentWeaponEntity.power.MaxPower2;
		}
		if (currentWeaponEntity.basicInfo.Info.Name == "shotgun_walker")
		{
			if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.MaxPower == 0)
			{
				return 0f;
			}
			return (float)currentWeaponEntity.clip.Clip2 / (float)currentWeaponEntity.power.MaxPower;
		}
		if (currentWeaponEntity.basicInfo.Info.Name == "void_link")
		{
			if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.MaxPower == 0)
			{
				return 0f;
			}
			return 1f * (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
		}
		if (currentWeaponEntity.basicInfo.Info.Name == "double_blade")
		{
			if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.MaxPower == 0)
			{
				return 0f;
			}
			if (currentWeaponEntity.power.Power > 0)
			{
				return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
			}
			if (currentWeaponEntity.power.Power2 > 0)
			{
				return (float)currentWeaponEntity.power.Power2 / (float)currentWeaponEntity.power.MaxPower2;
			}
		}
		if (currentWeaponEntity.basicInfo.Info.Name == "thunder_scepter")
		{
			if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.RpgMaxPower == 0 || !currentWeaponEntity.hasClip)
			{
				return 0f;
			}
			return (float)currentWeaponEntity.clip.Clip2 * 1f / (float)currentWeaponEntity.power.RpgMaxPower;
		}
		if (currentWeaponEntity.basicInfo.Info.Name == "mirage_dou_blade" && currentWeaponEntity.hasPower)
		{
			return (float)Mathf.Clamp(currentWeaponEntity.power.MaxPower2 - _timeContext.time.ServerTime, 0, 8000) / 8000f;
		}
		if ((currentWeaponEntity.basicInfo.Info.Name == "data_cube" || currentWeaponEntity.basicInfo.Info.Name == "data_cube1" || currentWeaponEntity.basicInfo.Info.Name == "data_cube2") && currentWeaponEntity.hasPower)
		{
			return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.MaxPower;
		}
		if (currentWeaponEntity.basicInfo.Info.Name == "endless_machinegun" && currentWeaponEntity.hasPower)
		{
			return (float)currentWeaponEntity.power.Power * 1f / 100f;
		}
		return 0f;
	}

	private void SetDunProgress(float arg1, float arg2)
	{
		_viewModel.DunProgressFillamount = arg2;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}

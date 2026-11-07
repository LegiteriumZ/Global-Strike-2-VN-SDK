using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class VoidJumpModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private VoidJumpViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int _raceType;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		_raceType = context.roomData.Data.RaceType;
	}

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
		_viewModel = new VoidJumpViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.MessageShow = false;
		_viewModel.SkillShow = false;
		if (RuleUtilty.IsBioMode(_raceType) || RuleUtilty.IsBigHeadModel(_raceType) || RuleUtilty.IsPveModel(_raceType))
		{
			_viewModel.RightBottomShow = true;
			if (_weaponContext.currentWeaponEntity != null)
			{
				if ((_weaponContext.currentWeaponEntity.special.EffectLevel & 4) > 0)
				{
					_viewModel.SkillShow = true;
				}
				else
				{
					_viewModel.SkillShow = false;
				}
			}
		}
		else
		{
			_viewModel.RightBottomShow = false;
		}
		NotifyManager.MakeTempNotify(GetProgressMaxPower, SetProgressMaxPower, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetProgressPower2, SetDunProgressPower2, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunPowerText, SetDunPowerText, null, initinvoke: true);
	}

	private float GetDunPowerText()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		return currentWeaponEntity.power.Power;
	}

	private void SetDunPowerText(float arg1, float arg2)
	{
		if (arg2 == 0f)
		{
			_viewModel.MessageShow = false;
		}
		if (arg2 == 1f)
		{
			_viewModel.MessageShow = true;
			base.Loader.RetriveSprite("weapon/void_jump", "Assets/Res/Assets/weapon/void_jump/ui/skill2.png", delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
			});
		}
		if (arg2 == 2f)
		{
			_viewModel.MessageShow = true;
			base.Loader.RetriveSprite("weapon/void_jump", "Assets/Res/Assets/weapon/void_jump/ui/skill1.png", delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
			});
		}
		if (arg2 == 3f)
		{
			_viewModel.MessageShow = true;
			base.Loader.RetriveSprite("weapon/void_jump", "Assets/Res/Assets/weapon/void_jump/ui/skill3.png", delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
			});
		}
		if (arg2 == 4f)
		{
			_viewModel.MessageShow = true;
			base.Loader.RetriveSprite("weapon/void_jump", "Assets/Res/Assets/weapon/void_jump/ui/skill4.png", delegate(Sprite sprite)
			{
				_viewModel.MessageSprite = sprite;
			});
		}
	}

	private float GetProgressPower2()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		return currentWeaponEntity.power.Power2;
	}

	private void SetDunProgressPower2(float arg1, float arg2)
	{
		if (arg2 == 0f)
		{
			_viewModel.dunShow = false;
		}
		else
		{
			_viewModel.dunShow = true;
		}
		if (arg2 > 0f)
		{
			_viewModel.DunProgressFillamount = arg2 / 100f;
			base.Loader.RetriveSprite("weapon/void_jump", "Assets/Res/Assets/weapon/void_jump/ui/skillProgressBlue.png", delegate(Sprite sprite)
			{
				_viewModel.DunProgressSprite = sprite;
				_viewModel.DunProgressNtvsize();
			});
		}
		if (arg2 < 0f && arg2 != -100f)
		{
			_viewModel.DunProgressFillamount = arg2 / -100f;
			base.Loader.RetriveSprite("weapon/void_jump", "Assets/Res/Assets/weapon/void_jump/ui/skillProgressRed.png", delegate(Sprite sprite)
			{
				_viewModel.DunProgressSprite = sprite;
				_viewModel.DunProgressNtvsize();
			});
		}
		if (arg2 == -100f)
		{
			_viewModel.dunShow = false;
		}
	}

	private float GetProgressMaxPower()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		return currentWeaponEntity.power.MaxPower;
	}

	private void SetProgressMaxPower(float arg1, float arg2)
	{
		if (arg2 == -1f || arg2 != 100f)
		{
			_viewModel.SkillBackShow = false;
		}
		else
		{
			_viewModel.SkillBackShow = true;
		}
		if (arg2 == -1f)
		{
			_viewModel.ProgressFillamount = 0f;
		}
		else
		{
			_viewModel.ProgressFillamount = arg2 / 100f;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}

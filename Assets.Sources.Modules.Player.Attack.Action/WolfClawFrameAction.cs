using System;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;
using math;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class WolfClawFrameAction : IFrameCmdAction, ICmdAction
{
	private readonly WolfClawKnifeRightAction _rightAction;

	private readonly WolfClawDoubleAttackAction _doubeAction;

	public WolfClawFrameAction(Contexts contexts)
	{
		_rightAction = new WolfClawKnifeRightAction(contexts);
		_doubeAction = new WolfClawDoubleAttackAction(contexts);
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			arg.CurrentWeapon.special.EffectLevel = 0;
			arg.CurrentWeapon.power.Power2 = 0;
			arg.CurrentWeapon.power.MaxPower2 = 0;
		}
		if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
		{
			return false;
		}
		if (!arg.CurrentWeapon.special.SpecialMode && arg.Cmd.IsSecondaryAttackOn)
		{
			arg.CurrentWeapon.special.SpecialMode = true;
			arg.CurrentWeapon.special.EffectLevel = 0;
			arg.CurrentWeapon.special.Level = arg.ClientTime + 200;
			arg.CurrentWeapon.power.MaxPower2 = arg.CurrentWeapon.special.Level;
		}
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if (arg.CurrentWeapon.special.EffectLevel == 0)
			{
				if (!arg.Cmd.IsSecondaryAttackOn)
				{
					arg.CurrentWeapon.special.EffectLevel = 0;
					arg.CurrentWeapon.special.SpecialMode = false;
					RightAttack(ref arg);
				}
				else if (arg.ClientTime > arg.CurrentWeapon.special.Level)
				{
					arg.CurrentWeapon.special.EffectLevel = 1;
					EnterDoubleStep(arg.CurrentWeapon, arg.Cmd, arg.CurrentWeapon.special.EffectLevel, arg.ClientTime);
				}
			}
			if (IsInDoubleHit(arg.Player))
			{
				if (arg.Player.viewAnim.RemainTime < 50 && arg.ClientTime > arg.CurrentWeapon.power.MaxPower2)
				{
					FailDoubleHit(ref arg);
				}
			}
			else if (arg.CurrentWeapon.special.EffectLevel >= 1 && arg.ClientTime - arg.CurrentWeapon.power.MaxPower2 > 100)
			{
				FailDoubleHit(ref arg);
				RightAttack(ref arg);
			}
			if ((arg.CurrentWeapon.special.EffectLevel == 1 && !arg.Cmd.IsSecondaryAttackOn) || (arg.CurrentWeapon.special.EffectLevel > 1 && arg.Cmd.IsSecondaryAttackOn))
			{
				WolfClawConfig doubleConfigByHitidx = GetDoubleConfigByHitidx(arg.CurrentWeapon, arg.CurrentWeapon.special.EffectLevel);
				if (doubleConfigByHitidx == null)
				{
					return false;
				}
				if (Math.Abs(arg.ClientTime - arg.CurrentWeapon.special.Level + doubleConfigByHitidx.Offset) > doubleConfigByHitidx.Pardon)
				{
					FailDoubleHit(ref arg);
					RightAttack(ref arg);
				}
				else
				{
					arg.CurrentWeapon.special.EffectLevel++;
					DoubleAttack(ref arg);
					EnterDoubleStep(arg.CurrentWeapon, arg.Cmd, arg.CurrentWeapon.special.EffectLevel, arg.ClientTime);
				}
			}
		}
		return true;
	}

	private bool IsInDoubleHit(PlayerEntity player)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(player, 40) && !PlayerAnimationUtility.IsViewAnimEqual(player, 71))
		{
			return PlayerAnimationUtility.IsViewAnimEqual(player, 72);
		}
		return true;
	}

	private void FailDoubleHit(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.special.SpecialMode = false;
		arg.CurrentWeapon.special.EffectLevel = 0;
		arg.CurrentWeapon.power.Power2 = 0;
		arg.CurrentWeapon.power.MaxPower2 = 0;
	}

	private void EnterDoubleStep(WeaponEntity currentWeapon, IUserCmd cmd, int idx, int clientTime)
	{
		WolfClawConfig doubleConfigByHitidx = GetDoubleConfigByHitidx(currentWeapon, idx);
		if (doubleConfigByHitidx == null)
		{
			currentWeapon.special.Level = 0;
			currentWeapon.power.Power2 = 0;
			currentWeapon.power.MaxPower2 = 0;
		}
		else
		{
			currentWeapon.special.Level = clientTime + UniformRandom.RandomInt(cmd.Seq, doubleConfigByHitidx.Min, doubleConfigByHitidx.Max);
			currentWeapon.power.Power2 = clientTime;
			currentWeapon.power.MaxPower2 = clientTime + doubleConfigByHitidx.Max + 100;
		}
	}

	protected void DoubleAttack(ref CommonWeaponArg arg)
	{
		_doubeAction.Action(ref arg);
	}

	public static WolfClawConfig GetDoubleConfigByHitidx(WeaponEntity currentWeapon, int hit)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		WolfClawConfig[] doubleConfigs = WolfClawConfig.GetDoubleConfigs(currentWeapon, raceType);
		foreach (WolfClawConfig wolfClawConfig in doubleConfigs)
		{
			if (hit >= wolfClawConfig.MinCount && hit <= wolfClawConfig.MaxCount)
			{
				return wolfClawConfig;
			}
		}
		return null;
	}

	public static int GetWolfClawDoubleLevel(WeaponEntity currentWeapon)
	{
		return GetDoubleConfigByHitidx(currentWeapon, currentWeapon.special.EffectLevel - 1)?.Effect ?? 0;
	}

	public static int GetWolfClawDoublePct(WeaponEntity currentWeapon)
	{
		if (currentWeapon.special.Level > currentWeapon.power.Power2 && currentWeapon.special.Level < currentWeapon.power.MaxPower2)
		{
			return (currentWeapon.special.Level - currentWeapon.power.Power2) * 1000 / (currentWeapon.power.MaxPower2 - currentWeapon.power.Power2);
		}
		return 0;
	}

	public static int GetWolfClawDoublePctNow(WeaponEntity currentWeapon, int clientTime)
	{
		if (clientTime > currentWeapon.power.Power2 && clientTime < currentWeapon.power.MaxPower2)
		{
			return (clientTime - currentWeapon.power.Power2) * 1000 / (currentWeapon.power.MaxPower2 - currentWeapon.power.Power2);
		}
		return 0;
	}

	protected void RightAttack(ref CommonWeaponArg arg)
	{
		_rightAction.Action(ref arg);
	}
}

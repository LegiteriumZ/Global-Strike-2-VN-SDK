using System;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Ak47UniqueFrameAction : AbstractFrameAction
{
	public static int AK47_ATTACK_INTERVAL = 100;

	public static float AK47_RANGE_MODIFIER = 0.98f;

	public static float AK47_PIERCE = 0.8f;

	public static float AK47_SPREAD_SCALEY = 0.4f;

	public static float AK47_DAMAGE_MODIFIER = 0.75f;

	public static float AK47_PENETRATIONPOWER = 110f;

	public static float AK47_DEFAULTACCURACY = 0.2f;

	public static float AK47_ACCURACY = 0.2f;

	public static float AK47_ACCURACYDIVISOR = 250f;

	public static float AK47_ACCURACYOFFSET = 0.35f;

	public static float AK47_MAXINACCURACY = 1.25f;

	public static int G18_ATTACK_INTERVAL = 100;

	public static float G18_RANGE_MODIFIER = 0.8f;

	public static float G18_PIERCE = 0.78f;

	public static float G18_SPREAD_SCALEY = 1f;

	public static float G18_DAMAGE_MODIFIER = 0.6f;

	public static float G18_PENETRATIONPOWER = 90f;

	public static float G18_DEFAULTACCURACY = 0.9f;

	public static float G18_ACCURACY = 0.9f;

	public static float G18_ACCURACYDIVISOR = -1f;

	public static float G18_ACCURACYOFFSET = 0f;

	public static float G18_MAXINACCURACY = 0f;

	private readonly int ENABLE_ATTACH = 32;

	private void ForeUpdatePara(ref CommonWeaponArg commonWeaponArg)
	{
		if (commonWeaponArg.CurrentWeapon.special.SpecialMode)
		{
			if ((double)Math.Abs(commonWeaponArg.CurrentWeapon.basicInfo.Info.MaxInaccuracy - AK47_MAXINACCURACY) < 0.01)
			{
				changeParasToSpecial(commonWeaponArg.CurrentWeapon);
			}
		}
		else if ((double)Math.Abs(commonWeaponArg.CurrentWeapon.basicInfo.Info.MaxInaccuracy - G18_MAXINACCURACY) < 0.01)
		{
			changeParasToNormal(commonWeaponArg.CurrentWeapon);
		}
	}

	private void CheckChangeAttachMode(WeaponEntity argCurrentWeapon, PlayerEntity argPlayer, IUserCmd cmd)
	{
		if (IsEnableAttachFire(argCurrentWeapon))
		{
			if (isNeedAutoChangeMode(argCurrentWeapon, cmd))
			{
				ChangeSpecialMode(argPlayer, argCurrentWeapon);
			}
			if (cmd.IsShowGun)
			{
				ChangeSpecialMode(argPlayer, argCurrentWeapon);
			}
		}
	}

	private bool isNeedAutoChangeMode(WeaponEntity argCurrentWeapon, IUserCmd cmd)
	{
		if (!argCurrentWeapon.special.SpecialMode && cmd.IsAttackOn && argCurrentWeapon.clip.Clip <= 0)
		{
			return argCurrentWeapon.clip.Clip2 + argCurrentWeapon.clip.CarryClip2 > 0;
		}
		return false;
	}

	private void ChangeSpecialMode(PlayerEntity player, WeaponEntity argCurrentWeapon)
	{
		if (player.viewAnim.ViewAnimInfo.StateId != 37 && player.viewAnim.ViewAnimInfo.StateId != 36)
		{
			if (argCurrentWeapon.special.SpecialMode)
			{
				exchangeClipAndClip2(argCurrentWeapon);
				changeParasToNormal(argCurrentWeapon);
				argCurrentWeapon.special.SpecialMode = false;
				PlayerAnimationUtility.SetViewAnimation(player, 37);
			}
			else
			{
				exchangeClipAndClip2(argCurrentWeapon);
				changeParasToSpecial(argCurrentWeapon);
				argCurrentWeapon.special.SpecialMode = true;
				PlayerAnimationUtility.SetViewAnimation(player, 36);
			}
		}
	}

	private void changeParasToSpecial(WeaponEntity argCurrentWeapon)
	{
		argCurrentWeapon.basicInfo.Info.AttackInterval = G18_ATTACK_INTERVAL;
		argCurrentWeapon.basicInfo.Info.SpreadScaleY = G18_SPREAD_SCALEY;
		argCurrentWeapon.basicInfo.Info.DefaultAccuracy = G18_DEFAULTACCURACY;
		argCurrentWeapon.basicInfo.Info.AccuracyDivisor = G18_ACCURACYDIVISOR;
		argCurrentWeapon.basicInfo.Info.AccuracyOffset = G18_ACCURACYOFFSET;
		argCurrentWeapon.basicInfo.Info.MaxInaccuracy = G18_MAXINACCURACY;
		argCurrentWeapon.accuracy.Accuracy = G18_ACCURACY;
		argCurrentWeapon.spread.SpreadScaleY = G18_SPREAD_SCALEY;
	}

	private void changeParasToNormal(WeaponEntity argCurrentWeapon)
	{
		argCurrentWeapon.basicInfo.Info.AttackInterval = AK47_ATTACK_INTERVAL;
		argCurrentWeapon.basicInfo.Info.SpreadScaleY = AK47_SPREAD_SCALEY;
		argCurrentWeapon.basicInfo.Info.DefaultAccuracy = AK47_DEFAULTACCURACY;
		argCurrentWeapon.basicInfo.Info.AccuracyDivisor = AK47_ACCURACYDIVISOR;
		argCurrentWeapon.basicInfo.Info.AccuracyOffset = AK47_ACCURACYOFFSET;
		argCurrentWeapon.basicInfo.Info.MaxInaccuracy = AK47_MAXINACCURACY;
		argCurrentWeapon.accuracy.Accuracy = AK47_ACCURACY;
		argCurrentWeapon.spread.SpreadScaleY = AK47_SPREAD_SCALEY;
	}

	private void exchangeClipAndClip2(WeaponEntity argCurrentWeapon)
	{
		int clip = argCurrentWeapon.clip.Clip;
		int maxClip = argCurrentWeapon.clip.MaxClip;
		int carryClip = argCurrentWeapon.clip.CarryClip;
		int maxCarryClip = argCurrentWeapon.clip.MaxCarryClip;
		argCurrentWeapon.clip.Clip = argCurrentWeapon.clip.Clip2;
		argCurrentWeapon.clip.MaxClip = argCurrentWeapon.power.Power2;
		argCurrentWeapon.clip.CarryClip = argCurrentWeapon.clip.CarryClip2;
		argCurrentWeapon.clip.MaxCarryClip = argCurrentWeapon.power.MaxPower2;
		argCurrentWeapon.clip.Clip2 = clip;
		argCurrentWeapon.power.Power2 = maxClip;
		argCurrentWeapon.clip.CarryClip2 = carryClip;
		argCurrentWeapon.power.MaxPower2 = maxCarryClip;
	}

	private bool IsEnableAttachFire(WeaponEntity weapon)
	{
		return (weapon.special.EffectLevel & ENABLE_ATTACH) > 0;
	}

	public int frameCheck(ref CommonWeaponArg arg)
	{
		CheckChangeAttachMode(arg.CurrentWeapon, arg.Player, arg.Cmd);
		ForeUpdatePara(ref arg);
		return 0;
	}

	public Ak47UniqueFrameAction(Contexts contexts)
		: base(contexts)
	{
		AddFrameAction(frameCheck);
	}

	public Ak47UniqueFrameAction(Contexts contexts, IIdleCmdAction action)
		: base(contexts, action)
	{
	}
}

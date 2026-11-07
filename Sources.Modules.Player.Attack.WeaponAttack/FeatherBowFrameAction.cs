using System;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class FeatherBowFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public FeatherBowFrameAction(Contexts contexts)
		: base(contexts)
	{
		_contexts = contexts;
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		Fire(ref arg);
		FovControll(ref arg);
		DelayFireFrame(ref arg);
		ShowWeapon(ref arg);
		return true;
	}

	private void ShowWeapon(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun && !arg.CurrentWeapon.special.SpecialMode && !arg.Player.viewAnim.Equals(44) && !arg.Player.viewAnim.Equals(15) && !arg.Player.viewAnim.Equals(20))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
		}
	}

	private void DelayFireFrame(ref CommonWeaponArg arg)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 25) && !arg.Cmd.IsAttackOn && arg.CurrentWeapon.attack.ShotsFired >= 1)
		{
			arg.CurrentWeapon.attack.ShotsFired = 0;
			BowAttach bowAttach = arg.CurrentWeapon.attach.Data as BowAttach;
			if (bowAttach != null && arg.ClientTime > bowAttach.startAttackTime)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + Math.Max(arg.ClientTime - bowAttach.startAttackTime, arg.CurrentWeapon.basicInfo.Data.MaxPower2);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 300;
			}
			if (bowAttach != null)
			{
				bowAttach.startAttackTime = arg.ClientTime;
			}
			OnFire(ref arg);
			FireUtility.PlayFireSound(ref arg);
		}
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		GunFire(ref arg, arg.Cmd.Seq, shotDistance);
		return 0;
	}

	private bool canFire(ref CommonWeaponArg arg)
	{
		if ((arg.CurrentWeapon.basicInfo.Data.EffectLevel & 0x10) > 0)
		{
			if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime))
			{
				return arg.CurrentWeapon.basicInfo.Data.Power > 0;
			}
			return false;
		}
		if (arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
		}
		return false;
	}

	private void Fire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsAttackOn && canFire(ref arg))
		{
			if ((arg.CurrentWeapon.basicInfo.Data.EffectLevel & 0x10) > 0)
			{
				arg.CurrentWeapon.basicInfo.Data.Power = Math.Max(arg.CurrentWeapon.basicInfo.Data.Power - 1, 0);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval;
			}
			else
			{
				arg.CurrentWeapon.attack.ShotsFired++;
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Data.MaxPower2;
			}
		}
	}

	private void FovControll(ref CommonWeaponArg arg)
	{
		BowAttach bowAttach = arg.CurrentWeapon.attach.Data as BowAttach;
		if (arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			if (bowAttach != null)
			{
				bowAttach.isFovDown = false;
			}
			arg.Player.fov.Fov = 90;
			return;
		}
		if (bowAttach != null && !bowAttach.isFovDown && arg.Cmd.IsAttackOn)
		{
			bowAttach.isFovDown = true;
			bowAttach.startAttackTime = arg.ClientTime + 200;
		}
		if (bowAttach != null && bowAttach.isFovDown && !arg.Cmd.IsAttackOn)
		{
			bowAttach.isFovDown = false;
			arg.Player.fov.Fov = 90;
		}
		else
		{
			AccumulateStrengthWhenIsFovDown(arg, bowAttach);
		}
	}

	private static void AccumulateStrengthWhenIsFovDown(CommonWeaponArg arg, BowAttach bowAttach)
	{
		if (bowAttach == null || !bowAttach.isFovDown)
		{
			return;
		}
		if ((PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 13) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 14)) && arg.ClientTime >= bowAttach.startAttackTime)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 25);
		}
		if (arg.CurrentWeapon.basicInfo != null)
		{
			float num = (float)(arg.ClientTime - bowAttach.startAttackTime) * 1f / (float)arg.CurrentWeapon.basicInfo.Data.MaxPower2;
			if (num > 1f)
			{
				num = 1f;
			}
			else if (num < 0f)
			{
				num = 0f;
			}
			arg.Player.fov.Fov = (int)(90f * (1f - num) + num * 55f);
		}
	}
}

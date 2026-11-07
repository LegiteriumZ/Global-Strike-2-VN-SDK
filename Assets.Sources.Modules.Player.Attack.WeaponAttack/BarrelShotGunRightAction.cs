using System;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BarrelShotGunRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
{
	public BarrelShotGunRightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireSetAnim);
		AddFire(FireNextAttack);
		AddFire(Fire);
		AddFire(FireUtility.PlaySecFireSound);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanSecondaryAttack(ref arg))
		{
			return arg.CurrentWeapon.clip.Clip > 0;
		}
		return false;
	}

	private int Fire(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is IMutilFireBullets))
		{
			return 0;
		}
		IMutilFireBullets mutilFireBullets = arg.CurrentWeapon.basicInfo.Info as IMutilFireBullets;
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		int num = Math.Min(3, arg.CurrentWeapon.clip.Clip);
		WeaponUtility.DescClip(arg.CurrentWeapon, num);
		for (int i = 0; i < num; i++)
		{
			FireUtility.RifleFireIncShotsFired(ref arg);
			FireUtility.FireSetAccuracy(ref arg);
			arg.CurrentWeapon.spread.Spread = 0.07f;
		}
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 1000;
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		for (int j = 0; j < mutilFireBullets.FireBullets * num; j++)
		{
			GunFire(ref arg, arg.Cmd.Seq + mutilFireBullets.FireBullets * num + j, shotDistance);
		}
		return 0;
	}

	private static int FireSetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		return 0;
	}

	private static int FireNextAttack(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 1000);
		return 0;
	}
}

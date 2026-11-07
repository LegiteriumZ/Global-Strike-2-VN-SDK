using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BurstPistolIdleAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	public BurstPistolIdleAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(BusrtRemainingFire);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.burstMode.BurstModeShotsFired > 0)
		{
			return (float)arg.ClientTime - arg.CurrentWeapon.attack.NextAttackTimer + (float)arg.CurrentWeapon.basicInfo.Info.AttackInterval + 400f > 50f;
		}
		return false;
	}

	private int BusrtRemainingFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		WeaponUtility.DescClip(arg.CurrentWeapon);
		if (arg.CurrentWeapon.clip.Clip < 0)
		{
			arg.CurrentWeapon.clip.Clip = 0;
			arg.CurrentWeapon.burstMode.BurstModeShotsFired = 0;
			return 0;
		}
		GunFire(ref arg, arg.Cmd.Seq + arg.CurrentWeapon.burstMode.BurstModeShotsFired, shotDistance);
		arg.CurrentWeapon.burstMode.BurstModeShotsFired--;
		arg.Player.punchOrientation.PunchPitch += 0.2f;
		FireUtility.PlayFireSound(ref arg);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval + 400;
		return 0;
	}
}

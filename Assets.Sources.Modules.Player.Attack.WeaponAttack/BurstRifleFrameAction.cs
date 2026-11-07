using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BurstRifleFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	public BurstRifleFrameAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(BusrtRemainingFire);
		AddFire(FireUtility.FireSetLastFireTime);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.burstMode.BurstModeShotsFired > 0)
		{
			return arg.ClientTime - arg.CurrentWeapon.attack.LastFire > 50;
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
		arg.Player.punchOrientation.PunchPitch += 0.6f;
		return 0;
	}
}

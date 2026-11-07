using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class LegoShotgunPistolLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public LegoShotgunPistolLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(ShotGunFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	public static int RightFireQkhhAfterFire(ref CommonWeaponArg arg)
	{
		arg.FireTranName = "qkhh_0";
		FireUtility.RightFireQkhhAfterFire(ref arg);
		return 0;
	}

	private int ShotGunFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		int seq = arg.Cmd.Seq;
		if (arg.CurrentWeapon.basicInfo.Info is IMutilFireBullets)
		{
			int fireBullets = (arg.CurrentWeapon.basicInfo.Info as IMutilFireBullets).FireBullets;
			for (int i = 0; i < fireBullets; i++)
			{
				GunFire(ref arg, seq + i, shotDistance);
			}
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (base.CanFire(ref arg))
		{
			return arg.CurrentWeapon.attack.ShotsFired < 1;
		}
		return false;
	}
}

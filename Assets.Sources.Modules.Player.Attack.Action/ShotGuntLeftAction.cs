using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class ShotGuntLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public ShotGuntLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(ResetReload);
		AddFire(ShotGunFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int ShotGunFire(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.PredicatedOnce)
		{
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
		}
		return 0;
	}

	private int ResetReload(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.reload.ReloadEndTime = 0f;
		arg.CurrentWeapon.reload.IsStartReload = false;
		return 0;
	}
}

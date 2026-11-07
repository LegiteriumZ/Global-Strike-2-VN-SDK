using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Spas12LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public Spas12LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(ResetReload);
		AddFire(ShotGunFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
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

	private int ResetReload(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.reload.ReloadEndTime = 0f;
		arg.CurrentWeapon.reload.IsStartReload = false;
		return 0;
	}

	public int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.reload.IsStartReload && !arg.CurrentWeapon.special.SpecialMode)
		{
			return false;
		}
		return base.CanFire(ref arg);
	}
}

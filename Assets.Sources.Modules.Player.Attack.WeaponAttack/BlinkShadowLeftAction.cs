using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlinkShadowLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public BlinkShadowLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireDescClip);
		AddFire(LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.AllFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		if (!arg.Cmd.PredicatedOnce)
		{
			if (arg.CurrentWeapon.attack.ShotsFired > 3)
			{
				for (int i = 0; i < 2; i++)
				{
					GunFire(ref arg, arg.Cmd.Seq + i, shotDistance);
				}
			}
			else
			{
				GunFire(ref arg, arg.Cmd.Seq, shotDistance);
			}
		}
		return 0;
	}

	public static int FireDescClip(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired > 3)
		{
			WeaponUtility.DescClip(arg.CurrentWeapon, 2);
		}
		else
		{
			WeaponUtility.DescClip(arg.CurrentWeapon, 1);
		}
		return 0;
	}

	public static int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired > 3)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
		}
		else if (arg.CurrentWeapon.basicInfo.Data.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
		}
		arg.CurrentWeapon.basicInfo.Data.SpecialMode = !arg.CurrentWeapon.basicInfo.Data.SpecialMode;
		arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}
}

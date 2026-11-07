using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class Mp5IceLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public Mp5IceLeftAction(Contexts contexts)
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
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private static int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if (arg.CurrentWeapon.attack.ShotsFired > 3)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 41);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
			}
		}
		else if (arg.CurrentWeapon.attack.ShotsFired > 3)
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

	private static int FireDescClip(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			return 0;
		}
		WeaponUtility.DescClip(arg.CurrentWeapon);
		return 0;
	}
}

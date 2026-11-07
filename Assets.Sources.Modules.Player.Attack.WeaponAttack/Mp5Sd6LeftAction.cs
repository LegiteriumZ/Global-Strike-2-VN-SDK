using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class Mp5Sd6LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public Mp5Sd6LeftAction(Contexts contexts)
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
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private static int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, (arg.CurrentWeapon.attack.ShotsFired > 3) ? 41 : 40);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, (arg.CurrentWeapon.attack.ShotsFired > 3) ? 32 : 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}
}

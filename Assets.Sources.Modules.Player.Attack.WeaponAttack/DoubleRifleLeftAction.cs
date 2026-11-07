using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleRifleLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public DoubleRifleLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(DoubleLeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.LeftFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int DoubleLeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 32);
		}
		else
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}
}

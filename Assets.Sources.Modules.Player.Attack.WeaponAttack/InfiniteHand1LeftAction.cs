using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InfiniteHand1LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public InfiniteHand1LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(LeftFireSetAnim);
		AddFire(FireNextAttack);
		AddFire(ShotGunFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.LeftFireQkhhAfterFire);
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
		for (int i = 0; i < 6; i++)
		{
			GunFire(ref arg, seq + i, shotDistance);
		}
		return 0;
	}

	public static int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 40);
		}
		else
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	public int FireNextAttack(ref CommonWeaponArg arg)
	{
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 15);
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + viewAnimDuration);
		return 0;
	}
}

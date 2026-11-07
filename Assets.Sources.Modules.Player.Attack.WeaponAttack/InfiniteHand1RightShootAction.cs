using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InfiniteHand1RightShootAction : AbstractFireAction, IRightCmdAction, ICmdAction
{
	public InfiniteHand1RightShootAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(RightFireSetAnim);
		AddFire(FireNextAttack);
		AddFire(ShotGunFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			base.Action(ref arg);
		}
		return true;
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

	public static int RightFireSetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
		return 0;
	}

	public int FireNextAttack(ref CommonWeaponArg arg)
	{
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 40);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + viewAnimDuration);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return WeaponUtility.CanFire2(ref arg);
	}
}

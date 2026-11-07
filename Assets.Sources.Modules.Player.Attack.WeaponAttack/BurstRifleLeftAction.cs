using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BurstRifleLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public BurstRifleLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(SetAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.DebugAfterFire);
		AddFire(FireUtility.FireSetLastFireTime);
		AddFire(FireUtility.RightFireQkhhAfterFire);
	}

	private int SetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, arg.CurrentWeapon.special.SpecialMode ? 20 : 15);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	private int SetNextAttack(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval + 450);
			arg.CurrentWeapon.burstMode.BurstModeShotsFired = 2;
			FireUtility.PlaySecFireSound(ref arg);
			arg.CurrentWeapon.attack.ShotsFired = 1;
		}
		else
		{
			FireUtility.RifleFireIncShotsFired(ref arg);
			FireUtility.PlayFireSound(ref arg);
			FireUtility.FireNextAttack(ref arg);
			arg.CurrentWeapon.burstMode.BurstModeShotsFired = 0;
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return base.CanFire(ref arg);
	}
}

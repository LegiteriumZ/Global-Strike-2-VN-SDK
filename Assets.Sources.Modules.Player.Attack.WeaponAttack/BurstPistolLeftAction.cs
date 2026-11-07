using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BurstPistolLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public BurstPistolLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(SetAnim);
		AddFire(SetNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.DebugAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int SetAnim(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimExist(arg.Player, 40))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, arg.CurrentWeapon.special.SpecialMode ? 40 : 15);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, arg.CurrentWeapon.special.SpecialMode ? 20 : 15);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		}
		return 0;
	}

	private int SetNextAttack(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval + 400);
			arg.CurrentWeapon.burstMode.BurstModeShotsFired = 2;
		}
		else
		{
			FireUtility.FireNextAttack(ref arg);
			arg.CurrentWeapon.burstMode.BurstModeShotsFired = 0;
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (base.CanFire(ref arg))
		{
			return arg.CurrentWeapon.basicInfo.Data.ShotsFired < 1;
		}
		return false;
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class MetalStormRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
{
	public MetalStormRightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(RightRifleBeforeFireClip2);
		AddFire(RightRifleBeforeFireSetAnim2);
		AddFire(RightRifleBeforeFireNextAttack);
		AddFire(OnRightFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(PlayFireSoundIfNeed);
	}

	private int PlayFireSoundIfNeed(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.IsAttackOn)
		{
			FireUtility.PlayFireSound(ref arg);
		}
		return 0;
	}

	protected int OnRightFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		GunFire(ref arg, arg.Cmd.Seq + 1, shotDistance);
		return 0;
	}

	private int RightRifleBeforeFireSetAnim2(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
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

	private int RightRifleBeforeFireNextAttack(ref CommonWeaponArg arg)
	{
		if (MetalStormPredicationSystem.IsSpecialMode(arg.CurrentWeapon))
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval / 2);
		}
		else
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval);
		}
		return 0;
	}

	private int RightRifleBeforeFireClip2(ref CommonWeaponArg arg)
	{
		if (MetalStormPredicationSystem.IsSpecialMode(arg.CurrentWeapon))
		{
			arg.CurrentWeapon.power.Power--;
		}
		else
		{
			arg.CurrentWeapon.clip.Clip2--;
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if ((float)arg.ClientTime < arg.CurrentWeapon.attack.NextSecondaryAttackTimer)
		{
			return false;
		}
		if (arg.CurrentWeapon.power.Power <= 0)
		{
			return arg.CurrentWeapon.clip.Clip2 > 0;
		}
		return true;
	}
}

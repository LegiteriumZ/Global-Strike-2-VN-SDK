using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class MetalStromLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public MetalStromLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(MetalStormFireDescClip);
		AddFire(DoubleLeftFireSetAnim);
		AddFire(MetalStormFireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.LeftFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int MetalStormFireNextAttack(ref CommonWeaponArg arg)
	{
		if (MetalStormPredicationSystem.IsSpecialMode(arg.CurrentWeapon))
		{
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval / 2);
		}
		else
		{
			FireUtility.FireNextAttack(ref arg);
		}
		return 0;
	}

	private int MetalStormFireDescClip(ref CommonWeaponArg arg)
	{
		if (MetalStormPredicationSystem.IsSpecialMode(arg.CurrentWeapon))
		{
			arg.CurrentWeapon.power.Power--;
		}
		else
		{
			WeaponUtility.DescClip(arg.CurrentWeapon);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if ((float)arg.ClientTime < arg.CurrentWeapon.attack.NextAttackTimer)
		{
			return false;
		}
		if (arg.CurrentWeapon.power.Power <= 0)
		{
			return arg.CurrentWeapon.clip.Clip > 0;
		}
		return true;
	}

	private static int DoubleLeftFireSetAnim(ref CommonWeaponArg arg)
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

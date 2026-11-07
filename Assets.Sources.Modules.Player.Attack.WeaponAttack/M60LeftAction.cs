using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M60LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public M60LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(M60LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime))
		{
			return arg.CurrentWeapon.special.Level < GetMaxLevel(arg.CurrentWeapon);
		}
		return false;
	}

	private int GetMaxLevel(WeaponEntity currentWeapon)
	{
		if (currentWeapon.hasAttach && currentWeapon.attach.Data is M60Attach)
		{
			return M60Attach.GetMaxLevel(currentWeapon);
		}
		return M60PredicationSystem.MAX_LEVEL;
	}

	private int M60LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 91);
			PlayerAnimationUtility.SetLegsAnimation(arg.Player, 91);
			if (arg.CurrentWeapon.attack.ShotsFired > 3)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 41);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
			}
		}
		else
		{
			if (arg.CurrentWeapon.attack.ShotsFired > 3)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		}
		if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.special.Level < GetMaxLevel(arg.CurrentWeapon))
		{
			arg.CurrentWeapon.special.Level += 5;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 500;
		}
		return 0;
	}
}

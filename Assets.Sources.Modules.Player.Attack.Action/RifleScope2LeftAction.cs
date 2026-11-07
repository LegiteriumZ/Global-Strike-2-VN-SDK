using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class RifleScope2LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public RifleScope2LeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(RifleScopeSetNextAttack);
		AddFire(RifleScop2SetAnim);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int RifleScop2SetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 41);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
			}
		}
		else if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
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

	public int RifleScopeSetNextAttack(ref CommonWeaponArg arg)
	{
		if (!(arg.CurrentWeapon.basicInfo.Info is IRifleScppeWeaponInfo))
		{
			return 0;
		}
		if (!arg.Player.fov.IsZoom())
		{
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval);
		}
		else
		{
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + (arg.CurrentWeapon.basicInfo.Info as IRifleScppeWeaponInfo).FovAttackInterval);
		}
		return 0;
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class WhiteSwordGunRightAction : RifleMeleeRightAction
{
	public WhiteSwordGunRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
		{
			return WeaponUtility.CanSecondaryAttack(ref arg);
		}
		return false;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		return 0;
	}

	protected override int SetNextAttack(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 1000;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.CurrentWeapon.attack.NextAttackTimer;
		return 0;
	}
}

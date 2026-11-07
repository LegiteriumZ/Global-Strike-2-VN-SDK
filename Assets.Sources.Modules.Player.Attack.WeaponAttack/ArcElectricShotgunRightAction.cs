using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ArcElectricShotgunRightAction : RifleMeleeRightAction
{
	public ArcElectricShotgunRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, base.ViewAnimId);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 72);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, base.ViewAnimId);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
		}
		return 0;
	}
}

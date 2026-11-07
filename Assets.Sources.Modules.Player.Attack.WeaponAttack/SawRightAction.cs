using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SawRightAction : KnifeRightAction
{
	public SawRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64))
		{
			return false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
		{
			return false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65))
		{
			return false;
		}
		return base.CanFire(ref arg);
	}
}

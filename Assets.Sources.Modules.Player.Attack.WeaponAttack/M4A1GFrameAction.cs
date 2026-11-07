using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M4A1GFrameAction : AbstractFrameAction
{
	public M4A1GFrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (base.Action(ref arg) && arg.Cmd.IsShowGun && !arg.Player.viewAnim.Equals(44))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
		}
		return true;
	}
}

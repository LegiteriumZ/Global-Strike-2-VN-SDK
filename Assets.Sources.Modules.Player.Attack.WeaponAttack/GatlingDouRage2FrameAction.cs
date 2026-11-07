using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingDouRage2FrameAction : AbstractFrameAction
{
	public GatlingDouRage2FrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44) && arg.Player.viewAnim.LeftViewAnimInfo != null && arg.Player.viewAnim.LeftViewAnimInfo.StateId != 44)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
		}
		return true;
	}
}

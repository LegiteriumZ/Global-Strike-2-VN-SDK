using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BursterNailsKnifeFrameAction : IFrameCmdAction, ICmdAction
{
	public BursterNailsKnifeFrameAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
			return true;
		}
		return false;
	}
}

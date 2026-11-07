using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

public class TripleAttackKnifeFrameAction : IFrameCmdAction, ICmdAction
{
	public TripleAttackKnifeFrameAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (CanOtherAttack(ref arg) && !arg.Cmd.IsAttackOn)
		{
			arg.CurrentWeapon.special.SpecialMode = true;
		}
		else
		{
			arg.CurrentWeapon.special.SpecialMode = false;
		}
		return true;
	}

	protected virtual bool CanOtherAttack(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 31))
		{
			if (arg.Player.viewAnim.RemainTime < 700 && arg.Player.viewAnim.RemainTime > 200)
			{
				return true;
			}
		}
		else if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 29))
		{
			if (arg.Player.viewAnim.RemainTime < 700 && arg.Player.viewAnim.RemainTime > 200)
			{
				return true;
			}
		}
		else if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 15) && arg.Player.viewAnim.RemainTime < 500 && arg.Player.viewAnim.RemainTime > 0)
		{
			return true;
		}
		return false;
	}
}

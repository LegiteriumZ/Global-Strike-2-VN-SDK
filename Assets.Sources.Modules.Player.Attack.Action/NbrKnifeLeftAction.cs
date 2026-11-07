using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class NbrKnifeLeftAction : KnifeLeftAction, ILeftCmdAction, ICmdAction
{
	public NbrKnifeLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
		return 0;
	}
}

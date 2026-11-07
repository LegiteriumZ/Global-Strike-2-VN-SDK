using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class YueTuRightAction : KnifeRightAction
{
	private readonly Contexts _contexts;

	public YueTuRightAction(Contexts contexts)
		: base(contexts)
	{
		_contexts = contexts;
	}

	protected override int SetAttackAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
		PlayerAnimationUtility.SetLegsAnimation(arg.Player, 27);
		return 0;
	}
}

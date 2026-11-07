using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class VoidJumpPredicationSystem : AbstractAttackPredicationSystem
{
	public VoidJumpPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new VoidJumpRightAction(contexts));
	}
}

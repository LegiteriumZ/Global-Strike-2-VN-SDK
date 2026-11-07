using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleRiflelPredicationSystem : AbstractAttackPredicationSystem
{
	public DoubleRiflelPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new DoubleRifleLeftAction(contexts));
		RightActions.Add(new DoubleRifleRightAction(contexts));
	}
}

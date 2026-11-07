using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class InfiniteHand1PredicationSystem : AbstractAttackPredicationSystem
{
	public InfiniteHand1PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new InfiniteHand1LeftAction(contexts));
		RightActions.Add(new InfiniteHand1RightAction(contexts));
		RightActions.Add(new InfiniteHand1RightShootAction(contexts));
	}
}

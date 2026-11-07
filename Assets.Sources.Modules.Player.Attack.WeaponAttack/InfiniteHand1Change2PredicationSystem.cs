using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InfiniteHand1Change2PredicationSystem : AbstractAttackPredicationSystem
{
	public InfiniteHand1Change2PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new InfiniteHand1Change2LeftAction(contexts));
		RightActions.Add(new InfiniteHand1Change2RightAction(contexts));
		FrameActions.Add(new InfiniteHand1Change2SpecialFrameAction(contexts));
		FrameActions.Add(new InfiniteHand1Change2FrameAction(contexts));
	}
}

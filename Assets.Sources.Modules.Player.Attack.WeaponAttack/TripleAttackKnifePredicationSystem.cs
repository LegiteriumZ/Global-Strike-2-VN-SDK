using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class TripleAttackKnifePredicationSystem : AbstractAttackPredicationSystem
{
	public TripleAttackKnifePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new TripleAttackKnifeLeftAction(contexts));
		RightActions.Add(new TripleAttackKnifeRightAction(contexts));
		FrameActions.Add(new TripleAttackKnifeFrameAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
	}
}

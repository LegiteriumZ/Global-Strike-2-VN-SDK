using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GoldSaberPredicationSystem : AbstractAttackPredicationSystem
{
	public GoldSaberPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new TripleAttackKnifeLeftAction(contexts));
		RightActions.Add(new TripleAttackKnifeRightAction(contexts));
		FrameActions.Add(new GoldSaberFrameAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.WeaponAttack;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class FeatherBowPredicationSystem : AbstractAttackPredicationSystem
{
	public FeatherBowPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new FeatherBowFrameAction(contexts));
		RightActions.Add(new FeatherBowRightAction());
		LeftActions.Add(new FeatherBowLeftAction());
	}
}

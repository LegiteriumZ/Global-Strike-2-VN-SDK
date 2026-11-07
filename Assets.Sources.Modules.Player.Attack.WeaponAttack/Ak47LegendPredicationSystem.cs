using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Ak47LegendPredicationSystem : AbstractAttackPredicationSystem
{
	public Ak47LegendPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		Ak47LegendRightAction ak47LegendRightAction = new Ak47LegendRightAction(contexts);
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(ak47LegendRightAction);
		FrameActions.Add(new TripleAttackFrameAction(contexts, ak47LegendRightAction));
	}
}

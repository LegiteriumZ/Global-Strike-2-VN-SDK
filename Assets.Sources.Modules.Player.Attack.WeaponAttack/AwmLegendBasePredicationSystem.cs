using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AwmLegendBasePredicationSystem : AbstractAttackPredicationSystem
{
	public AwmLegendBasePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new AwmLegendLeftAction(contexts));
		LeftActions.Add(new FovLeftAction(contexts));
		RightActions.Add(new FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		FrameActions.Add(new AwmLegendBaseAction(contexts));
	}
}

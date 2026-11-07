using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AwmLegendBaseSpecialPredicationSystem : AbstractAttackPredicationSystem
{
	public AwmLegendBaseSpecialPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		RightActions.Add(new FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		FrameActions.Add(new AwmLegendSpecialFrameAction(contexts));
	}
}

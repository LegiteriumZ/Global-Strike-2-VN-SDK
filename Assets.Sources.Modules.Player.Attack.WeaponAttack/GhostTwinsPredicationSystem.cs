using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GhostTwinsPredicationSystem : AbstractAttackPredicationSystem
{
	public GhostTwinsPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new GhostTwinsLeftAction(contexts));
		RightActions.Add(new FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		FrameActions.Add(new GhostTwinsSwitchAction(contexts));
	}
}

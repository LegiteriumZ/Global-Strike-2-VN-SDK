using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SniperRifle2PredicationSystem : AbstractAttackPredicationSystem
{
	public SniperRifle2PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
	}
}

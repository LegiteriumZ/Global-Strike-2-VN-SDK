using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolScopePredicationSystem : AbstractAttackPredicationSystem
{
	public PistolScopePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new PistolLeftAction(contexts));
		RightActions.Add(new RifleScopeFovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleScopePredicationSystem : AbstractAttackPredicationSystem
{
	public RifleScopePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleScopeLeftAction(contexts));
		RightActions.Add(new RifleScopeFovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
	}
}

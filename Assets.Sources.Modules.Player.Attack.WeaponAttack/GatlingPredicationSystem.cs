using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingPredicationSystem : AbstractAttackPredicationSystem
{
	public GatlingPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new GatlingLeftAction(contexts));
		RightActions.Add(new GatlingRightAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new GatlingFrameAction(contexts));
	}
}

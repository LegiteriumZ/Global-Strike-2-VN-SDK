using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingDouRage1PredicationSystem : AbstractAttackPredicationSystem
{
	public GatlingDouRage1PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new GatlingDouRage1LeftAction(contexts));
		RightActions.Add(new GatlingRightAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new GatlingFrameAction(contexts));
	}
}

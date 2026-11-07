using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingDouRage2PredicationSystem : AbstractAttackPredicationSystem
{
	public GatlingDouRage2PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new GatlingDouRage2LeftAction(contexts));
		RightActions.Add(new GatlingDouRage2RightAction(contexts));
		FrameActions.Add(new GatlingDouRage2FrameAction(contexts));
	}
}

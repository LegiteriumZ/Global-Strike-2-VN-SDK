using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingGPredicationSystem : AbstractAttackPredicationSystem
{
	public GatlingGPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new GatlingGLeftAction(contexts));
		RightActions.Add(new GatlingGRightAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
	}
}

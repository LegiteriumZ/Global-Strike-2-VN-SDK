using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M4a1LegendBase2PredicationSystem : AbstractAttackPredicationSystem
{
	public M4a1LegendBase2PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new M4a1LegendBaseAction(contexts));
	}
}

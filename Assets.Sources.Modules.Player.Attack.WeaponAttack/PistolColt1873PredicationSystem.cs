using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolColt1873PredicationSystem : AbstractAttackPredicationSystem
{
	public PistolColt1873PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new PistolColt1873LeftAction(contexts));
	}
}

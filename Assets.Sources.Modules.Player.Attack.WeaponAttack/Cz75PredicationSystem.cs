using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Cz75PredicationSystem : AbstractAttackPredicationSystem
{
	public Cz75PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new Cz75LeftAction(contexts));
	}
}

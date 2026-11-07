using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class AnimalAttackPredicationSystem : AbstractAttackPredicationSystem
{
	public AnimalAttackPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new AnimalLeftAction(contexts));
	}
}

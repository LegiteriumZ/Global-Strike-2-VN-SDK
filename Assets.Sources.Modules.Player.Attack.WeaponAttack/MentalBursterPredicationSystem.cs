using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class MentalBursterPredicationSystem : AbstractAttackPredicationSystem
{
	public MentalBursterPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new MentalBursterLeftAction(contexts));
	}
}

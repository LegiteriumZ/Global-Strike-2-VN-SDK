using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolElectricPredicationSystem : AbstractAttackPredicationSystem
{
	public PistolElectricPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new PistolElectricPistolLeftAction(contexts));
	}
}

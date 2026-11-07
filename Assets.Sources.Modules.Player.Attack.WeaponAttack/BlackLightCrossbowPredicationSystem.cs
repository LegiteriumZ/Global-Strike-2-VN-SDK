using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlackLightCrossbowPredicationSystem : AbstractAttackPredicationSystem
{
	public BlackLightCrossbowPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new BlackLightCrossbowLeftAction(contexts));
	}
}

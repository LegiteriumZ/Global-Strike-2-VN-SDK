using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlackLightCrossbowSpecial : AbstractAttackPredicationSystem
{
	public BlackLightCrossbowSpecial(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new BlackLightCrossbowSpecialLeftAction(contexts));
	}
}

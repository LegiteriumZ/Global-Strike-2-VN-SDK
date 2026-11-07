using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleShotGunPredicationSystem : AbstractAttackPredicationSystem
{
	public DoubleShotGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new DoubleShotGunLeftAction(contexts));
	}
}

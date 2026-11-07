using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShotGunPredicationSystem : AbstractAttackPredicationSystem
{
	public ShotGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new ShotGuntLeftAction(contexts));
	}
}

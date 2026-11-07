using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BarrelShotGunPredicationSystem : AbstractAttackPredicationSystem
{
	public BarrelShotGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new BarrelShotGuntLeftAction(contexts));
		RightActions.Add(new BarrelShotGunRightAction(contexts));
	}
}

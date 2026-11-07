using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BloodShotGunPredicationSystem : AbstractAttackPredicationSystem
{
	public BloodShotGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new BloodShotGunLeftAction(contexts));
	}
}

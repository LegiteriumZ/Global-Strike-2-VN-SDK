using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShotGunPistolPredicationSystem : AbstractAttackPredicationSystem
{
	public ShotGunPistolPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new ShotGunPistolLeftAction(contexts));
	}
}

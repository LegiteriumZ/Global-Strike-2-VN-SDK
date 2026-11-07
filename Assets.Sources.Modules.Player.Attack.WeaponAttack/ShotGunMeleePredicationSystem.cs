using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShotGunMeleePredicationSystem : AbstractAttackPredicationSystem
{
	public ShotGunMeleePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new ShotGuntLeftAction(contexts));
		RightActions.Add(new RifleMeleeRightAction(contexts));
	}
}

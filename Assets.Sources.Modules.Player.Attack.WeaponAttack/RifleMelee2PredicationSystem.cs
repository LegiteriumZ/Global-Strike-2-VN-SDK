using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleMelee2PredicationSystem : AbstractAttackPredicationSystem
{
	public RifleMelee2PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new RifleMeleeDelaySoundRightAction(contexts));
	}
}

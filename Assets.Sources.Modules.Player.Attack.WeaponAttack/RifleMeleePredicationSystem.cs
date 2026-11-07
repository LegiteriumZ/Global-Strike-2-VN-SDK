using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleMeleePredicationSystem : AbstractAttackPredicationSystem
{
	public RifleMeleePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new RifleMeleeRightAction(contexts));
	}
}

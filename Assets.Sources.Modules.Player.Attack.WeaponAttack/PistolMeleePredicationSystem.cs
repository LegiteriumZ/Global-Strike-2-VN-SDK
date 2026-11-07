using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolMeleePredicationSystem : AbstractAttackPredicationSystem
{
	public PistolMeleePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new PistolLeftAction(contexts));
		RightActions.Add(new RifleMeleeRightAction(contexts));
	}
}

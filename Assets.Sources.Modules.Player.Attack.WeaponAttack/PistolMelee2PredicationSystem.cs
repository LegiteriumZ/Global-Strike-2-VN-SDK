using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolMelee2PredicationSystem : AbstractAttackPredicationSystem
{
	public PistolMelee2PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new PistolLeftAction(contexts));
		RightActions.Add(new RifleMeleeDelaySoundRightAction(contexts));
	}
}

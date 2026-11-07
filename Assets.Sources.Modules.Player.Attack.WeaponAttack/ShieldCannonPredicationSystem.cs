using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShieldCannonPredicationSystem : AbstractAttackPredicationSystem
{
	public ShieldCannonPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new ShieldCannonLeftAction(contexts));
		RightActions.Add(new ShieldCannonRightAction(contexts));
	}
}

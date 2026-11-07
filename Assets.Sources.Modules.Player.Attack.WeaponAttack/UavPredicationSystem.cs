using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class UavPredicationSystem : AbstractAttackPredicationSystem
{
	public UavPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new UavLeftAction(contexts));
		IdleActions.Add(new PistolIdleAction(contexts));
		RightActions.Add(new UavRightAction(contexts));
	}
}

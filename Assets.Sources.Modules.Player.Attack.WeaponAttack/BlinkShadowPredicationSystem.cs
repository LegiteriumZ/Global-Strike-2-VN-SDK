using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlinkShadowPredicationSystem : AbstractAttackPredicationSystem
{
	public BlinkShadowPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new BlinkShadowLeftAction(contexts));
		RightActions.Add(new RifleMeleeRightAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleUziPredicationSystem : AbstractAttackPredicationSystem
{
	public DoubleUziPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new DoubleUziLeftAction(contexts));
	}
}

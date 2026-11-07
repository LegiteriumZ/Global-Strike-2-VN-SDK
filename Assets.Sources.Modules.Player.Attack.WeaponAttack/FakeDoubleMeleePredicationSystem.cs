using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class FakeDoubleMeleePredicationSystem : AbstractAttackPredicationSystem
{
	public FakeDoubleMeleePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new DoubleUziLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new RifleMeleeRightAction(contexts));
	}
}

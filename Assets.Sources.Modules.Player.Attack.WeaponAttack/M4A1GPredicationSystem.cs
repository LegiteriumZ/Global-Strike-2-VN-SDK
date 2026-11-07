using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M4A1GPredicationSystem : AbstractAttackPredicationSystem
{
	public M4A1GPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new RifleMeleeRightAction(contexts));
		FrameActions.Add(new M4A1GFrameAction(contexts));
	}
}

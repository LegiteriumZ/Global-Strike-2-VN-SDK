using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleScope3PredicationSystem : AbstractAttackPredicationSystem
{
	public RifleScope3PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleScope3LeftAction(contexts));
		RightActions.Add(new RifleScopeFovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
	}
}

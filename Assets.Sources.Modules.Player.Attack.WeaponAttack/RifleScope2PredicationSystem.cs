using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleScope2PredicationSystem : AbstractAttackPredicationSystem
{
	public RifleScope2PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleScope2LeftAction(contexts));
		RightActions.Add(new RifleScope2FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
	}
}

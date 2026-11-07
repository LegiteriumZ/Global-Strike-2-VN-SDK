using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolScope2PredicationSystem : AbstractAttackPredicationSystem
{
	public PistolScope2PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new PistolLeftAction(contexts));
		RightActions.Add(new RifleScope2FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
	}
}

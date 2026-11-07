using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BurstPistolPredicationSystem : AbstractAttackPredicationSystem
{
	public BurstPistolPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new BurstPistolLeftAction(contexts));
		RightActions.Add(new BurstPistolRightAction(contexts));
		IdleActions.Add(new PistolIdleAction(contexts));
		FrameActions.Add(new BurstPistolIdleAction(contexts));
	}
}

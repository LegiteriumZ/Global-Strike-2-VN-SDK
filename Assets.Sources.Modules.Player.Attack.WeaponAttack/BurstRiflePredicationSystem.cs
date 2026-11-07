using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BurstRiflePredicationSystem : AbstractAttackPredicationSystem
{
	public BurstRiflePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new BurstRifleLeftAction(contexts));
		RightActions.Add(new BurstRifleRightAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new BurstRifleFrameAction(contexts));
	}
}

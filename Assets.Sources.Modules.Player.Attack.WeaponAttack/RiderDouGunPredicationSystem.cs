using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class RiderDouGunPredicationSystem : AbstractAttackPredicationSystem
{
	public RiderDouGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RiderDouGunLeftAction(contexts));
		RightActions.Add(new RiderDouGunRightAction(contexts));
		FrameActions.Add(new RiderDouGunFrameAction(contexts));
	}
}

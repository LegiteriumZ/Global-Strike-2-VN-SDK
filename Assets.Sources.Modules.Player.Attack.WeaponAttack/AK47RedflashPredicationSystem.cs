using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AK47RedflashPredicationSystem : AbstractAttackPredicationSystem
{
	public AK47RedflashPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RedflashLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new AK47RedflashFrameAction(contexts));
		RightActions.Add(new RedFlashRightAction(contexts));
	}
}

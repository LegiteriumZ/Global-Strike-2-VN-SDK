using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class TmpPredicationSystem : AbstractAttackPredicationSystem
{
	public TmpPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new TmpLeftAction(contexts));
		FrameActions.Add(new G36CSwitchAction(contexts));
	}
}

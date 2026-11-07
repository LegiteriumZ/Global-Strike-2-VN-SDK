using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class G36CPredicationSystem : AbstractAttackPredicationSystem
{
	public G36CPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new G36CLeftAction(contexts));
		RightActions.Add(new FovRight2Action(contexts));
		FrameActions.Add(new G36CSwitchAction(contexts));
	}
}

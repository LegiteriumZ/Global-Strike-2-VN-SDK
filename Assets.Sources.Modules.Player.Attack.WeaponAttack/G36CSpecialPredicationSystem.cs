using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class G36CSpecialPredicationSystem : AbstractAttackPredicationSystem
{
	public G36CSpecialPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new G36CSpecialLeftAction(contexts));
		FrameActions.Add(new G36CSwitchAction(contexts));
	}
}

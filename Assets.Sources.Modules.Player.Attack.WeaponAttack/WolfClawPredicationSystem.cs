using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class WolfClawPredicationSystem : AbstractAttackPredicationSystem
{
	public WolfClawPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new WolfLeftAction(contexts));
		FrameActions.Add(new WolfClawFrameAction(contexts));
	}
}

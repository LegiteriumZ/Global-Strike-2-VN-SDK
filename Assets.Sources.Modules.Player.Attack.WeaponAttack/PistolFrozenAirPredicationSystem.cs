using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolFrozenAirPredicationSystem : AbstractAttackPredicationSystem
{
	public PistolFrozenAirPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new PistolFrozenAirPistolLeftAction(contexts));
		FrameActions.Add(new PistolFrozenAirFrameAction(contexts));
		RightActions.Add(new RifleMeleeRightAction(contexts));
	}
}

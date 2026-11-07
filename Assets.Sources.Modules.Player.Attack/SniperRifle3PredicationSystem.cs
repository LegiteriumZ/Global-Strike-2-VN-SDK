using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;

namespace Assets.Sources.Modules.Player.Attack;

internal class SniperRifle3PredicationSystem : AbstractAttackPredicationSystem
{
	public SniperRifle3PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		RightActions.Add(new FovRight2Action(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
	}
}

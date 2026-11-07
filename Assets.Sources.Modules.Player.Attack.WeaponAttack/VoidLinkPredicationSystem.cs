using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class VoidLinkPredicationSystem : AbstractAttackPredicationSystem
{
	public VoidLinkPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RifleLeftAction(contexts));
		RightActions.Add(new VoidLinkRightAction(contexts));
	}
}

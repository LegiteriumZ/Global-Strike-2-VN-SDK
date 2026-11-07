using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Ak47StrikePredicationSystem : AbstractAttackPredicationSystem
{
	public Ak47StrikePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new Ak47StrikeRifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new Ak47StrikeMeleeRightAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RiflePistolPredicationSystem : AbstractAttackPredicationSystem
{
	public RiflePistolPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new RifleLeftAction(contexts));
	}
}

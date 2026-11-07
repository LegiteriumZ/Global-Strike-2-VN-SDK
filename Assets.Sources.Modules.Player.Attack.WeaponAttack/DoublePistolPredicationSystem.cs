using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoublePistolPredicationSystem : AbstractAttackPredicationSystem
{
	public DoublePistolPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new DoublePistolLeftAction(contexts));
		IdleActions.Add(new PistolIdleAction(contexts));
	}
}

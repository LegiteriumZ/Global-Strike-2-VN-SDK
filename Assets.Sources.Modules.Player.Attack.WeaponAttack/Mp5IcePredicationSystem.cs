using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Mp5IcePredicationSystem : AbstractAttackPredicationSystem
{
	public Mp5IcePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new Mp5IceLeftAction(contexts));
	}
}

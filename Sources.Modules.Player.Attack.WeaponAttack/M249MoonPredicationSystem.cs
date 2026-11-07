using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;

namespace Sources.Modules.Player.Attack.WeaponAttack;

public class M249MoonPredicationSystem : AbstractAttackPredicationSystem
{
	public M249MoonPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RifleLeftAction(contexts));
		RightActions.Add(new M249MoonRightActions(contexts));
	}
}

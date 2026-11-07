using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class Sa58FuturePredicationSystem : AbstractAttackPredicationSystem
{
	public Sa58FuturePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new Sa58FutureLeftAction(contexts));
		RightActions.Add(new Sa58FutureRightAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class LegoShotgunPistolPredicationSystem : AbstractAttackPredicationSystem
{
	public LegoShotgunPistolPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new LegoShotgunPistolLeftAction(contexts));
		RightActions.Add(new LegoShotgunPistolRightAction(contexts));
	}
}

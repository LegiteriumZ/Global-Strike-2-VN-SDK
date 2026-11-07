using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class ElectriElementPredicationSystem : AbstractAttackPredicationSystem
{
	public ElectriElementPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new ElectriElementLeftAction(contexts));
		FrameActions.Add(new ElectriElementFrameAction(contexts));
	}
}

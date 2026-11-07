namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BowPredicationSystem : AbstractAttackPredicationSystem
{
	public BowPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new BowFrameAction(contexts));
		RightActions.Add(new BowRightAction());
	}
}

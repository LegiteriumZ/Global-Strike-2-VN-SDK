namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BowGodPredicationSystem : AbstractAttackPredicationSystem
{
	public BowGodPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new BowGodFrameAction(contexts));
		RightActions.Add(new BowGodRightAction());
	}
}

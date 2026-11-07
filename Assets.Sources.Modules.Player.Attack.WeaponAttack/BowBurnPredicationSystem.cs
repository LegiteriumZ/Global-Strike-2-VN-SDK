namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BowBurnPredicationSystem : AbstractAttackPredicationSystem
{
	public BowBurnPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new BowBurnFrameAction(contexts));
	}
}

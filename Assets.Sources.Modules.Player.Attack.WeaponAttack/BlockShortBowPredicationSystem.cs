namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlockShortBowPredicationSystem : AbstractAttackPredicationSystem
{
	public BlockShortBowPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new BlockShortBowFrameAction(contexts));
	}
}

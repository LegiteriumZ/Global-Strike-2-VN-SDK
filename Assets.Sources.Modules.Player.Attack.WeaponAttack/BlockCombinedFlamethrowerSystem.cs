namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlockCombinedFlamethrowerSystem : AbstractAttackPredicationSystem
{
	public BlockCombinedFlamethrowerSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new BlockCombinedFlamethrowerLeftAction(contexts));
		FrameActions.Add(new BlockCombinedFlamethrowerFrameAction(contexts));
	}
}

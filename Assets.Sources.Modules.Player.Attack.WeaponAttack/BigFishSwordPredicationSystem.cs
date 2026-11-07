namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BigFishSwordPredicationSystem : AbstractAttackPredicationSystem
{
	public BigFishSwordPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new BigFishSwordLeftAction(contexts));
		RightActions.Add(new BigFishSwordRightActions(contexts));
		FrameActions.Add(new BigFishSwordFrameAction());
	}
}

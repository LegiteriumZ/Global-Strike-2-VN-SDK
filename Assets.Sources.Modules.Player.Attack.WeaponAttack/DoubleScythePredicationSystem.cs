namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleScythePredicationSystem : AbstractAttackPredicationSystem
{
	public DoubleScythePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new DoubleScytheLeftAction(contexts));
		RightActions.Add(new DoubleScytheRightAction(contexts));
		FrameActions.Add(new DoubleScytheSwitchAction(contexts));
	}
}

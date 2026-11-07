namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SawPredicationSystem : AbstractAttackPredicationSystem
{
	public SawPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new SawLeftAction());
		RightActions.Add(new SawRightAction(contexts));
		FrameActions.Add(new SawFrameAction(contexts));
	}
}

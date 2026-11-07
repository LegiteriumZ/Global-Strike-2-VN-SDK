namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SwordHeavenJudgeAttackPredicationSystem : AbstractAttackPredicationSystem
{
	public SwordHeavenJudgeAttackPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new SwordHeavenJudgeLeftAction(contexts));
		FrameActions.Add(new SwordHeavenJudgeFrameAction(contexts));
	}
}

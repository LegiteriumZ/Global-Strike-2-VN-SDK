namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class VoidSpearPredicationSystem : AbstractAttackPredicationSystem
{
	public VoidSpearPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new VoidSpear1LeftAction(contexts));
		RightActions.Add(new VoidSpear1RightAction(contexts));
		FrameActions.Add(new VoidSpear1FrameAction(contexts));
	}
}

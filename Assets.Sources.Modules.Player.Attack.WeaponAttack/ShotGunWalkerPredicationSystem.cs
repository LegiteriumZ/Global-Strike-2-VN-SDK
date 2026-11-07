namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class ShotGunWalkerPredicationSystem : AbstractAttackPredicationSystem
{
	public ShotGunWalkerPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new ShotGunWalker1LeftAction(contexts));
		RightActions.Add(new ShotGunWalker1RightAction(contexts));
		FrameActions.Add(new ShotGunWalkerFrameAction(contexts));
	}
}

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class HeroWomanClosePredication : HeroClosePredicationSystem
{
	public HeroWomanClosePredication(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Clear();
		RightActions.Clear();
		FrameActions.Clear();
		LeftActions.Add(new HeroCloseLeftAction(contexts, 432, 532));
		RightActions.Add(new HeroCloseRightAction(contexts, new int[3] { 998, 1198, 1332 }));
		FrameActions.Add(new HeroCloseFrameAction());
	}
}

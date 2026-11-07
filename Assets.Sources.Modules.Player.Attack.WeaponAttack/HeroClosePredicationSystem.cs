namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class HeroClosePredicationSystem : AbstractAttackPredicationSystem
{
	public HeroClosePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new HeroCloseLeftAction(contexts, 799, 699));
		RightActions.Add(new HeroCloseRightAction(contexts, new int[3] { 998, 1198, 1332 }));
		FrameActions.Add(new HeroCloseFrameAction());
	}

	public static int getDelayAttackTime(int stateId)
	{
		return (int)(stateId switch
		{
			31 => 199.79999f, 
			29 => 266.4f, 
			122 => 233.09999f, 
			124 => 532.8f, 
			126 => 832.5f, 
			_ => -1f, 
		});
	}
}

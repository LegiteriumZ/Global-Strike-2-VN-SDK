namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class HeroWeaponBasePredicationSystem : AbstractAttackPredicationSystem
{
	public HeroWeaponBasePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new HeroWeaponBaseLeftAction(contexts, 832, 832));
		RightActions.Add(new HeroWeaponBaseRightAction(contexts, new int[3] { 998, 1198, 1332 }));
		FrameActions.Add(new HeroWeaponBaseFrameAction());
	}

	public static int getDelayAttackTime(int stateId)
	{
		return (int)(stateId switch
		{
			31 => 432.9f, 
			29 => 432.9f, 
			122 => 399.59998f, 
			124 => 233.09999f, 
			126 => 599.39996f, 
			_ => -1f, 
		});
	}
}

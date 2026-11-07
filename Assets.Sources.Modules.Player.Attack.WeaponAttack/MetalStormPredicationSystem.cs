using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class MetalStormPredicationSystem : AbstractAttackPredicationSystem
{
	public MetalStormPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new MetalStromLeftAction(contexts));
		RightActions.Add(new MetalStormRightAction(contexts));
		FrameActions.Add(new MetalStormFrameAction(contexts));
	}

	public static bool IsSpecialMode(WeaponEntity currentWeapon)
	{
		if (RuleUtilty.IsGeneralPve(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			return currentWeapon.power.Power > 10;
		}
		return false;
	}
}

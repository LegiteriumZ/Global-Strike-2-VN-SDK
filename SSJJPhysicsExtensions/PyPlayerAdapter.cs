using System;
using Assets.Sources.Constant.Career;
using Assets.Sources.Utils;
using SSJJPhysics;
using weapon.predicateSystem.logic.maxSpeedLogic;

namespace SSJJPhysicsExtensions;

public class PyPlayerAdapter : BasePyPlayerAdapter
{
	public PyPlayerAdapter(PlayerEntity playerEntity, WeaponContext weaponContext)
		: base(playerEntity, weaponContext)
	{
	}

	protected override int GetRuleMaxSpeed(int speed, PlayerEntity playerEntity)
	{
		if (133 == Contexts.sharedInstance.battleRoom.roomData.Data.RaceType && !PlayerCareerConstantUtility.IsNoHuMan(playerEntity.GetCareer()))
		{
			speed = Math.Min(850, speed);
		}
		return speed;
	}

	protected override int GetMaxSpeed(WeaponEntity weaponEntity, int speed)
	{
		IMaxSpeedLogic maxSpeedLogic = weaponEntity.basicInfo.PredicationConfig.GetMaxSpeedLogic();
		if (maxSpeedLogic != null)
		{
			speed = maxSpeedLogic.GetMaxSpeed(WeaponPredicationUtility.CommonWeaponArgs);
		}
		return speed;
	}
}

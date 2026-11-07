using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class EndlessMachinegunVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		int raceType = battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsPveModel(raceType) || RuleUtilty.IsBioMode(raceType) || RuleUtilty.IsBigHeadModel(raceType))
		{
			return true;
		}
		return false;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		if (weaponContext.isCurrentWeapon && weaponContext.currentWeaponEntity.hasBasicInfo && (weaponContext.currentWeaponEntity.basicInfo.Data.EffectLevel & 2) > 0)
		{
			return 1;
		}
		return 0;
	}
}

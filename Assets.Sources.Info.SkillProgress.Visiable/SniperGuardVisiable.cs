using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class SniperGuardVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		if (!RuleUtilty.IsBigHeadModel(battleRoom.roomData.Data.RaceType) && !RuleUtilty.IsPveModel(battleRoom.roomData.Data.RaceType) && !RuleUtilty.IsBioMode(battleRoom.roomData.Data.RaceType))
		{
			return false;
		}
		return true;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		if (!RuleUtilty.IsBigHeadModel(raceType) && !RuleUtilty.IsPveModel(raceType) && !RuleUtilty.IsBioMode(raceType))
		{
			return 0;
		}
		if (!weaponContext.isCurrentWeapon || !weaponContext.currentWeaponEntity.hasBasicInfo || (weaponContext.currentWeaponEntity.basicInfo.Data.EffectLevel & 8) <= 0)
		{
			return 0;
		}
		return 1;
	}
}

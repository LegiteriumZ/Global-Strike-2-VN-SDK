using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class ThunderScepterVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		return true;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		if ((!RuleUtilty.IsPveModel(raceType) && !RuleUtilty.IsBioMode(raceType) && !RuleUtilty.IsBigHeadModel(raceType) && !RuleUtilty.isMechKingMode(raceType)) || !weaponContext.isCurrentWeapon || !weaponContext.currentWeaponEntity.hasPower || weaponContext.currentWeaponEntity.power.MaxPower2 <= 0)
		{
			return 0;
		}
		return 1;
	}
}

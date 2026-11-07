using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class BreakShotgunPistolVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		return true;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		if ((!RuleUtilty.IsPve(raceType) && !RuleUtilty.IsBigHeadModel(raceType) && !RuleUtilty.IsBioMode(raceType)) || !weaponContext.isCurrentWeapon || !weaponContext.currentWeaponEntity.hasPower || weaponContext.currentWeaponEntity.power.MaxPower == 0)
		{
			return 0;
		}
		return 1;
	}
}

using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class IsBigheadVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		if (!RuleUtilty.IsBigHeadModel(battleRoom.roomData.Data.RaceType))
		{
			return false;
		}
		return true;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		if (weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName == "shotgun_walker" && raceType == 126)
		{
			return 0;
		}
		return -1;
	}
}

using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class KrissVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		int raceType = battleRoom.roomData.Data.RaceType;
		if (battleRoom.roomData.Data.FairFlag || RuleUtilty.IsGeneralPve(raceType) || raceType == 25 || raceType == 62)
		{
			return false;
		}
		return true;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		return -1;
	}
}

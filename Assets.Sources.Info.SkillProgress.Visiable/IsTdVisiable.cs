using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class IsTdVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		int raceType = battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsPveModel(raceType) && !RuleUtilty.IsGeneralPve(raceType))
		{
			return true;
		}
		return false;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		return -1;
	}
}

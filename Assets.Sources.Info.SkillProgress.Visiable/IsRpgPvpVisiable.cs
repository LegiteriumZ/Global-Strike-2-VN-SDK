using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class IsRpgPvpVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		if (!RuleUtilty.IsRpgPvp(battleRoom.roomData.Data.RaceType))
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

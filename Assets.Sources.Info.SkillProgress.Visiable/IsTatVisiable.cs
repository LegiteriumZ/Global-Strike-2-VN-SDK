using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class IsTatVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		if (battleRoom.roomData.Data.FreeType != "titForTat")
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

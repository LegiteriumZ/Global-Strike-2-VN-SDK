using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress;

public interface IVisiable
{
	bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom);

	int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType);
}

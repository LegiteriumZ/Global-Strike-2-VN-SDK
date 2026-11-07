using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class MirageDouBladeHeroVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		return true;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		if (weaponContext.isCurrentWeapon && weaponContext.currentWeaponEntity.hasBasicInfo && (raceType == 120 || raceType == 119 || raceType == 122))
		{
			return 1;
		}
		return 0;
	}
}

using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class PickaxeVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		return true;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		if (weaponContext.isCurrentWeapon && weaponContext.currentWeaponEntity.hasBasicInfo && (weaponContext.currentWeaponEntity.basicInfo.Data.EffectLevel & 1) > 0)
		{
			return 1;
		}
		return 0;
	}
}

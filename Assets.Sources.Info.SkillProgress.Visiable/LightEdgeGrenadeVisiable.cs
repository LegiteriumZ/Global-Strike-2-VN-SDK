using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Visiable;

public class LightEdgeGrenadeVisiable : IVisiable
{
	public bool IsModeShow(WeaponSkillTable.Row config, BattleRoomEntity battleRoom)
	{
		return true;
	}

	public int Visiable(WeaponContext weaponContext, PlayerEntity player, WeaponSkillTable.Row config, TimeComponent time, int raceType)
	{
		if (weaponContext.isCurrentWeapon && weaponContext.currentWeaponEntity.hasBasicInfo && (weaponContext.currentWeaponEntity.basicInfo.Data.EffectLevel & 8) > 0 && (RuleUtilty.IsPveModel(raceType) || RuleUtilty.IsBigHeadModel(raceType) || RuleUtilty.IsBioMode(raceType)))
		{
			return 1;
		}
		return 0;
	}
}

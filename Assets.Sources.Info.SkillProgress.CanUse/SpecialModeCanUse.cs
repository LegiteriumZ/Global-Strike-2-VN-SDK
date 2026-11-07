using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class SpecialModeCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (currentWeapon.hasBasicInfo)
		{
			return (currentWeapon.basicInfo.Data.WeaponFlag & 1) > 0;
		}
		return false;
	}
}

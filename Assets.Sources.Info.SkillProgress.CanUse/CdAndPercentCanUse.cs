using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class CdAndPercentCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (currentWeapon.hasBasicInfo && currentWeapon.basicInfo.Data.NextSkillTimer >= time.ClientRealTime)
		{
			return progress > config.CanUseValue;
		}
		return false;
	}
}

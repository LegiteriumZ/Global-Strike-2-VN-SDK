using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class MaxPower2CanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (currentWeapon.hasPower)
		{
			return currentWeapon.power.Power > currentWeapon.power.MaxPower2;
		}
		return false;
	}
}

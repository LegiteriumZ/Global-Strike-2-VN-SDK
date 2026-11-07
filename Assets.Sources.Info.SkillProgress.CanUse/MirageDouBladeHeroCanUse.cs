using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class MirageDouBladeHeroCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (progress >= 1f || (currentWeapon.hasPower && currentWeapon.power.RpgMaxPower > 0))
		{
			return true;
		}
		return false;
	}
}

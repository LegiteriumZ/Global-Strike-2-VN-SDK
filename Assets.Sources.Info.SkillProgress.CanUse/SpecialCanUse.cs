using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class SpecialCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (progress >= config.CanUseValue && currentWeapon.hasSpecial)
		{
			return currentWeapon.special.SpecialMode;
		}
		return false;
	}
}

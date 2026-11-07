using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class RifleOPticorCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (!currentWeapon.hasSpecial || !currentWeapon.special.SpecialMode)
		{
			return progress >= config.CanUseValue;
		}
		return true;
	}
}

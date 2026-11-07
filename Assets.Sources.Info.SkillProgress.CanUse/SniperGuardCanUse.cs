using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class SniperGuardCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (currentWeapon.hasSpecial && (currentWeapon.special.EffectLevel & 0x10) > 0)
		{
			return true;
		}
		return level > 0;
	}
}

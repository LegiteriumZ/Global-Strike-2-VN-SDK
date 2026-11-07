using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class MirageDouBladeCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (currentWeapon.hasSpecial)
		{
			if ((currentWeapon.special.EffectLevel & 0x10) > 0 && (currentWeapon.special.EffectLevel & 0x20) > 0)
			{
				if ((currentWeapon.special.EffectLevel & 0x80) > 0)
				{
					return false;
				}
				return true;
			}
			if (progress >= 1f || (currentWeapon.special.EffectLevel & 0x40) > 0)
			{
				return true;
			}
		}
		return false;
	}
}

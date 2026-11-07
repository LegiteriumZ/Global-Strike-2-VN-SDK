using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class Clip2CanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (currentWeapon.hasClip)
		{
			return currentWeapon.clip.Clip2 > 0;
		}
		return false;
	}
}

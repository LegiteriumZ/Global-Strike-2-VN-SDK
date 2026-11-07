using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class M99BarrettCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (!currentWeapon.hasBasicInfo)
		{
			return false;
		}
		if ((currentWeapon.basicInfo.Data.EffectLevel & 2) > 0)
		{
			return true;
		}
		if (currentWeapon.basicInfo.Data.NextSkillTimer - time.ServerTime <= 0 && progress >= 1f)
		{
			return true;
		}
		return false;
	}
}

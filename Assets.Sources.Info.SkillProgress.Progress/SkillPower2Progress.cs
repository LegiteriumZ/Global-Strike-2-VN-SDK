using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class SkillPower2Progress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (!currentWeapon.hasPower || currentWeapon.power.MaxPower2 < 1)
		{
			return 0f;
		}
		int num = currentWeapon.power.MaxPower2 / config.MaxLevel;
		return 1f * (float)currentWeapon.power.Power2 / (float)num;
	}
}

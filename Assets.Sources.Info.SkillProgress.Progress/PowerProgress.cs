using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class PowerProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (config.MaxLevel < 1)
		{
			return 0f;
		}
		if (!currentWeapon.hasPower || currentWeapon.power.MaxPower < 1)
		{
			return 0f;
		}
		int num = currentWeapon.power.MaxPower / config.MaxLevel;
		return 1f * (float)currentWeapon.power.Power / (float)num;
	}
}

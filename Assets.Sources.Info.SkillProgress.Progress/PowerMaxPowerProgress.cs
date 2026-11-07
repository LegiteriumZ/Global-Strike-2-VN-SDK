using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class PowerMaxPowerProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (!currentWeapon.hasPower || currentWeapon.power.MaxPower == 0)
		{
			return 0f;
		}
		return 1f * (float)currentWeapon.power.Power / (float)currentWeapon.power.MaxPower;
	}
}

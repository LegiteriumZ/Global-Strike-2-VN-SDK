using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class PowerLevelProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		return (currentWeapon.hasPower && currentWeapon.power.MaxPower >= 1) ? currentWeapon.power.MaxPower : 0;
	}
}

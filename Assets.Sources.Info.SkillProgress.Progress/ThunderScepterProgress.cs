using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class ThunderScepterProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (currentWeapon.hasPower && currentWeapon.power.MaxPower2 != 0)
		{
			return (float)currentWeapon.power.Power2 * 1f / (float)currentWeapon.power.MaxPower2;
		}
		return 0f;
	}
}

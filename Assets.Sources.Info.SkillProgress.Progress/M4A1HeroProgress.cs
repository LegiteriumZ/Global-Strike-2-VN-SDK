using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class M4A1HeroProgress : IProgress
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
		int num = (RuleUtilty.IsGeneralPve(raceType) ? (currentWeapon.power.MaxPower / config.MaxLevel) : currentWeapon.power.MaxPower);
		return 1f * (float)currentWeapon.power.Power / (float)num;
	}
}

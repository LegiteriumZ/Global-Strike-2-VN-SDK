using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class MirageDouBladeProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		float num = 0f;
		num = ((((currentWeapon.hasSpecial ? currentWeapon.special.EffectLevel : 0) & 0x20) <= 0) ? (currentWeapon.hasPower ? ((float)currentWeapon.power.MaxPower / 100f) : 0f) : ((!RuleUtilty.IsPveModel(raceType)) ? (currentWeapon.hasPower ? (1f - (float)currentWeapon.power.Power2 / 10000f) : 0f) : (currentWeapon.hasPower ? (1f - (float)currentWeapon.power.Power2 / 20000f) : 0f)));
		if (num > 1f)
		{
			num = 1f;
		}
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}
}

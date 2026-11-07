using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class EffectLevelCdProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		float num = (currentWeapon.hasBasicInfo ? (1f - (float)(currentWeapon.basicInfo.Data.NextSkillTimer - time.ClientRealTime) / (((currentWeapon.basicInfo.Data.EffectLevel & 2) > 0) ? ((float)config.MaxLevel * 0.5f) : ((float)config.MaxLevel))) : 0f);
		if (num > 1f)
		{
			num = 1f;
		}
		return num;
	}
}

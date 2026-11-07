using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using UnityEngine;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class SniperGuardProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		float value = 0f;
		if (currentWeapon.hasSpecial && currentWeapon.hasClip && currentWeapon.hasBasicInfo)
		{
			if ((currentWeapon.special.EffectLevel & 0x10) > 0)
			{
				if (currentWeapon.basicInfo.Data.WeaponTimer1 == 0L)
				{
					return 0f;
				}
				value = (float)currentWeapon.clip.Clip2 * 1f / (float)currentWeapon.basicInfo.Data.WeaponTimer1;
			}
			else
			{
				PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
				if (myPlayerEntity != null)
				{
					long num = currentWeapon.basicInfo.Data.NextSkillTimer - myPlayerEntity.GetClientTime();
					value = 1f - (float)num * 1f / 15000f;
				}
			}
		}
		return Mathf.Clamp01(value);
	}
}

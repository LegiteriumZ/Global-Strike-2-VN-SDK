using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class CdProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		float num = 0f;
		if (Contexts.sharedInstance.player.cameraOwnerEntity != null)
		{
			num = (currentWeapon.hasBasicInfo ? (1f - (float)(currentWeapon.basicInfo.Data.NextSkillTimer - Contexts.sharedInstance.player.cameraOwnerEntity.clientTime.ClientTime) / (float)config.MaxLevel) : 0f);
		}
		if (num > 1f)
		{
			num = 1f;
		}
		return num;
	}
}

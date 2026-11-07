using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class VoidLinkProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		float num = 0f;
		int num2 = 45000;
		if (RuleUtilty.IsPveModel(raceType))
		{
			num2 = 30000;
		}
		if (Contexts.sharedInstance.player.cameraOwnerEntity != null)
		{
			num = (currentWeapon.hasBasicInfo ? (1f - (float)(currentWeapon.basicInfo.Data.NextSkillTimer - Contexts.sharedInstance.player.cameraOwnerEntity.clientTime.ClientTime) / (float)num2) : 0f);
		}
		if (num > 1f)
		{
			num = 1f;
		}
		return num;
	}
}

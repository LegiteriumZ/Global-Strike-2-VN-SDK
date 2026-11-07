using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class HormoneInjectionProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		float num = 0f;
		if (RuleUtilty.IsGeneralPve(raceType))
		{
			if (currentWeapon.hasPower)
			{
				num = 1f * (float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() / (float)currentWeapon.power.RpgMaxPower;
			}
		}
		else if (currentWeapon.hasBasicInfo && currentWeapon.basicInfo.Data.Kill != 0)
		{
			num = 1f - (float)(currentWeapon.basicInfo.Data.NextSkillTimer - Contexts.sharedInstance.player.cameraOwnerEntity.clientTime.ClientTime) / (float)currentWeapon.basicInfo.Data.Kill;
		}
		if (num > 1f)
		{
			num = 1f;
		}
		return num;
	}
}

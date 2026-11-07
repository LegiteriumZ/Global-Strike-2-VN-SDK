using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class Type91DaggerProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (RuleUtilty.IsGeneralPve(raceType))
		{
			if (!currentWeapon.hasPower || currentWeapon.power.RpgMaxPower < 1)
			{
				return 0f;
			}
			return 1f * (float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() / (1f * (float)currentWeapon.power.RpgMaxPower);
		}
		float num = 0f;
		if (Contexts.sharedInstance.player.cameraOwnerEntity != null)
		{
			num = (currentWeapon.hasBasicInfo ? (1f - (float)(currentWeapon.basicInfo.Data.NextSkillTimer - Contexts.sharedInstance.player.cameraOwnerEntity.clientTime.ClientTime) / 50000f) : 0f);
		}
		if (num > 1f)
		{
			num = 1f;
		}
		return num;
	}
}

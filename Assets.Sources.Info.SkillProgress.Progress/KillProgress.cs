using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class KillProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		int num = (currentWeapon.hasBasicInfo ? currentWeapon.basicInfo.Data.Kill : 0);
		if (num <= 0)
		{
			return 0f;
		}
		return 1f * (float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() / (float)num;
	}
}

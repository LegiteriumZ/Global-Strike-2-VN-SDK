using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class TdSkillPowerProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (UiIEventCondition.Get_tdSkillStateData_TotalMp() < 1)
		{
			return 0f;
		}
		int num = UiIEventCondition.Get_tdSkillStateData_TotalMp() / config.MaxLevel;
		return 1f * (float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() / (float)num;
	}
}

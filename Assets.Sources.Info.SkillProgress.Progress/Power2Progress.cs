using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class Power2Progress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (!currentWeapon.hasPower || currentWeapon.power.MaxPower < 1)
		{
			return 0f;
		}
		return 1f * (float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() / (float)currentWeapon.power.MaxPower;
	}
}

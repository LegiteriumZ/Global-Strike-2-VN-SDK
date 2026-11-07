using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class InfiniteSkillPowerProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (!currentWeapon.hasSpecial || !currentWeapon.special.SpecialMode)
		{
			return 0f;
		}
		if (!currentWeapon.hasPower || currentWeapon.power.RpgMaxPower < 1)
		{
			return 0f;
		}
		return (float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() / (float)currentWeapon.power.RpgMaxPower;
	}
}

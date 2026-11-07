using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class RpgMaxPowerCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		if (currentWeapon.hasSpecial && currentWeapon.special.SpecialMode)
		{
			return true;
		}
		if (!currentWeapon.hasPower)
		{
			return false;
		}
		if (RuleUtilty.IsGeneralPve(UiIEventCondition.Get_uiRoomData_RaceType()))
		{
			if (UiIEventCondition.Get_tdSkillStateData_CurrentMp() > currentWeapon.power.RpgMaxPower)
			{
				return progress > 0f;
			}
			return false;
		}
		if (currentWeapon.power.Power > currentWeapon.power.RpgMaxPower)
		{
			return progress > 0f;
		}
		return false;
	}
}

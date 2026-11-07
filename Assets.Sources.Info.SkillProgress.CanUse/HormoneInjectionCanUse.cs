using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui.UiEventCondition;

namespace Assets.Sources.Info.SkillProgress.CanUse;

public class HormoneInjectionCanUse : ICanUse
{
	public bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsBioMode(raceType) || RuleUtilty.IsPveModel(raceType) || RuleUtilty.IsBigHeadModel(raceType))
		{
			if (currentWeapon.hasSpecial && currentWeapon.special.SpecialMode)
			{
				if (currentWeapon.hasPower && currentWeapon.power.Power > 0)
				{
					return true;
				}
				return false;
			}
			if (currentWeapon.hasBasicInfo && currentWeapon.hasPower && currentWeapon.basicInfo.Data.NextSkillTimer - time.ClientRealTime <= 0)
			{
				if (RuleUtilty.IsGeneralPve(raceType))
				{
					if (1f * (float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() > (float)currentWeapon.power.RpgMaxPower)
					{
						return true;
					}
					return false;
				}
				return true;
			}
		}
		return false;
	}
}

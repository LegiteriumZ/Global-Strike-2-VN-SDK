using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui.UiEventCondition;
using UnityEngine;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class RifleOPticorProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (!currentWeapon.hasPower)
		{
			return 0f;
		}
		if (currentWeapon.hasSpecial && currentWeapon.special.SpecialMode)
		{
			if (!RuleUtilty.IsPveModel(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType) || currentWeapon.power.RpgMaxPower == 0)
			{
				return 0f;
			}
			if (RuleUtilty.IsGeneralPve(raceType) && currentWeapon.power.RpgMaxPower != 0)
			{
				return Mathf.Clamp01((float)UiIEventCondition.Get_tdSkillStateData_CurrentMp() / (float)currentWeapon.power.RpgMaxPower);
			}
			if (RuleUtilty.IsOldPve(raceType) && currentWeapon.power.RpgMaxPower != 0)
			{
				return Mathf.Clamp01((float)currentWeapon.clip.Clip2 / (float)currentWeapon.power.RpgMaxPower);
			}
			return 1f;
		}
		return Mathf.Clamp01((float)currentWeapon.power.Power / (float)currentWeapon.power.MaxPower);
	}
}

using Assets.Sources.Components.Time;
using Assets.Sources.Constant;

namespace Assets.Sources.Info.SkillProgress.CanCd;

public class RifleOpticorCd : ICd
{
	public bool CdOver(WeaponEntity currentWeapon, TimeComponent time, int raceType)
	{
		if (currentWeapon.hasBasicInfo)
		{
			if (RuleUtilty.IsPveModel(raceType) && currentWeapon.power.RpgMaxPower != 0)
			{
				return time.ClientRealTime >= currentWeapon.basicInfo.Data.Power2;
			}
			return true;
		}
		return false;
	}
}

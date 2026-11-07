using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanCd;

public class NormalCd : ICd
{
	public bool CdOver(WeaponEntity currentWeapon, TimeComponent time, int raceType)
	{
		if (currentWeapon.hasBasicInfo && time.ClientRealTime >= currentWeapon.basicInfo.Data.NextSkillTimer)
		{
			return true;
		}
		return false;
	}
}

using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.CanCd;

public class NoneCd : ICd
{
	public bool CdOver(WeaponEntity currentWeapon, TimeComponent time, int raceType)
	{
		return true;
	}
}

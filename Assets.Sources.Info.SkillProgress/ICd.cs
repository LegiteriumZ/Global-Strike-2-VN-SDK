using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress;

public interface ICd
{
	bool CdOver(WeaponEntity currentWeapon, TimeComponent time, int raceType);
}

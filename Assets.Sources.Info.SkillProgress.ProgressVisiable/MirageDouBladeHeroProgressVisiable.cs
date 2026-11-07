using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.ProgressVisiable;

public class MirageDouBladeHeroProgressVisiable : IProgressVisiable
{
	public bool IsProgressVisiable(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (currentWeapon.hasPower && currentWeapon.power.RpgMaxPower > 0)
		{
			return false;
		}
		return true;
	}
}

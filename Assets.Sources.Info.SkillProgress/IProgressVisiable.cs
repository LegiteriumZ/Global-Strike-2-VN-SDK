using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress;

public interface IProgressVisiable
{
	bool IsProgressVisiable(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart);
}

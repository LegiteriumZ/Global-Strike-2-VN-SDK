using Assets.Generated.Table;

namespace Assets.Sources.Info.SkillProgress;

public interface ISpecial
{
	void GetBackImage(string[] backImage, WeaponSkillTable.Row config, WeaponEntity currentWeapon, bool isSpecial, int raceType, int level, bool isOver);

	void GetIcon(string[] icon, WeaponSkillTable.Row config, WeaponEntity currentWeapon, bool isSpecial, int level, bool isOver);

	bool GetSpecial(WeaponEntity currentWeapon);
}

using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress;

public interface ICanUse
{
	bool CanUse(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, float progress, int level);
}

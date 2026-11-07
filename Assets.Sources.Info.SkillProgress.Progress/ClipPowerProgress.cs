using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class ClipPowerProgress : IProgress
{
	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (currentWeapon.hasClip && currentWeapon.clip.Clip2 + currentWeapon.clip.CarryClip2 < 1)
		{
			return 0f;
		}
		return 1f;
	}
}

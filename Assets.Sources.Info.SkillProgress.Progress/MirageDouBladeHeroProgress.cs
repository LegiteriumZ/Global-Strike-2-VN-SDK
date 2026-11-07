using Assets.Generated.Table;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Info.SkillProgress.Progress;

public class MirageDouBladeHeroProgress : IProgress
{
	private bool showFull;

	public float GetProgress(WeaponEntity currentWeapon, WeaponSkillTable.Row config, TimeComponent time, int raceType, ref bool isInSpecial, ref int specialStart)
	{
		if (Contexts.sharedInstance.player.isMyPlayer)
		{
			showFull = !Contexts.sharedInstance.player.myPlayerEntity.isThirdView();
		}
		float num = 0f;
		if (currentWeapon.hasBasicInfo && currentWeapon.hasPower)
		{
			if (currentWeapon.power.RpgMaxPower == 0 && currentWeapon.basicInfo.Data.Kill == 0 && !showFull)
			{
				num = 1f;
			}
			else if (currentWeapon.power.RpgMaxPower > 0)
			{
				num = 0f;
				showFull = true;
			}
			else
			{
				if (currentWeapon.basicInfo.Data.Kill != 0)
				{
					showFull = false;
				}
				if (!showFull)
				{
					int num2 = currentWeapon.basicInfo.Data.Kill - Contexts.sharedInstance.player.cameraOwnerEntity.clientTime.ClientTime;
					num = 1f - (float)num2 / config.CanUseValue;
				}
			}
		}
		if (num > 1f)
		{
			num = 1f;
		}
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}
}

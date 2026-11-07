using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.AccuracyLogic;

public class R28RifleAccuracyLogic : IAccuracyLogic
{
	public void BeforeFire(int seed, PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
	{
		float num = (currentWeapon.special.SpecialMode ? 1f : 1f);
		float num2 = (currentWeapon.special.SpecialMode ? 0.3f : 0.3f);
		int num3 = (currentWeapon.special.SpecialMode ? 255 : 255);
		int shotsFired = currentWeapon.attack.ShotsFired;
		float num4 = currentWeapon.accuracy.Accuracy;
		if (num3 != -1)
		{
			num4 = (float)(shotsFired * shotsFired * shotsFired) * 1f / (float)num3 + num2;
			if (num4 > num)
			{
				num4 = num;
			}
		}
		currentWeapon.accuracy.Accuracy = num4;
	}
}

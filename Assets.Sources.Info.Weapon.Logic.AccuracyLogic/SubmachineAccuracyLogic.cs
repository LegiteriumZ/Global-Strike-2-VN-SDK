using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.AccuracyLogic;

public class SubmachineAccuracyLogic : IAccuracyLogic
{
	public void BeforeFire(int seed, PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
	{
		int shotsFired = currentWeapon.attack.ShotsFired;
		float maxInaccuracy = currentWeapon.basicInfo.Info.MaxInaccuracy;
		float accuracyOffset = currentWeapon.basicInfo.Info.AccuracyOffset;
		float accuracyDivisor = currentWeapon.basicInfo.Info.AccuracyDivisor;
		float num = currentWeapon.accuracy.Accuracy;
		if (!Mathf.Approximately(accuracyDivisor, -1f))
		{
			num = (float)(shotsFired * shotsFired) / accuracyDivisor + accuracyOffset;
			if (num > maxInaccuracy)
			{
				num = maxInaccuracy;
			}
		}
		currentWeapon.accuracy.Accuracy = num;
	}
}

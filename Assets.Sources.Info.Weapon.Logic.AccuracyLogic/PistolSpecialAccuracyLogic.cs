namespace Assets.Sources.Info.Weapon.Logic.AccuracyLogic;

public class PistolSpecialAccuracyLogic : PistolAccuracyLogic
{
	public override void BeforeFire(int seed, PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
	{
		float accuracy = currentWeapon.accuracy.Accuracy;
		accuracy -= Param * (0.3f - ((float)clientTime - currentWeapon.attack.NextAttackTimer + (float)currentWeapon.basicInfo.Info.AttackInterval + 400f) / 1000f);
		if (accuracy > MaxAccuracy)
		{
			accuracy = MaxAccuracy;
		}
		else if (accuracy < MinAccuracy)
		{
			accuracy = MinAccuracy;
		}
		currentWeapon.accuracy.Accuracy = accuracy;
	}
}

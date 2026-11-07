using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.AccuracyLogic;

public class PistolAccuracyLogic : IAccuracyLogic, IParamParse
{
	protected float MaxAccuracy = 0.92f;

	protected float MinAccuracy = 0.7f;

	protected float Param = 0.25f;

	public virtual void BeforeFire(int seed, PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
	{
		float accuracy = currentWeapon.accuracy.Accuracy;
		accuracy -= Param * (0.3f - ((float)clientTime - currentWeapon.attack.NextAttackTimer + (float)currentWeapon.basicInfo.Info.AttackInterval) / 1000f);
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

	public virtual void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 3);
		Param = restlts[0];
		MaxAccuracy = restlts[1];
		MinAccuracy = restlts[2];
	}
}

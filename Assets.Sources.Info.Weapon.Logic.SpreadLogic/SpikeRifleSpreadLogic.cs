using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

public class SpikeRifleSpreadLogic : ISpreadLogic, IParamParse
{
	internal float AirParam { get; set; }

	internal float DefaultParam { get; set; }

	internal float Fire2Param { get; set; }

	internal float Fire1Param { get; set; }

	internal float Fire0Param { get; set; }

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 5);
		AirParam = restlts[0];
		DefaultParam = restlts[1];
		Fire0Param = restlts[2];
		Fire1Param = restlts[3];
		Fire2Param = restlts[4];
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		if (!player.OnGround() && !isWeightlessness)
		{
			spread = AirParam * currentWeapon.accuracy.Accuracy;
		}
		else if ((currentWeapon.basicInfo.Data.EffectLevel & 2) > 0)
		{
			if (currentWeapon.attack.ShotsFired == 2)
			{
				spread = Fire2Param;
			}
			else if (currentWeapon.attack.ShotsFired == 1)
			{
				spread = Fire1Param;
			}
			else if (currentWeapon.attack.ShotsFired == 0)
			{
				spread = Fire0Param;
			}
			else
			{
				spread = DefaultParam * currentWeapon.accuracy.Accuracy;
			}
		}
		else
		{
			spread = DefaultParam * currentWeapon.accuracy.Accuracy;
		}
	}
}

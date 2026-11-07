using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class GatlingDouRageSpreadLogic : ISpreadLogic, IParamParse
{
	internal float DefaultParam { get; set; }

	internal float AirParam { get; set; }

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 2);
		AirParam = restlts[0];
		DefaultParam = restlts[1];
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float num = 0f;
		float num2 = ((player.OnGround() || isWeightlessness) ? (DefaultParam * currentWeapon.accuracy.Accuracy) : (AirParam * currentWeapon.accuracy.Accuracy));
		if (string.Compare(currentWeapon.basicInfo.Data.WeaponName, "gatling_dou_rage2") != 0 && string.Compare(currentWeapon.basicInfo.Data.WeaponName, "gatling_dou_rage_overload") != 0)
		{
			num = ((currentWeapon.basicInfo.Data.Kill == 3) ? 15f : ((currentWeapon.basicInfo.Data.Kill == 2) ? 25f : ((currentWeapon.basicInfo.Data.Kill != 1) ? 0f : 50f)));
		}
		else if (currentWeapon.basicInfo.Data.Kill == 3)
		{
			num = 15f;
		}
		spread = num2 + num2 * num * 0.01f;
	}
}

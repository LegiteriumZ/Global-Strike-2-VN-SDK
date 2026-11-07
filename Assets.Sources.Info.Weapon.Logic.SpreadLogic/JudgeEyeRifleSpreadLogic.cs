using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

public class JudgeEyeRifleSpreadLogic : ISpreadLogic, IParamParse
{
	internal float DefaultParam { get; set; }

	internal float AirParam { get; set; }

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 2);
		DefaultParam = restlts[0];
		AirParam = restlts[1];
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float num = ((!currentWeapon.special.SpecialMode && !(player.OnGround() || isWeightlessness)) ? AirParam : DefaultParam);
		spread = num * currentWeapon.accuracy.Accuracy;
	}
}

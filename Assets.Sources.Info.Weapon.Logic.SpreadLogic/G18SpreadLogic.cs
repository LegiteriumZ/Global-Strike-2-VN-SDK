using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class G18SpreadLogic : ISpreadLogic, IParamParse
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
		float num = (cmd.IsAttackOn ? ((player.OnGround() || isWeightlessness) ? DefaultParam : AirParam) : (player.OnGround() ? DefaultParam : AirParam));
		spread = num * currentWeapon.accuracy.Accuracy;
	}
}

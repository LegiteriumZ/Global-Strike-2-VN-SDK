using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Components.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class MechDouAkmSpreadLogic : ISpreadLogic, IParamParse
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
		int index = 13;
		float num = (((currentWeapon.GetComponent(index) as PowerComponent).Power2 >= 2) ? DefaultParam : ((player.OnGround() || isWeightlessness) ? DefaultParam : AirParam));
		spread = num * currentWeapon.accuracy.Accuracy;
	}
}

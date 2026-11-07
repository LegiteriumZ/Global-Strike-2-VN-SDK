using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

internal class SpecialPistolSpreadLogic : ISpreadLogic, IParamParse
{
	private PistolSpreadLogic special = new PistolSpreadLogic();

	private PistolSpreadLogic normal = new PistolSpreadLogic();

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		if (currentWeapon.special.SpecialMode)
		{
			special.BeforeFire(out spread, player, currentWeapon, cmd, isWeightlessness);
		}
		else
		{
			normal.BeforeFire(out spread, player, currentWeapon, cmd, isWeightlessness);
		}
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 8);
		special.SetParams(restlts, 0);
		normal.SetParams(restlts, 4);
	}
}

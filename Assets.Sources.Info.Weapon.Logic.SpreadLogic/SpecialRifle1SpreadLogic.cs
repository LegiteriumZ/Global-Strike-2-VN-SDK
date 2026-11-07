using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

public class SpecialRifle1SpreadLogic : ISpreadLogic, IParamParse
{
	private ISpreadLogic _specialLogic;

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 2);
		RifleSpreadLogic rifleSpreadLogic = new RifleSpreadLogic();
		rifleSpreadLogic.AirParam = restlts[0];
		rifleSpreadLogic.DefaultParam = restlts[1];
		_specialLogic = rifleSpreadLogic;
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float spread2 = 0f;
		if (currentWeapon.special.SpecialMode && _specialLogic != null)
		{
			_specialLogic.BeforeFire(out spread2, player, currentWeapon, cmd, isWeightlessness);
		}
		spread = spread2;
	}
}

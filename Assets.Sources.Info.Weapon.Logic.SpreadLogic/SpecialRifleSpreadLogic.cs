using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

public class SpecialRifleSpreadLogic : ISpreadLogic, IParamParse
{
	private ISpreadLogic _normaLogic;

	private ISpreadLogic _specialLogic;

	public void Parse(string param)
	{
		ParamParseHelp.ParseFloat(out var restlts, param, 4);
		RifleSpreadLogic rifleSpreadLogic = new RifleSpreadLogic();
		RifleSpreadLogic rifleSpreadLogic2 = new RifleSpreadLogic();
		rifleSpreadLogic.AirParam = restlts[0];
		rifleSpreadLogic.DefaultParam = restlts[1];
		rifleSpreadLogic2.AirParam = restlts[2];
		rifleSpreadLogic2.DefaultParam = restlts[3];
		_normaLogic = rifleSpreadLogic;
		_specialLogic = rifleSpreadLogic2;
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float spread2 = 0f;
		if (currentWeapon.special.SpecialMode && _specialLogic != null)
		{
			_specialLogic.BeforeFire(out spread2, player, currentWeapon, cmd, isWeightlessness);
		}
		else if (!currentWeapon.special.SpecialMode && _normaLogic != null)
		{
			_normaLogic.BeforeFire(out spread2, player, currentWeapon, cmd, isWeightlessness);
		}
		spread = spread2;
	}
}

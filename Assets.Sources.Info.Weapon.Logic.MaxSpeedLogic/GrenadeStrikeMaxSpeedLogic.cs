using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Components.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class GrenadeStrikeMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SpecialSpeed1;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		int index = 13;
		PowerComponent powerComponent = currentWeapon.GetComponent(index) as PowerComponent;
		return SpecialSpeed1 + powerComponent.RpgMaxPower;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 1);
		SpecialSpeed1 = restlts[0];
	}
}

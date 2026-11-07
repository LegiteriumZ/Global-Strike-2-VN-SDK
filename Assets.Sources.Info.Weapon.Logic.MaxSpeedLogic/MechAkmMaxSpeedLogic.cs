using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Components.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class MechAkmMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SpecialSpeed1;

	internal int SpecialSpeed2;

	internal int Speed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		int index = 13;
		PowerComponent powerComponent = currentWeapon.GetComponent(index) as PowerComponent;
		if (powerComponent.Power2 >= 2)
		{
			return SpecialSpeed2;
		}
		if (powerComponent.Power2 >= 1)
		{
			return SpecialSpeed1;
		}
		return Speed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 3);
		SpecialSpeed1 = restlts[0];
		SpecialSpeed2 = restlts[1];
		Speed = restlts[2];
	}
}

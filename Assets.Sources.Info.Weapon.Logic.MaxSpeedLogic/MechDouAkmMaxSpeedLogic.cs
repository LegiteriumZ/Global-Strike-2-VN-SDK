using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Components.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class MechDouAkmMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SpecialSpeed1;

	internal int Speed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		int index = 13;
		if ((currentWeapon.GetComponent(index) as PowerComponent).Power2 >= 1)
		{
			return SpecialSpeed1;
		}
		return Speed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		SpecialSpeed1 = restlts[0];
		Speed = restlts[1];
	}
}

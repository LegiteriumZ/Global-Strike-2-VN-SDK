using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class Qbz951stMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SpecialSpeed1;

	internal int SpecialSpeed2;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (player.fov.Fov != 90)
		{
			return SpecialSpeed1;
		}
		return SpecialSpeed2;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		SpecialSpeed1 = restlts[0];
		SpecialSpeed2 = restlts[1];
	}
}

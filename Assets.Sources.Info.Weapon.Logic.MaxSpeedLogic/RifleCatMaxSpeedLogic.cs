using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class RifleCatMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int Speed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		return Speed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 1);
		Speed = restlts[0];
	}
}

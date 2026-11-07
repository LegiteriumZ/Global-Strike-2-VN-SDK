using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class SniperMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int FovSpeed;

	internal int Speed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (player.fov.IsZoom())
		{
			return FovSpeed;
		}
		return Speed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		FovSpeed = restlts[0];
		Speed = restlts[1];
	}
}

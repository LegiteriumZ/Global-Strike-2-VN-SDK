using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class GhostTwinsMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int Speed;

	internal int FovSpeed;

	internal int SpecialSpeed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (!currentWeapon.special.SpecialMode)
		{
			if (player.fov.IsZoom())
			{
				return FovSpeed;
			}
			return Speed;
		}
		return SpecialSpeed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 3);
		FovSpeed = restlts[0];
		Speed = restlts[1];
		SpecialSpeed = restlts[2];
	}
}

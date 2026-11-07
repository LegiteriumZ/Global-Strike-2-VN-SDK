using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class G36cTacticMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int Speed;

	internal int FovSpeed;

	internal int SpecialSpeed;

	internal int SpecialFovSpeed;

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
		if (player.fov.IsZoom())
		{
			return SpecialFovSpeed;
		}
		return SpecialSpeed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 4);
		FovSpeed = restlts[0];
		Speed = restlts[1];
		SpecialFovSpeed = restlts[2];
		SpecialSpeed = restlts[3];
	}
}

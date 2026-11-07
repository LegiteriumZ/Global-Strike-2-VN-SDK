using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class CrystalBowMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SpecialSpeed;

	internal int NormalSpeed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (!player.fov.IsZoom())
		{
			return NormalSpeed + currentWeapon.power.Power2;
		}
		return SpecialSpeed + currentWeapon.power.Power2;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		SpecialSpeed = restlts[0];
		NormalSpeed = restlts[1];
	}
}

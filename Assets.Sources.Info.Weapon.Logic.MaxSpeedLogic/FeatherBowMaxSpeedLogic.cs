using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class FeatherBowMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int DefaultSpeed;

	internal int FovSpeed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		int result = DefaultSpeed;
		if ((currentWeapon.basicInfo.Data.EffectLevel & 2) <= 0 && 90 != player.fov.Fov)
		{
			result = FovSpeed;
		}
		return result;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		FovSpeed = restlts[0];
		DefaultSpeed = restlts[1];
	}
}

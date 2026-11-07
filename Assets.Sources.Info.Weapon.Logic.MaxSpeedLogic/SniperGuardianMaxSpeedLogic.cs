using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class SniperGuardianMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int DefaultSpeed;

	internal int FovSpeed;

	internal int EffectSpeed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		int num = DefaultSpeed;
		if (player.fov.IsZoom())
		{
			num = FovSpeed;
		}
		if ((currentWeapon.basicInfo.Data.EffectLevel & 1) > 0)
		{
			num = EffectSpeed;
		}
		int num2 = ((player.clientTime.ClientTime > currentWeapon.basicInfo.Data.RpgMaxPower) ? (currentWeapon.basicInfo.Data.Clip2 / 500 * 10) : 0);
		return num - num2;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 3);
		DefaultSpeed = restlts[0];
		FovSpeed = restlts[1];
		EffectSpeed = restlts[2];
	}
}

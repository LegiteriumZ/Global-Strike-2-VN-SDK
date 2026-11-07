using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class Dragonknight2021MaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int DefaultSpeed;

	internal int EffectSpeed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		int result = DefaultSpeed;
		if ((currentWeapon.basicInfo.Data.EffectLevel & 1) > 0)
		{
			result = EffectSpeed;
		}
		return result;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		DefaultSpeed = restlts[1];
		EffectSpeed = restlts[0];
	}
}

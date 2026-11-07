using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class HonorShieldMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int NormalSpeed;

	internal int SpecialSpeed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.power.Power > 200)
		{
			return SpecialSpeed;
		}
		return NormalSpeed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 2);
		NormalSpeed = restlts[0];
		SpecialSpeed = restlts[1];
	}
}

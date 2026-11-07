using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class PhaseWalkerMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int SpecialSpeed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.special.SpecialMode)
		{
			if (currentWeapon.basicInfo.Info.Name == "phase_walker1")
			{
				return (int)((double)SpecialSpeed * 1.2999999523162842);
			}
			if (currentWeapon.basicInfo.Info.Name == "phase_walker2")
			{
				return (int)((double)SpecialSpeed * 1.5);
			}
		}
		return SpecialSpeed;
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 1);
		SpecialSpeed = restlts[0];
	}
}

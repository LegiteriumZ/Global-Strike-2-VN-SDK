using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class DaggerBulletBursterMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int Speed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		double num = 1.0;
		if (currentWeapon.basicInfo.Data.Level > 35)
		{
			num = 1.2;
		}
		else if (currentWeapon.basicInfo.Data.Level > 15)
		{
			num = 1.1;
		}
		return (int)((double)Speed * num);
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 1);
		Speed = restlts[0];
	}
}

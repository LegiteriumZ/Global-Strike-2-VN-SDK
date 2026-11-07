using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class VoidLinkMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	internal int Speed;

	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		return (int)((double)Speed * (1.0 + (double)currentWeapon.basicInfo.Data.Clip2 * 0.01));
	}

	public void Parse(string param)
	{
		ParamParseHelp.ParseInt(out var restlts, param, 1);
		Speed = restlts[0];
	}
}

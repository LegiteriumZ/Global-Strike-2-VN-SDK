using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class RiderSwordMaxSpeedLogic : IMaxSpeedLogic, IParamParse
{
	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		return currentWeapon.basicInfo.Data.Kill;
	}

	public void Parse(string param)
	{
	}
}

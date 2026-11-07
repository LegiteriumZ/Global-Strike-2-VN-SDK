using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.MaxSpeedLogic;

internal class UnknownMaxSpeedLogic : IMaxSpeedLogic
{
	public int GetMaxSpeed(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.basicInfo.Info.WeaponType == 0)
		{
			return 635;
		}
		if (currentWeapon.basicInfo.Info.WeaponType == 2 || currentWeapon.basicInfo.Info.WeaponType == 3)
		{
			return 615;
		}
		return 609;
	}
}

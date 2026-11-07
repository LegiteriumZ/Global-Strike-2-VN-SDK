using Assets.Sources.Components.Interface.Info.Weapon;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponInfo.Info;

public class RifleMeleeWeaponInfo : RifleWeaponInfo, IRifleMeleeWeaponInfo, IWeaponInfo, IEntitsWeaponInfo
{
	public RifleMeleeWeaponInfo(string name, string attackType, string specialAttackType, bool isSharedPredication)
		: base(name, attackType, specialAttackType, isSharedPredication)
	{
	}
}

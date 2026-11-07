using Assets.Sources.Components.Interface.Info.Weapon;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponInfo.Info;

internal class ShotGunMeleeWeaponInfo : ShotGunWeaponInfo, IRifleMeleeWeaponInfo, IWeaponInfo, IEntitsWeaponInfo
{
	public ShotGunMeleeWeaponInfo(string name, string attackType, string specialAttackType, bool isSharedPredication)
		: base(name, attackType, specialAttackType, isSharedPredication)
	{
	}
}

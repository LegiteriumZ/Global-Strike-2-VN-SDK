using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Info.Weapon.Logic;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponInfo.Info;

internal class ShotGunWeaponInfo : DefaultWeaponInfo, IGunWeaponInfo, IWeaponInfo, IEntitsWeaponInfo, IMutilFireBullets
{
	public IKickbackLogic KickbackLogic { get; set; }

	public IRailLogic RailLogic { get; set; }

	public int FireBullets { get; set; }

	public ShotGunWeaponInfo(string name, string attackType, string specialAttackType, bool isSharedPredication)
		: base(name, attackType, specialAttackType, isSharedPredication)
	{
	}
}

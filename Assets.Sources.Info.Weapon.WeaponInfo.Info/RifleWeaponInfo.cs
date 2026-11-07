using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Info.Weapon.Logic;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponInfo.Info;

public class RifleWeaponInfo : DefaultWeaponInfo, IGunWeaponInfo, IWeaponInfo, IEntitsWeaponInfo
{
	public IKickbackLogic KickbackLogic { get; set; }

	public IRailLogic RailLogic { get; set; }

	public RifleWeaponInfo(string name, string attackType, string specialAttackType, bool isSharedPredication)
		: base(name, attackType, specialAttackType, isSharedPredication)
	{
	}
}

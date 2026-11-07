using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Info.Weapon.Logic;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon;

public interface IGunWeaponInfo : IWeaponInfo, IEntitsWeaponInfo
{
	IKickbackLogic KickbackLogic { get; }

	IRailLogic RailLogic { get; }
}

using Assets.Sources.Components.Interface.Info.Weapon;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon;

public interface IRifleMeleeWeaponInfo : IWeaponInfo, IEntitsWeaponInfo
{
	new int DelayAttackStabTime { get; }
}

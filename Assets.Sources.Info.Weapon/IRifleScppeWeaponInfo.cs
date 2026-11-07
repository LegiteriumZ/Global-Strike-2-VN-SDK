using Assets.Sources.Components.Interface.Info.Weapon;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon;

internal interface IRifleScppeWeaponInfo : IWeaponInfo, IEntitsWeaponInfo
{
	int FovAttackInterval { get; }

	int FovDelayTime { get; }
}

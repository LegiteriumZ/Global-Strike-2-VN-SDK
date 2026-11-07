using Assets.Sources.Components.Interface.Info.Weapon;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon;

public interface IMeleeWeaponInfo : IWeaponInfo, IEntitsWeaponInfo
{
	new int SlashSlashTime { get; }

	new int SlashStabTime { get; }

	new int StabSlashTime { get; }

	new int StabStabTime { get; }

	new int DelayAttackSlashTime { get; }

	new int DelayAttackStabTime { get; }
}

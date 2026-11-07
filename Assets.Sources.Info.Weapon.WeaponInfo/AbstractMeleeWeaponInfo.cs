using Assets.Sources.Components.Interface.Info.Weapon;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponInfo;

public abstract class AbstractMeleeWeaponInfo : DefaultWeaponInfo, IMeleeWeaponInfo, IWeaponInfo, IEntitsWeaponInfo
{
	public new int SlashSlashTime { get; set; }

	public new int SlashStabTime { get; set; }

	public new int StabSlashTime { get; set; }

	public new int StabStabTime { get; set; }

	public new int DelayAttackSlashTime { get; set; }

	public new int DelayAttackStabTime { get; set; }

	protected AbstractMeleeWeaponInfo(string name, string attackType, string specialAttackType, bool isSharedPredication)
		: base(name, attackType, specialAttackType, isSharedPredication)
	{
	}
}

using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom.Conditions;

public interface IWeaponCondition
{
	bool DoCondition(ref CommonWeaponArg arg);
}

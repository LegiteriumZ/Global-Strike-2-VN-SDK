using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public interface IWeaponAction
{
	WeaponActionResult.ACTION_RESULT DoAction(ref CommonWeaponArg arg);
}

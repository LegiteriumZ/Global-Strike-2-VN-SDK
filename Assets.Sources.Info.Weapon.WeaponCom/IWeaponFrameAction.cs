using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponCom;

public interface IWeaponFrameAction
{
	void DoFrameAction(ref CommonWeaponArg arg);
}

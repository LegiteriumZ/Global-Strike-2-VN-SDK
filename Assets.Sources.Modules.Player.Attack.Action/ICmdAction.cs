using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

public interface ICmdAction
{
	bool Action(ref CommonWeaponArg arg);
}

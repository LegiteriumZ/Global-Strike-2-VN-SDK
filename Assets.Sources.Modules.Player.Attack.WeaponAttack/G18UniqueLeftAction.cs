using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class G18UniqueLeftAction : RifleLeftAction
{
	public G18UniqueLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime) && arg.Player.viewAnim.ViewAnimInfo.StateId != 36 && arg.Player.viewAnim.ViewAnimInfo.StateId != 37 && arg.Player.viewAnim.ViewAnimInfo.StateId != 17)
		{
			return arg.Player.viewAnim.ViewAnimInfo.StateId != 46;
		}
		return false;
	}
}

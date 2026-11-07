using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class WhiteSwordGunLeftAction : PistolLeftAction
{
	public WhiteSwordGunLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.ShotsFired < 1 && WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime))
		{
			return arg.CurrentWeapon.basicInfo.Data.RpgMaxPower == 0;
		}
		return false;
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RedflashLeftAction : RifleLeftAction
{
	public RedflashLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.power.Power2 > 0)
		{
			return false;
		}
		return base.CanFire(ref arg);
	}
}

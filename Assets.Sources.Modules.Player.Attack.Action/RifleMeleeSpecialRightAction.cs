using Assets.Sources.Info.Weapon;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class RifleMeleeSpecialRightAction : RifleMeleeRightAction
{
	public RifleMeleeSpecialRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo && !arg.CurrentWeapon.special.SpecialMode)
		{
			return WeaponUtility.CanSecondaryAttack(ref arg);
		}
		return false;
	}
}

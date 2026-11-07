using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class VoidLinkRightAction : RifleMeleeRightAction
{
	public VoidLinkRightAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.Kill == 1)
		{
			return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
		}
		return false;
	}
}

using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class WhiteTigerLeftAction : M60LeftAction
{
	public WhiteTigerLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.Player.IsMoving() && arg.CurrentWeapon.special.SpecialMode)
		{
			return false;
		}
		return base.CanFire(ref arg);
	}
}

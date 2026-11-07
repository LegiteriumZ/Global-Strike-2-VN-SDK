using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolFrozenAirPistolLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public PistolFrozenAirPistolLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		return false;
	}
}

using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingLeftAction : RifleLeftAction
{
	public GatlingLeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.hasAttach && arg.CurrentWeapon.attach.Data is GatlingAttach)
		{
			if (base.CanFire(ref arg))
			{
				return (arg.CurrentWeapon.attach.Data as GatlingAttach).State.Equals(GatlingState.Ready);
			}
			return false;
		}
		return false;
	}
}

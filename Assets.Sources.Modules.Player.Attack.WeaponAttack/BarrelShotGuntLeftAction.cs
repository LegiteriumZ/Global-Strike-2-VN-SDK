using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BarrelShotGuntLeftAction : ShotGuntLeftAction
{
	public BarrelShotGuntLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddFire(SetNextSecAttackTime);
	}

	private int SetNextSecAttackTime(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.CurrentWeapon.attack.NextAttackTimer;
		return 0;
	}
}

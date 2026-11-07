using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class GrenadeRifleLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired >= 1)
		{
			return false;
		}
		return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
	}

	public GrenadeRifleLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddFire(FireUtility.FireDescClip);
		AddFire(FireUtility.LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(FireUtility.PlayFireSound);
	}
}

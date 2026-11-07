using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PhotonDeformationSpecialLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public PhotonDeformationSpecialLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddFire(LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(FireUtility.PlayFireSound);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.power.Power >= arg.CurrentWeapon.power.RpgMaxPower)
		{
			return WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime);
		}
		return false;
	}

	private int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
		return 0;
	}
}

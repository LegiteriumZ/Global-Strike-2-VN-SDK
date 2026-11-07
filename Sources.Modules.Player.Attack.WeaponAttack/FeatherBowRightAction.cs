using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class FeatherBowRightAction : IRightCmdAction, ICmdAction
{
	public bool Action(ref CommonWeaponArg arg)
	{
		if (!canSecondaryFire(arg.CurrentWeapon, arg.ClientTime))
		{
			return false;
		}
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 25000;
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 28);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 28);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return true;
	}

	private bool canSecondaryFire(WeaponEntity currentWeapon, int clientTime)
	{
		if ((currentWeapon.basicInfo.Data.EffectLevel & 0x20) > 0)
		{
			return (float)clientTime >= currentWeapon.attack.NextSecondaryAttackTimer;
		}
		return false;
	}
}

using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class G36CSwitchAction : IFrameCmdAction, ICmdAction
{
	public G36CSwitchAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.IsShowGun)
		{
			return false;
		}
		if (arg.CurrentWeapon.attack.NextAttackTimer >= (float)arg.ClientTime)
		{
			return false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 117))
		{
			return false;
		}
		int animId = (arg.CurrentWeapon.special.SpecialMode ? 37 : 36);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, animId);
		arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, animId);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		return true;
	}
}

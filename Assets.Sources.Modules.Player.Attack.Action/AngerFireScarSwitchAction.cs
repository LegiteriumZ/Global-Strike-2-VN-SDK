using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class AngerFireScarSwitchAction : IFrameCmdAction, ICmdAction
{
	public AngerFireScarSwitchAction(Contexts contexts)
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
		if (arg.Player.viewAnim.Equals(36) || arg.Player.viewAnim.Equals(37) || arg.Player.viewAnim.Equals(46) || arg.Player.viewAnim.Equals(17) || arg.Player.viewAnim.Equals(117))
		{
			return false;
		}
		if (arg.CurrentWeapon.special.EffectLevel == 0)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 117);
			return false;
		}
		int num = -1;
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			if (arg.CurrentWeapon.special.Level != 1)
			{
				return false;
			}
			num = 36;
		}
		else
		{
			num = 37;
		}
		PlayerAnimationUtility.SetViewAnimation(arg.Player, num);
		arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, num);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		return true;
	}
}

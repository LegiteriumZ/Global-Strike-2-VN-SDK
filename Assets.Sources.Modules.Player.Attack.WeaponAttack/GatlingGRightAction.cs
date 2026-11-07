using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GatlingGRightAction : IRightCmdAction, ICmdAction
{
	public GatlingGRightAction(Contexts contexts)
	{
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
		{
			return false;
		}
		if (arg.Player.DuckState() == 0)
		{
			return false;
		}
		if (arg.Player.HasState(16777216))
		{
			return false;
		}
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 100);
			PlayerAnimationUtility.SetLegsAnimation(arg.Player, 100);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		}
		else
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 99);
			PlayerAnimationUtility.SetLegsAnimation(arg.Player, 99);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			int viewAnimDuration2 = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration2;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration2;
		}
		arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		return true;
	}
}

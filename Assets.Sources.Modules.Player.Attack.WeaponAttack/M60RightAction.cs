using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M60RightAction : IRightCmdAction, ICmdAction
{
	public bool Action(ref CommonWeaponArg arg)
	{
		if ((float)arg.ClientTime < arg.CurrentWeapon.attack.NextAttackTimer)
		{
			return true;
		}
		if (!arg.Player.OnGround())
		{
			return true;
		}
		if (arg.Player.DuckState() == 0)
		{
			return true;
		}
		if (arg.Player.HasState(16777216))
		{
			return true;
		}
		if (arg.Player.DuckState() == 3)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 90);
				PlayerAnimationUtility.SetLegsAnimation(arg.Player, 90);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
				int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			}
			else
			{
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 89);
				PlayerAnimationUtility.SetLegsAnimation(arg.Player, 89);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
				int viewAnimDuration2 = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration2;
			}
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		}
		return true;
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class M4a1ProFrameAction : AbstractFrameAction
{
	public M4a1ProFrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		changeAnimLogic(ref arg);
		showgunLogic(ref arg);
		return true;
	}

	private void changeAnimLogic(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsSecondaryAttackOn && canChangeAnim(ref arg))
		{
			int num = 0;
			if (!arg.CurrentWeapon.special.SpecialMode)
			{
				arg.CurrentWeapon.special.SpecialMode = true;
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
				num = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + num;
			}
			else
			{
				arg.CurrentWeapon.special.SpecialMode = false;
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
				num = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + num;
			}
		}
	}

	private void showgunLogic(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.IsShowGun || !canChangeAnim(ref arg))
		{
			return;
		}
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
			}
		}
		else if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 117))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 117);
		}
	}

	private bool canChangeAnim(ref CommonWeaponArg arg)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36))
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37);
		}
		return false;
	}
}

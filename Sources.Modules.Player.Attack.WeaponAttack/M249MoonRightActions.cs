using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class M249MoonRightActions : AbstractFireAction, IRightCmdAction, ICmdAction
{
	public M249MoonRightActions(Contexts contexts)
		: base(contexts)
	{
		AddFire(LeftFireSetAnim);
		AddFire(FireNextAttack);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.RpgMaxPower < arg.CurrentWeapon.basicInfo.Data.Kill && arg.CurrentWeapon.basicInfo.Data.Kill != 0 && WeaponUtility.CanSecondaryAttack(ref arg))
		{
			return arg.CurrentWeapon.clip.CarryClip >= 50;
		}
		return false;
	}

	private static int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 28);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	private static int FireNextAttack(ref CommonWeaponArg arg)
	{
		ConsumeCarryClips(ref arg);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 28);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		return 0;
	}

	private static void ConsumeCarryClips(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.clip.CarryClip >= 50)
		{
			arg.CurrentWeapon.clip.CarryClip -= 50;
		}
		else
		{
			arg.CurrentWeapon.clip.CarryClip = 0;
		}
	}
}

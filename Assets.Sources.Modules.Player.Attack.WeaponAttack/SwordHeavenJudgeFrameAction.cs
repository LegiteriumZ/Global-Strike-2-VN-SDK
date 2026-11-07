using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SwordHeavenJudgeFrameAction : AbstractFrameAction
{
	public SwordHeavenJudgeFrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 69) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 48) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 70))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
		}
		if (CanSpecailToNoramlAni(ref arg) && CanQuitBlock(ref arg))
		{
			SpecialToNormalModel(ref arg);
		}
		if (arg.ClientTime > arg.CurrentWeapon.clip.Clip && arg.Cmd.IsSecondaryAttackOn && !arg.CurrentWeapon.special.SpecialMode && arg.Contexts.battleRoom.roomData.Data.RaceType != 30 && CanNormalToSpecailAni(ref arg))
		{
			NormalToSpecialModel(ref arg);
		}
		return true;
	}

	private void NormalToSpecialModel(ref CommonWeaponArg arg)
	{
		arg.Player.viewAnim.RightSpeed = ((arg.CurrentWeapon.power.Power2 != 0) ? 1.2f : 1f);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		if (arg.CurrentWeapon.clip.CarryClip2 == 4000)
		{
			arg.CurrentWeapon.power.RpgMaxPower = arg.ClientTime + 4000 + viewAnimDuration;
		}
		else
		{
			arg.CurrentWeapon.power.RpgMaxPower = arg.ClientTime + 2000 + viewAnimDuration;
		}
		arg.CurrentWeapon.special.SpecialMode = true;
	}

	private void SpecialToNormalModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		if (arg.CurrentWeapon.clip.CarryClip2 == 4000)
		{
			arg.CurrentWeapon.clip.Clip = arg.ClientTime + viewAnimDuration + 3000;
		}
		else
		{
			arg.CurrentWeapon.clip.Clip = arg.ClientTime + viewAnimDuration + 7000;
		}
		arg.CurrentWeapon.special.SpecialMode = false;
	}

	public bool CanQuitBlock(ref CommonWeaponArg arg)
	{
		if (arg.ClientTime > arg.CurrentWeapon.power.RpgMaxPower || arg.CurrentWeapon.basicInfo.Data.Kill == 1)
		{
			return true;
		}
		return false;
	}

	private bool CanNormalToSpecailAni(ref CommonWeaponArg arg)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 48) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 31) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 30) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 170) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 169) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 172) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 171) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 69))
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 70);
		}
		return false;
	}

	private bool CanSpecailToNoramlAni(ref CommonWeaponArg arg)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 70))
		{
			return PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 48);
		}
		return true;
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InfiniteHand1FrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	public InfiniteHand1FrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun && CanChangeAnim(arg.Player))
		{
			if (arg.CurrentWeapon.basicInfo.Data.EffectLevel == 0)
			{
				NormalToSpecialModel(ref arg);
			}
			else
			{
				SpecialToNormalModel(ref arg);
			}
		}
		return true;
	}

	private bool CanChangeAnim(PlayerEntity player)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(player, 44) && !PlayerAnimationUtility.IsViewAnimEqual(player, 117) && !PlayerAnimationUtility.IsViewAnimEqual(player, 20))
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(player, 72);
		}
		return false;
	}

	private void SpecialToNormalModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.basicInfo.Data.EffectLevel = 0;
		arg.CurrentWeapon.basicInfo.Info.AttackInterval = 80;
	}

	private void NormalToSpecialModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.basicInfo.Data.EffectLevel = 1;
		arg.CurrentWeapon.basicInfo.Info.AttackInterval = 100;
	}
}

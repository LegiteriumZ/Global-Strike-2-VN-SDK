using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Mk14RedflashPredicationSystem : AbstractAttackPredicationSystem
{
	internal class Mk14RedflashFrameAction : IFrameCmdAction, ICmdAction
	{
		public Mk14RedflashFrameAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && CanChangeAnim(arg.Player))
			{
				if (!arg.CurrentWeapon.special.SpecialMode)
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
				}
				else
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 117);
				}
			}
			return false;
		}
	}

	public Mk14RedflashPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new Mk14RedflashLeftAction(contexts));
		RightActions.Add(new Mk14RedflashRightAction(contexts));
		FrameActions.Add(new Mk14RedflashFrameAction(contexts));
	}

	public static bool CheckGameRule(int raceType)
	{
		if (!RuleUtilty.IsGeneralPve(raceType) && !RuleUtilty.IsPve(raceType) && !RuleUtilty.IsBioMode(raceType) && raceType != 19)
		{
			return raceType == 90;
		}
		return true;
	}

	public static bool CanChangeAnim(PlayerEntity player)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(player, 44))
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(player, 117);
		}
		return false;
	}
}

using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RpgRedflashPredicationSystem : AbstractAttackPredicationSystem
{
	internal class RpgRedflashFrameAction : IFrameCmdAction, ICmdAction
	{
		public RpgRedflashFrameAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (arg.Cmd.IsShowGun && CheckGameRule(raceType) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && arg.CurrentWeapon.special.EffectLevel != 2)
			{
				if (!arg.CurrentWeapon.special.SpecialMode)
				{
					NormalToSpecialModel(ref arg);
				}
				else
				{
					SpecialToNormalModel(ref arg);
				}
			}
			return false;
		}

		private bool CheckGameRule(int raceType)
		{
			if (!RuleUtilty.IsGeneralPve(raceType) && !RuleUtilty.IsPve(raceType))
			{
				return RuleUtilty.IsBioMode(raceType);
			}
			return true;
		}

		private void NormalToSpecialModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = true;
		}

		public void SpecialToNormalModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = false;
		}
	}

	public RpgRedflashPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RpgRedflashLeftAction(contexts));
		RightActions.Add(new RpgRedflashRightAction(contexts));
		FrameActions.Add(new RpgRedflashFrameAction(contexts));
	}
}

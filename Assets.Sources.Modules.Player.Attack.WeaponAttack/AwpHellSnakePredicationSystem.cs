using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AwpHellSnakePredicationSystem : AbstractAttackPredicationSystem
{
	internal class AwpHellSnakeFrameAction : IFrameCmdAction, ICmdAction
	{
		public AwpHellSnakeFrameAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsDemolitionOn && arg.CurrentWeapon.special.EffectLevel > 0 && arg.ClientTime > arg.CurrentWeapon.basicInfo.Data.NextSkillTimer && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && !arg.CurrentWeapon.special.SpecialMode)
			{
				arg.CurrentWeapon.special.SpecialMode = true;
				arg.CurrentWeapon.basicInfo.Data.NextSkillTimer = (uint)(arg.ClientTime + 5000);
				NormalToSpecialModel(ref arg);
			}
			if (arg.Cmd.IsDemolitionOn && arg.CurrentWeapon.special.EffectLevel > 0 && arg.ClientTime > arg.CurrentWeapon.basicInfo.Data.NextSkillTimer && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && arg.CurrentWeapon.special.SpecialMode)
			{
				arg.CurrentWeapon.special.SpecialMode = false;
				SpecialToNormalModel(ref arg);
			}
			return true;
		}

		private static void SpecialToNormalModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		}

		private static void NormalToSpecialModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		}
	}

	internal class AwpHellSnakeRightAction : IRightCmdAction, ICmdAction
	{
		private IRightCmdAction _fovRightCmdAction;

		public AwpHellSnakeRightAction(Contexts contexts)
		{
			_fovRightCmdAction = new FovRightAction(contexts);
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				return false;
			}
			return _fovRightCmdAction.Action(ref arg);
		}
	}

	internal class AwpHellSnakeLeftAction : ILeftCmdAction, ICmdAction
	{
		private ILeftCmdAction _rifleLeftAction;

		private ILeftCmdAction _specialLeftAction;

		public AwpHellSnakeLeftAction(Contexts contexts)
		{
			_rifleLeftAction = new RifleLeftAction(contexts);
			_specialLeftAction = new SpecialLeftAction(contexts);
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (!arg.CurrentWeapon.special.SpecialMode)
			{
				return _rifleLeftAction.Action(ref arg);
			}
			return _specialLeftAction.Action(ref arg);
		}
	}

	public class SpecialLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public SpecialLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireNextAttack);
			AddFire(FireUtility.FovLeft);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
			AddFire(SpecialToNormalModel);
		}

		private static int SpecialToNormalModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			return 0;
		}
	}

	public AwpHellSnakePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new AwpHellSnakeLeftAction(contexts));
		RightActions.Add(new AwpHellSnakeRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		FrameActions.Add(new AwpHellSnakeFrameAction(contexts));
	}
}

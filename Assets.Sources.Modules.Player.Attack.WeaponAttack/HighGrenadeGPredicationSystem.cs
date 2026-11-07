using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HighGrenadeGPredicationSystem : AbstractAttackPredicationSystem
{
	private class HighGrenadeGRightAction : IRightCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public HighGrenadeGRightAction(Contexts contexts)
		{
			_contexts = contexts;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (CanFire(ref arg))
			{
				arg.CurrentWeapon.attack.ShotsFired++;
				SetAttackAnim(ref arg);
				return true;
			}
			return false;
		}

		private void SetAttackAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 135);
		}

		private bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.attack.ShotsFired >= 1)
			{
				return false;
			}
			if (!WeaponUtility.CanSecondaryAttack(ref arg))
			{
				return false;
			}
			if (arg.CurrentWeapon.basicInfo.Data.Clip <= 0)
			{
				return false;
			}
			return true;
		}
	}

	private class HighGrenadeGFrameAction : IFrameCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public HighGrenadeGFrameAction(Contexts contexts)
		{
			_contexts = contexts;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 136) && !arg.Cmd.IsSecondaryAttackOn && arg.CurrentWeapon.attack.ShotsFired >= 1)
			{
				arg.CurrentWeapon.attack.ShotsFired = 0;
				WeaponUtility.DescClip(arg.CurrentWeapon);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 137);
				int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 137);
				viewAnimDuration += PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 16);
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
				return true;
			}
			return false;
		}
	}

	public HighGrenadeGPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		RightActions.Add(new HighGrenadeGRightAction(contexts));
		FrameActions.Add(new HighGrenadeGFrameAction(contexts));
	}
}

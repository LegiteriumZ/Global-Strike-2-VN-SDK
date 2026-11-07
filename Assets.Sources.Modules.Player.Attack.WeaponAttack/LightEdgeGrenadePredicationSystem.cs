using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class LightEdgeGrenadePredicationSystem : AbstractAttackPredicationSystem
{
	private class LightEdgeGrenadeLeftAction : ILeftCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public LightEdgeGrenadeLeftAction(Contexts contexts)
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
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 21);
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
			if (!canFirePlayer(ref arg))
			{
				return false;
			}
			return true;
		}

		private bool canFirePlayer(ref CommonWeaponArg arg)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 21) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 22))
			{
				return !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 23);
			}
			return false;
		}
	}

	private class LightEdgeGrenadeRightAction : IRightCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public LightEdgeGrenadeRightAction(Contexts contexts)
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
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 21);
		}

		private bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power > 0)
			{
				return false;
			}
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
			if (!canFirePlayer(ref arg))
			{
				return false;
			}
			return true;
		}

		private bool canFirePlayer(ref CommonWeaponArg arg)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 21) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 22))
			{
				return !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 23);
			}
			return false;
		}
	}

	private class LightEdgeGrenadeFrameAction : IFrameCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public LightEdgeGrenadeFrameAction(Contexts contexts)
		{
			_contexts = contexts;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 22) && !arg.Cmd.IsSecondaryAttackOn && !arg.Cmd.IsAttackOn && arg.CurrentWeapon.attack.ShotsFired >= 1)
			{
				arg.CurrentWeapon.attack.ShotsFired = 0;
				WeaponUtility.DescClip(arg.CurrentWeapon);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 23);
				int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 23);
				viewAnimDuration += PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 16);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
				return true;
			}
			return false;
		}
	}

	public LightEdgeGrenadePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new LightEdgeGrenadeLeftAction(contexts));
		RightActions.Add(new LightEdgeGrenadeRightAction(contexts));
		FrameActions.Add(new LightEdgeGrenadeFrameAction(contexts));
	}
}

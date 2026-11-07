using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SkyDomeBeaconPredicationSystem : AbstractAttackPredicationSystem
{
	private class SkyDomeBeaconRightAction : IRightCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public SkyDomeBeaconRightAction(Contexts contexts)
		{
			_contexts = contexts;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (CanFire(ref arg) && CanFirePlayer(ref arg))
			{
				SetAttackAnim(ref arg);
				WeaponUtility.DescClip(arg.CurrentWeapon);
				return true;
			}
			return false;
		}

		private void SetAttackAnim(ref CommonWeaponArg arg)
		{
			float num = 1f + (float)arg.CurrentWeapon.basicInfo.Data.Power2 * 0.01f;
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 15);
			arg.CurrentWeapon.basicInfo.Data.NextAttackTimer = (uint)((float)arg.ClientTime + (float)viewAnimDuration / num);
			arg.CurrentWeapon.basicInfo.Data.NextSecondaryAttackTimer = (uint)((float)arg.ClientTime + (float)viewAnimDuration / num);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			arg.Player.viewAnim.RightSpeed = num;
		}

		private bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
			{
				return false;
			}
			if (arg.CurrentWeapon.attack.ShotsFired >= 1)
			{
				return false;
			}
			if (arg.Player.GetClientTime() < arg.CurrentWeapon.basicInfo.Data.NextSecondaryAttackTimer)
			{
				return false;
			}
			if (arg.CurrentWeapon.basicInfo.Data.Clip == 0)
			{
				return false;
			}
			return true;
		}

		private bool CanFirePlayer(ref CommonWeaponArg arg)
		{
			if (arg.Player.GetClientTime() > arg.CurrentWeapon.basicInfo.Data.MaxPower)
			{
				return arg.CurrentWeapon.basicInfo.Data.Power == 0;
			}
			return false;
		}
	}

	private class SkyDomeBeaconLeftAction : ILeftCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public SkyDomeBeaconLeftAction(Contexts contexts)
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
			if (arg.Player.GetClientTime() < arg.CurrentWeapon.basicInfo.Data.NextAttackTimer)
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

	private class SkyDomeBeaconFrameAction : IFrameCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public SkyDomeBeaconFrameAction(Contexts contexts)
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

	public SkyDomeBeaconPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new SkyDomeBeaconLeftAction(contexts));
		FrameActions.Add(new SkyDomeBeaconFrameAction(contexts));
		RightActions.Add(new SkyDomeBeaconRightAction(contexts));
	}
}

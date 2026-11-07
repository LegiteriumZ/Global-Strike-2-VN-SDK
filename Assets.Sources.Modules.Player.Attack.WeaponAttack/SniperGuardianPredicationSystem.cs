using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class SniperGuardianPredicationSystem : AbstractAttackPredicationSystem
{
	internal class SniperGuardianLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public SniperGuardianLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(FovLeft);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime))
			{
				return arg.Player.viewAnim.ViewAnimInfo.StateId != 17;
			}
			return false;
		}

		private int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			arg.Player.viewAnim.RightSpeed = (float)(1.0 + (double)((float)arg.CurrentWeapon.basicInfo.Data.Clip2 / 500f) * 0.015);
			if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}

		private int FovLeft(ref CommonWeaponArg arg)
		{
			if (!arg.CurrentWeapon.basicInfo.Data.SpecialMode && arg.Player.fov.IsZoom())
			{
				arg.Player.fov.ResumeZoom = true;
				arg.Player.fov.LastFov = arg.Player.fov.Fov;
				arg.Player.fov.DelayFov = 90;
				arg.Player.fov.Fov = 90;
			}
			return 0;
		}
	}

	internal class SniperFovRightAction : IRightCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		public SniperFovRightAction(Contexts contexts)
		{
			_contexts = contexts;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			int num = 300;
			if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
			{
				return true;
			}
			if (!SwitchFireModeFrameAction.CanSwitchFireMode(ref arg))
			{
				return true;
			}
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + num;
			if (arg.Player.fov.Fov == 90)
			{
				arg.Player.fov.Fov = 40;
				arg.Player.fov.DelayFov = 40;
			}
			else if (arg.Player.fov.Fov == 40)
			{
				arg.Player.fov.Fov = 10;
				arg.Player.fov.DelayFov = 10;
			}
			else
			{
				arg.Player.fov.Fov = 90;
				arg.Player.fov.DelayFov = 90;
			}
			return true;
		}
	}

	internal class SwitchFireModeFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		public SwitchFireModeFrameAction(Contexts contexts)
			: base(contexts)
		{
			_messageContext = contexts.message;
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			UpdateAttackInterval(ref arg);
			SwitchFireMode(ref arg);
			return true;
		}

		private static void UpdateAttackInterval(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = (int)((double)(arg.CurrentWeapon.basicInfo.Data.SpecialMode ? 500 : 1300) * (1.0 - (double)(arg.CurrentWeapon.basicInfo.Data.Clip2 / 500) * 0.015));
		}

		private void SwitchFireMode(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && CanSwitchFireMode(ref arg))
			{
				if (arg.Player.fov.Fov != 90)
				{
					arg.Player.fov.ResetFov();
				}
				if (arg.CurrentWeapon.special.SpecialMode)
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("SemiAutomatic"));
					NotifyManager.ForceInvoke(38);
				}
				else
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("FullyAutomatic"));
					NotifyManager.ForceInvoke(38);
				}
				arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
			}
		}

		public static bool CanSwitchFireMode(ref CommonWeaponArg arg)
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17);
		}
	}

	public SniperGuardianPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new SniperGuardianLeftAction(contexts));
		RightActions.Add(new SniperFovRightAction(contexts));
		FrameActions.Add(new SwitchFireModeFrameAction(contexts));
	}
}

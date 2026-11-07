using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Qbz951stPredicationSystem : AbstractAttackPredicationSystem
{
	internal class Qbz951stLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public Qbz951stLeftAction(Contexts contexts)
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
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		public static int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			if (!arg.CurrentWeapon.special.SpecialMode && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 28))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			return 0;
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (CanFire(ref arg))
			{
				if (arg.CurrentWeapon.special.SpecialMode)
				{
					int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 29);
					arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
					arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
					FireUtility.RightFireQkhhAfterFire(ref arg);
					FireUtility.PlayFire3Sound(ref arg);
				}
				else
				{
					OnFireFunc.Step(ref arg);
				}
			}
			return true;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.special.EffectLevel == 1)
			{
				return false;
			}
			return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
		}
	}

	internal class Qbz951stFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		public Qbz951stFrameAction(Contexts contexts)
			: base(contexts)
		{
			_messageContext = contexts.message;
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun)
			{
				if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
				{
					return false;
				}
				if (CanSwitchMode(arg.Player))
				{
					if (!arg.CurrentWeapon.special.SpecialMode)
					{
						if (arg.CurrentWeapon.special.EffectLevel == 1)
						{
							_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("NoGrenade"));
							NotifyManager.ForceInvoke(38);
						}
						else
						{
							switchMode(ref arg);
						}
					}
					else
					{
						switchMode(ref arg);
					}
				}
			}
			return true;
		}

		private bool CanSwitchMode(PlayerEntity player)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 28) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46))
			{
				return !PlayerAnimationUtility.IsViewAnimEqual(player, 17);
			}
			return false;
		}

		private void switchMode(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 28);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 28);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		}
	}

	internal class Qbz951stRightAction : IRightCmdAction, ICmdAction
	{
		public Qbz951stRightAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			int num = 300;
			if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
			{
				return true;
			}
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + num;
			if (arg.Player.fov.Fov == 90)
			{
				arg.Player.fov.Fov = 40;
				arg.Player.fov.DelayFov = 40;
			}
			else
			{
				arg.Player.fov.Fov = 90;
				arg.Player.fov.DelayFov = 90;
			}
			return true;
		}
	}

	public Qbz951stPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new Qbz951stLeftAction(contexts));
		FrameActions.Add(new Qbz951stFrameAction(contexts));
		RightActions.Add(new Qbz951stRightAction(contexts));
	}
}

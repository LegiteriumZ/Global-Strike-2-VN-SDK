using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class AwmStrikePredicationSystem : AbstractAttackPredicationSystem
{
	internal class AwmStrikeFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		public AwmStrikeFrameAction(Contexts contexts)
			: base(contexts)
		{
			_messageContext = contexts.message;
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Clip2 != 1)
			{
				return true;
			}
			if (arg.Cmd.IsShowGun && arg.ClientTime > arg.CurrentWeapon.power.MaxPower2)
			{
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
				arg.CurrentWeapon.power.MaxPower2 = arg.ClientTime + 600;
			}
			return true;
		}
	}

	internal class AwmStrikeLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public AwmStrikeLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(FovLeft);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.LeftFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		public static int FireNextAttack(ref CommonWeaponArg arg)
		{
			int animId = (arg.CurrentWeapon.special.SpecialMode ? 32 : 15);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, animId);
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + viewAnimDuration);
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + viewAnimDuration);
			return 0;
		}

		public static int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
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

		public static int FovLeft(ref CommonWeaponArg arg)
		{
			if (!arg.CurrentWeapon.special.SpecialMode && arg.Player.fov.Fov != 90)
			{
				arg.Player.fov.LastFov = arg.Player.fov.Fov;
				arg.Player.fov.DelayFov = 90;
				arg.Player.fov.Fov = 90;
			}
			return 0;
		}
	}

	public AwmStrikePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new AwmStrikeLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		FrameActions.Add(new AwmStrikeFrameAction(contexts));
	}
}

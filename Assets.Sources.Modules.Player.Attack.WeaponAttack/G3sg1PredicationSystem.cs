using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class G3sg1PredicationSystem : AbstractAttackPredicationSystem
{
	internal class G3sg1FrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		private G3sg1LeftAction g3Sg1LeftAction;

		public G3sg1FrameAction(Contexts contexts)
			: base(contexts)
		{
			_messageContext = contexts.message;
			g3Sg1LeftAction = new G3sg1LeftAction(contexts);
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
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
			if (arg.CurrentWeapon.power.Power > 0)
			{
				g3Sg1LeftAction.Action(ref arg);
			}
			return true;
		}
	}

	internal class G3sg1LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public G3sg1LeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		private int FireDescClip(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power < 0)
			{
				WeaponUtility.DescClip(arg.CurrentWeapon);
			}
			return 0;
		}

		public static int FireNextAttack(ref CommonWeaponArg arg)
		{
			int num = 1;
			if (arg.CurrentWeapon.power.Power > 0 || arg.CurrentWeapon.special.SpecialMode)
			{
				num = 3;
			}
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval / num);
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.attack.ShotsFired >= 1 && !arg.CurrentWeapon.special.SpecialMode)
			{
				return false;
			}
			return base.CanFire(ref arg);
		}

		public int LeftFireSetAnim(ref CommonWeaponArg arg)
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

		public int FireSetSpread(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power > 0)
			{
				arg.CurrentWeapon.spread.Spread = 0.001f;
				return 0;
			}
			return FireUtility.FireSetSpread(ref arg);
		}
	}

	public G3sg1PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new G3sg1LeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new FovRightAction(contexts));
		FrameActions.Add(new FovFrameAction(contexts));
		FrameActions.Add(new G3sg1FrameAction(contexts));
	}
}

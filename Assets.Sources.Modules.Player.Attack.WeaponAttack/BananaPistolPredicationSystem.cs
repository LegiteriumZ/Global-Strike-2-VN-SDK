using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BananaPistolPredicationSystem : AbstractAttackPredicationSystem
{
	internal class BananaPistolRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
	{
		public BananaPistolRightAction(Contexts contexts)
			: base(contexts)
		{
			AddFire(RightFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(OnFire);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!arg.CurrentWeapon.special.SpecialMode)
			{
				return false;
			}
			if (arg.CurrentWeapon.basicInfo.Data.Kill != 0)
			{
				return false;
			}
			if (!WeaponUtility.CanSecondaryAttack(ref arg))
			{
				return false;
			}
			return true;
		}

		public static int RightFireSetAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 28);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 28);
			return 0;
		}

		public static int FireNextAttack(ref CommonWeaponArg arg)
		{
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 28);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			return 0;
		}
	}

	internal class BananaPistolFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		public BananaPistolFrameAction(Contexts contexts)
			: base(contexts)
		{
			_messageContext = contexts.message;
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if ((arg.Cmd.Buttons & 0x200) > 0 && arg.CurrentWeapon.basicInfo.Data.Kill != 0)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_NOTIMES"));
				NotifyManager.ForceInvoke(38);
			}
			return true;
		}
	}

	public BananaPistolPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new PistolLeftAction(contexts));
		RightActions.Add(new BananaPistolRightAction(contexts));
		FrameActions.Add(new BananaPistolFrameAction(contexts));
	}
}

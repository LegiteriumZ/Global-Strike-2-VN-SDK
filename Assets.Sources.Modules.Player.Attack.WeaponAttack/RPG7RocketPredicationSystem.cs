using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RPG7RocketPredicationSystem : AbstractAttackPredicationSystem
{
	internal class RPG7RocketFrameAction : IFrameCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		public RPG7RocketFrameAction(Contexts contexts)
		{
			_messageContext = contexts.message;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power == 0 && PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 15) && arg.Player.viewAnim.RemainTime < 100)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 39);
			}
			if (arg.CurrentWeapon.special.EffectLevel != 0 && PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 47))
			{
				if (arg.CurrentWeapon.special.EffectLevel == 1)
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_NO_ZENGQIANGHUOJIANDAN"));
					NotifyManager.ForceInvoke(38);
				}
				else if (arg.CurrentWeapon.special.EffectLevel == 3)
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_NO_XINHAODAN"));
					NotifyManager.ForceInvoke(38);
				}
				else if (arg.CurrentWeapon.special.EffectLevel == 4)
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_NO_ZENGQIANGXINHAODAN"));
					NotifyManager.ForceInvoke(38);
				}
				else
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_NO_QIANGCHIDANTOU"));
					NotifyManager.ForceInvoke(38);
				}
			}
			LeftAttackLogic(ref arg);
			return false;
		}

		private void LeftAttackLogic(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.EffectLevel != 0 && !((float)arg.ClientTime < arg.CurrentWeapon.attack.NextAttackTimer) && arg.CurrentWeapon.power.Power > 0 && arg.Cmd.IsAttackOn)
			{
				FireUtility.RightFireQkhhAfterFire(ref arg);
				FireUtility.PlayFireSound(ref arg);
				RPG7RocketLeftAction.FireSetAnim(ref arg);
			}
		}
	}

	public RPG7RocketPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RPG7RocketLeftAction(contexts));
		FrameActions.Add(new RPG7RocketFrameAction(contexts));
	}
}

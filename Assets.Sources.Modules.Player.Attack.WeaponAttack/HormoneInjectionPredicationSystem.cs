using Assets.Sources.Constant;
using Assets.Sources.Free.Data;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class HormoneInjectionPredicationSystem : AbstractAttackPredicationSystem
{
	private class HormoneInjectionFrameAction : IFrameCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		public HormoneInjectionFrameAction(Contexts contexts)
		{
			_messageContext = contexts.message;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			ShowWeapon(ref arg);
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				InjectRemedy(ref arg);
			}
			else
			{
				InjectHormone(ref arg);
			}
			return true;
		}

		private void ShowWeapon(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 15) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44))
			{
				if (!arg.CurrentWeapon.basicInfo.Data.WeaponName.EndsWith("2"))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
				}
				else if (RuleUtilty.IsGeneralPve(GameModelLocator.GetInstance().GameModel.RoomData.RaceType) && arg.CurrentWeapon.basicInfo.Data.Power2 == 1)
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_DRUG_EFFECT_ACTIVE_CAN_NOT_SWITCH"));
					NotifyManager.ForceInvoke(38);
				}
			}
		}

		private void InjectRemedy(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsAttackOn && CheckRemedyCondition(ref arg))
			{
				SetFireAnim(ref arg);
			}
		}

		private bool CheckRemedyCondition(ref CommonWeaponArg arg)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 15))
			{
				return false;
			}
			if (arg.CurrentWeapon.power.Power == 0)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_NO_SYNTHETIC_REMEDY"));
				NotifyManager.ForceInvoke(38);
				return false;
			}
			return arg.ClientTime > arg.CurrentWeapon.basicInfo.Data.NextAttackTimer;
		}

		private void SetFireAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		}

		private void InjectHormone(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsAttackOn && arg.Cmd.IsAttackOn && CheckHormoneCondition(ref arg))
			{
				SetFireAnim(ref arg);
			}
		}

		private bool CheckHormoneCondition(ref CommonWeaponArg arg)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 15))
			{
				return false;
			}
			bool flag = true;
			if (arg.CurrentWeapon.power.RpgMaxPower > 0)
			{
				flag = UiIEventCondition.Get_tdSkillStateData_CurrentMp() >= arg.CurrentWeapon.power.RpgMaxPower;
			}
			if (!flag)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_NOENERGY"));
				NotifyManager.ForceInvoke(38);
				return false;
			}
			if (arg.ClientTime > arg.CurrentWeapon.basicInfo.Data.NextSkillTimer)
			{
				return true;
			}
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_HORMONE_COOL_DOWN"));
			NotifyManager.ForceInvoke(38);
			return false;
		}
	}

	public HormoneInjectionPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		FrameActions.Add(new HormoneInjectionFrameAction(contexts));
	}
}

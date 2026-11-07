using Assets.Sources.Constant;
using Assets.Sources.Free.Data;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Mk14RedflashRightAction : IRightCmdAction, ICmdAction
{
	private readonly MessageContext _messageContext;

	public Mk14RedflashRightAction(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (Mk14RedflashPredicationSystem.CheckGameRule(GameModelLocator.GetInstance().GameModel.RoomData.RaceType))
		{
			if (Mk14RedflashPredicationSystem.CanChangeAnim(arg.Player))
			{
				if (!arg.CurrentWeapon.special.SpecialMode)
				{
					if (CheckPowerClip(arg.CurrentWeapon))
					{
						_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("NoMK14Grenade"));
						NotifyManager.ForceInvoke(38);
						return false;
					}
					NormalToSpecialModel(ref arg);
				}
				else
				{
					SpecialToNormalModel(ref arg);
				}
			}
		}
		else
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CAN_NOT_USE"));
			NotifyManager.ForceInvoke(38);
		}
		return true;
	}

	private void NormalToSpecialModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.special.SpecialMode = true;
	}

	private void SpecialToNormalModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.special.SpecialMode = false;
	}

	private bool CheckPowerClip(WeaponEntity currentWeapon)
	{
		if (RuleUtilty.IsGeneralPve(GameModelLocator.GetInstance().GameModel.RoomData.RaceType))
		{
			return currentWeapon.power.Power < currentWeapon.power.RpgMaxPower;
		}
		return currentWeapon.power.Power2 == 0;
	}
}

using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class VoidSpear1FrameAction : NormalFrameAction
{
	public VoidSpear1FrameAction(Contexts contexts)
		: base(contexts)
	{
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun)
		{
			if (CanChangeTimeLimit(ref arg))
			{
				if (CanChangeAnimationLimit(ref arg))
				{
					if (CanNormalToSpecailAni(ref arg))
					{
						NormalToSpecialModel(ref arg);
					}
					else if (CanSpecailToNoramlAni(ref arg))
					{
						SpecialToNormalModel(ref arg);
					}
				}
			}
			else
			{
				float num = Mathf.Ceil((float)(arg.CurrentWeapon.basicInfo.Data.WeaponTimer1 - arg.Player.clientTime.ClientTime) / 1000f);
				Contexts.sharedInstance.message.messageRemindData.SetMessage(ScriptLocalization.Get("WAIT_TIME_CHANGE_WEAPON").Replace("%s", StringCache.IntToString((int)num)));
				NotifyManager.ForceInvoke(38);
			}
		}
		return true;
	}

	protected override void NormalToSpecialModel(ref CommonWeaponArg arg)
	{
		if (arg.Player.HasState(1) && !RuleUtilty.IsPveModel(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			Contexts.sharedInstance.message.messageRemindData.SetMessage(ScriptLocalization.Get("EV_VOID_SPEAR_NOT_CHANGED"));
			NotifyManager.ForceInvoke(38);
			return;
		}
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.special.SpecialMode = true;
	}

	protected bool CanChangeTimeLimit(ref CommonWeaponArg arg)
	{
		if (arg.Player.clientTime.ClientTime > arg.CurrentWeapon.basicInfo.Data.WeaponTimer1)
		{
			return true;
		}
		return false;
	}

	protected bool CanChangeAnimationLimit(ref CommonWeaponArg arg)
	{
		if (!arg.Player.viewAnim.Equals(36) && !arg.Player.viewAnim.Equals(37) && !arg.Player.viewAnim.Equals(20) && !arg.Player.viewAnim.Equals(41) && !arg.Player.viewAnim.Equals(72))
		{
			return true;
		}
		return false;
	}
}

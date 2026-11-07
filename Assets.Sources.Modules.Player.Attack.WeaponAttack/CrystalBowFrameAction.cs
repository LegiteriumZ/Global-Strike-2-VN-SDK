using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class CrystalBowFrameAction : AbstractFrameAction
{
	private readonly MessageContext _messageContext;

	public CrystalBowFrameAction(Contexts contexts)
		: base(contexts)
	{
		_messageContext = contexts.message;
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		base.Action(ref arg);
		if (arg.CurrentWeapon.basicInfo.Data.Kill != 1 && arg.CurrentWeapon.basicInfo.Data.Kill != 2)
		{
			return false;
		}
		if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.basicInfo.Info.AttackInterval != 500)
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = 500;
		}
		else if (!arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.basicInfo.Info.AttackInterval != 1300)
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = 1300;
		}
		if ((arg.Cmd.Buttons & 0x10000) > 0 && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17))
		{
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
			if (UiIEventCondition.Get_uiCross_SpecialMode())
			{
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = 500;
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_CRYSTAL_BOW_DAOXIANG"));
				NotifyManager.ForceInvoke(38);
			}
			else
			{
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = 1300;
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_CRYSTAL_BOW_JICHU"));
				NotifyManager.ForceInvoke(38);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 17);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 17);
		}
		return true;
	}
}

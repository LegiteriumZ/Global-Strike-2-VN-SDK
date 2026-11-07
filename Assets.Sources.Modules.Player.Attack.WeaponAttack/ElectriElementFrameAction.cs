using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ElectriElementFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	private readonly MessageContext _messageContext;

	public ElectriElementFrameAction(Contexts contexts)
		: base(contexts)
	{
		_messageContext = contexts.message;
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsSecondaryAttackOn && (float)arg.ClientTime > arg.CurrentWeapon.attack.NextSecondaryAttackTimer)
		{
			if (arg.CurrentWeapon.power.Power2 == 1)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("NOENERGY_CAN_NOT_USE"));
				NotifyManager.ForceInvoke(38);
			}
			else if (arg.CurrentWeapon.power.Power2 == 2)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("NOFLASH_CAN_NOT_USE"));
				NotifyManager.ForceInvoke(38);
			}
		}
		return true;
	}
}

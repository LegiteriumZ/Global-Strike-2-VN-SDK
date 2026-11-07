using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GrenadeRifleRightAction : IRightCmdAction, ICmdAction
{
	private MessageContext _messageContext;

	public GrenadeRifleRightAction(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer <= (float)arg.ClientTime)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 300;
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("OpenInfraredGuidMode"));
				NotifyManager.ForceInvoke(38);
			}
			else
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CloseInfraredGuidMode"));
				NotifyManager.ForceInvoke(38);
			}
		}
		return true;
	}
}

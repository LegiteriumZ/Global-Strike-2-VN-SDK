using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GlockRedflashRightAction : IRightCmdAction, ICmdAction
{
	private MessageContext _messageContext;

	public GlockRedflashRightAction(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
		{
			return true;
		}
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 300);
		_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get(arg.CurrentWeapon.special.SpecialMode ? "ChangeOneMode" : "ChangeThreeMode"));
		NotifyManager.ForceInvoke(38);
		arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		return true;
	}
}

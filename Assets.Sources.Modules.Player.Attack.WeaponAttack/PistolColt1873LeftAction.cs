using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolColt1873LeftAction : PistolLeftAction
{
	private readonly MessageContext _messageContext;

	public PistolColt1873LeftAction(Contexts contexts)
		: base(contexts)
	{
		_messageContext = contexts.message;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (!arg.Cmd.IsSecondaryAttackOn)
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("ClickRightBeforeFire"));
			NotifyManager.ForceInvoke(38);
		}
		if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime) && arg.Cmd.IsSecondaryAttackOn)
		{
			return arg.CurrentWeapon.attack.ShotsFired < 1;
		}
		return false;
	}
}

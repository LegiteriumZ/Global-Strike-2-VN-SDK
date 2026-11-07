using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Spas12FrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	private readonly MessageContext _messageContext;

	public Spas12FrameAction(Contexts contexts)
		: base(contexts)
	{
		_messageContext = contexts.message;
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsSecondaryAttackOn && arg.ClientTime > arg.CurrentWeapon.power.MaxPower2 && CanChangeAnim(arg.Player))
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("SemiAutomatic"));
				NotifyManager.ForceInvoke(38);
			}
			else
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("PUMP_ACTION"));
				NotifyManager.ForceInvoke(38);
			}
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
			arg.CurrentWeapon.power.MaxPower2 = arg.ClientTime + 600;
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = 1400;
			}
			else
			{
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = 700;
			}
		}
		if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.reload.IsStartReload && arg.Cmd.IsReloadOn)
		{
			(arg.CurrentWeapon.attach.Data as Spas12Attach).ReloadCount++;
		}
		return true;
	}

	protected bool CanChangeAnim(PlayerEntity player)
	{
		int stateId = player.viewAnim.ViewAnimInfo.StateId;
		if (stateId != 33 && stateId != 34 && stateId != 35)
		{
			return true;
		}
		return false;
	}
}

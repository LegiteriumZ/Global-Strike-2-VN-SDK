using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InfiniteHand1Change2FrameAction : IFrameCmdAction, ICmdAction
{
	private readonly MessageContext _messageContext;

	private int last;

	public InfiniteHand1Change2FrameAction(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.special.Kil == 1 && arg.Cmd.IsAttackOn)
		{
			if (arg.Player.clientTime.ClientTime < arg.CurrentWeapon.power.Power2)
			{
				_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("INFINITE_HAND_V_USE"), (arg.CurrentWeapon.power.Power2 - arg.Player.clientTime.ClientTime) / 1000));
				NotifyManager.ForceInvoke(38);
			}
			else if (arg.CurrentWeapon.power.Power >= arg.CurrentWeapon.power.MaxPower2 && arg.ClientTime - last > 100)
			{
				if (FireUtility.TraceWorldInDistance(arg.Player, arg.CurrentWeapon) != Vector3.zero)
				{
					FireUtility.PlayFire4Sound(ref arg);
				}
				last = arg.ClientTime;
			}
		}
		return true;
	}
}

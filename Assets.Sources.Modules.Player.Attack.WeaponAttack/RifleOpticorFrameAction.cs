using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleOpticorFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
{
	private readonly MessageContext _messageContext;

	public RifleOpticorFrameAction(Contexts contexts)
		: base(contexts)
	{
		_messageContext = contexts.message;
	}

	public override bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun && CanChangeAnim(arg.Player))
		{
			if (arg.CurrentWeapon.basicInfo.Data.EffectLevel == 0)
			{
				NormalToSpecialModel(ref arg);
			}
			else
			{
				SpecialToNormalModel(ref arg);
			}
		}
		if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.basicInfo.Data.RpgMaxPower > 0 && arg.CurrentWeapon.basicInfo.Data.NextSkillTimer == 0L && arg.Cmd.IsDemolitionOn && arg.Player.clientTime.ClientTime < arg.CurrentWeapon.power.Power2)
		{
			_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("INFINITE_HAND_V_USE"), (arg.CurrentWeapon.power.Power2 - arg.Player.clientTime.ClientTime) / 1000));
			NotifyManager.ForceInvoke(38);
		}
		return true;
	}

	private bool CanChangeAnim(PlayerEntity player)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(player, 20) && !PlayerAnimationUtility.IsViewAnimEqual(player, 69) && !PlayerAnimationUtility.IsViewAnimEqual(player, 70) && !PlayerAnimationUtility.IsViewAnimEqual(player, 71))
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(player, 72);
		}
		return false;
	}

	private void SpecialToNormalModel(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		arg.CurrentWeapon.special.SpecialMode = true;
		arg.CurrentWeapon.power.Power = 0;
	}

	private void NormalToSpecialModel(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.power.Power >= arg.CurrentWeapon.power.MaxPower)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = false;
		}
	}
}

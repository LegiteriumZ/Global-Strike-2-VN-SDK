using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BurstPistolRightAction : IRightCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public BurstPistolRightAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
		{
			return true;
		}
		if (PlayerAnimationUtility.IsViewAnimExist(arg.Player, 37) && PlayerAnimationUtility.IsViewAnimExist(arg.Player, 36))
		{
			int animId = (arg.CurrentWeapon.special.SpecialMode ? 37 : 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, animId);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, animId);
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		}
		else
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 300);
		}
		_contexts.message.messageRemindData.SetMessage(ScriptLocalization.Get(arg.CurrentWeapon.special.SpecialMode ? "ChangeOneMode" : "ChangeThreeMode"));
		NotifyManager.ForceInvoke(38);
		arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		return true;
	}
}

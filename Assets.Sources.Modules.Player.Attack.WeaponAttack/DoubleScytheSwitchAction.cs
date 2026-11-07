using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleScytheSwitchAction : IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public DoubleScytheSwitchAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsReloadOn && arg.CurrentWeapon.attack.NextAttackTimer < (float)arg.ClientTime)
		{
			int animId = (arg.CurrentWeapon.special.SpecialMode ? 37 : 36);
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
			PlayerAnimationUtility.SetViewAnimation(arg.Player, animId);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, animId);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		}
		return true;
	}
}

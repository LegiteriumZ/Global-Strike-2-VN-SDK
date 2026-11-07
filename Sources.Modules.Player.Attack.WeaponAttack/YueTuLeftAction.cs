using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class YueTuLeftAction : ILeftCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public YueTuLeftAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime) && arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			arg.CurrentWeapon.attack.ShotsFired++;
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
			PlayerAnimationUtility.SetLegsAnimation(arg.Player, 51);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 64);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			FireUtility.PlaySecFireSound(ref arg);
		}
		return true;
	}
}

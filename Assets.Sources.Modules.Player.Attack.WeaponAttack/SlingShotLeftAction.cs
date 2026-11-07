using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SlingShotLeftAction : ILeftCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public SlingShotLeftAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime) && arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			arg.CurrentWeapon.attack.ShotsFired++;
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 25);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 25);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			FireUtility.PlaySecFireSound(ref arg);
		}
		return true;
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SlingShotFrameAction : IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public SlingShotFrameAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	protected bool CanFire(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 25))
		{
			return false;
		}
		if (arg.Cmd.IsAttackOn)
		{
			return false;
		}
		if (arg.CurrentWeapon.attack.ShotsFired < 1)
		{
			return false;
		}
		return true;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (CanFire(ref arg))
		{
			arg.CurrentWeapon.attack.ShotsFired = 0;
			FireUtility.FireDescClip(ref arg);
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 15);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			FireUtility.PlayFireSound(ref arg);
		}
		return true;
	}
}

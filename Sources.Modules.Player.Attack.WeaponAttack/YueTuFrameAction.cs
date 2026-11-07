using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Sources.Modules.Player.Attack.WeaponAttack;

internal class YueTuFrameAction : IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public YueTuFrameAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	protected bool CanFire(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
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
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 65);
			PlayerAnimationUtility.SetLegsAnimation(arg.Player, 53);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 65);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			FireUtility.PlayFireSound(ref arg);
		}
		return true;
	}
}

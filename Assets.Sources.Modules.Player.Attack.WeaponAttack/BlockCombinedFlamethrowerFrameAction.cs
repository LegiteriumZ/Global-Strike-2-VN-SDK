using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlockCombinedFlamethrowerFrameAction : IFrameCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public BlockCombinedFlamethrowerFrameAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64))
		{
			return true;
		}
		if (!arg.Cmd.IsAttackOn && arg.CurrentWeapon.attack.ShotsFired >= 1)
		{
			arg.CurrentWeapon.attack.ShotsFired = 0;
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 65);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 65);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		}
		return true;
	}
}

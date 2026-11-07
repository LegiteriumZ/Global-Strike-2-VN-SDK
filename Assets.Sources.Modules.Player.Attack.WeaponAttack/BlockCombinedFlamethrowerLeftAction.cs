using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BlockCombinedFlamethrowerLeftAction : ILeftCmdAction, ICmdAction
{
	private readonly Contexts _contexts;

	public BlockCombinedFlamethrowerLeftAction(Contexts contexts)
	{
		_contexts = contexts;
	}

	public bool Action(ref CommonWeaponArg arg)
	{
		if (!WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime))
		{
			return true;
		}
		FireUtility.PlayFireSound(ref arg);
		if (arg.CurrentWeapon.attack.ShotsFired >= 1)
		{
			FireUtility.FireDescClip(ref arg);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 50;
			return true;
		}
		arg.CurrentWeapon.attack.ShotsFired++;
		PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 64);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		return true;
	}
}

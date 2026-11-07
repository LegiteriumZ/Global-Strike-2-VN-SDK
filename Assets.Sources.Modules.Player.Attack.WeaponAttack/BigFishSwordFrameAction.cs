using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BigFishSwordFrameAction : AbstractKnifeFrameAction
{
	protected override bool CheckDelayAttack(ref CommonWeaponArg arg)
	{
		if (!arg.Player.viewAnim.Equals(29) && !arg.Player.viewAnim.Equals(28) && !arg.Player.viewAnim.Equals(96) && !arg.Player.viewAnim.Equals(31) && !arg.Player.viewAnim.Equals(20))
		{
			return false;
		}
		return true;
	}

	protected override void PostFrame(ref CommonWeaponArg arg)
	{
		ShowWeapon(ref arg);
	}

	private void ShowWeapon(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.IsShowGun && CanShowWeaponAnim(ref arg))
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
		}
	}

	private bool CanShowWeaponAnim(ref CommonWeaponArg arg)
	{
		if (!arg.Player.viewAnim.Equals(44) && !arg.Player.viewAnim.Equals(31) && !arg.Player.viewAnim.Equals(29) && !arg.Player.viewAnim.Equals(20) && !arg.Player.viewAnim.Equals(96))
		{
			return !arg.Player.viewAnim.Equals(28);
		}
		return false;
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RifleScope3LeftAction : RifleScopeLeftAction
{
	public RifleScope3LeftAction(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.attack.ShotsFired > 5 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}
}

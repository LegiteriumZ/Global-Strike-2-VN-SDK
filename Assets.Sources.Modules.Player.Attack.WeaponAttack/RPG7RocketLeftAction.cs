using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RPG7RocketLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public RPG7RocketLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddFire(FireUtility.FireDescClip);
		AddFire(FireSetAnim);
		AddFire(OnFire);
		AddFire(FireUtility.PlayFireSound);
		AddFire(FireUtility.RightFireQkhhAfterFire);
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime))
		{
			return arg.CurrentWeapon.special.EffectLevel == 0;
		}
		return false;
	}

	public static int FireSetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 15);
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 15);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration - 100;
		return 0;
	}
}

using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.Action;

internal class DoublePistolLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public DoublePistolLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(SetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int SetAnim(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			FireUtility.LeftFireQkhhAfterFire(ref arg);
		}
		else
		{
			FireUtility.RightFireQkhhAfterFire(ref arg);
		}
		PlayerAnimationUtility.SetViewAnimation(arg.Player, arg.CurrentWeapon.special.SpecialMode ? 15 : 29);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (base.CanFire(ref arg))
		{
			return arg.CurrentWeapon.attack.ShotsFired < 1;
		}
		return false;
	}
}

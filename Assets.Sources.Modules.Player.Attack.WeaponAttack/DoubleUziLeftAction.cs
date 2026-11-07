using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DoubleUziLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public DoubleUziLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(DoubleUziLeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(DoubleUziFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int DoubleUziFireQkhhAfterFire(ref CommonWeaponArg arg)
	{
		if (arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
		{
			WeaponUtility.AllFire(arg.Player.firstPersonUnityObjects.LeftFires, arg.CurrentWeapon.special.SpecialMode);
			WeaponUtility.AllFire(arg.Player.firstPersonUnityObjects.RightFires, arg.CurrentWeapon.special.SpecialMode);
		}
		return 0;
	}

	private int DoubleUziLeftFireSetAnim(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
		if (arg.CurrentWeapon.attack.ShotsFired > 3)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
		}
		else if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}
}

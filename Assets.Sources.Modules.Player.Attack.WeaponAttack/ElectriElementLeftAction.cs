using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ElectriElementLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	private bool _doubleFire;

	public ElectriElementLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		int num = base.OnFire(ref arg);
		if (num == 0 && !arg.Cmd.PredicatedOnce)
		{
			if ((arg.CurrentWeapon.special.EffectLevel & 1) > 0)
			{
				FireUtility.PlayFire3Sound(ref arg);
			}
			else
			{
				FireUtility.PlayFireSound(ref arg);
			}
			bool flag = false;
			if (arg.Player.viewAnim.Equals(29) || arg.Player.viewAnim.Equals(17))
			{
				flag = true;
			}
			else if (arg.Player.viewAnim.Equals(32))
			{
				_doubleFire = !_doubleFire;
				flag = _doubleFire;
			}
			if (flag)
			{
				FireUtility.LeftFireQkhhAfterFire(ref arg);
				return num;
			}
			FireUtility.RightFireQkhhAfterFire(ref arg);
		}
		return num;
	}

	public static int LeftFireSetAnim(ref CommonWeaponArg arg)
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

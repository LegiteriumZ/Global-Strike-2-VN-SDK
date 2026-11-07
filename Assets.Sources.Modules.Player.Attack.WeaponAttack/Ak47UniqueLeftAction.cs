using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Ak47UniqueLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	private readonly int INTERVAL_FLAG = 16;

	public Ak47UniqueLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(setFireAnim);
		AddFire(SetNextFireTimer);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(RightFireQkhhAfterFire);
		AddFire(PlayFireSound);
	}

	public static int RightFireQkhhAfterFire(ref CommonWeaponArg arg)
	{
		if (arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				WeaponUtility.Fire(arg.Player.firstPersonUnityObjects.LeftFires, arg.CurrentWeapon.special.SpecialMode, arg.FireParentTranName);
			}
			else
			{
				WeaponUtility.Fire(arg.Player.firstPersonUnityObjects.RightFires, arg.CurrentWeapon.special.SpecialMode, arg.FireParentTranName);
			}
		}
		return 0;
	}

	private int PlayFireSound(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			return FireUtility.PlayFire3Sound(ref arg);
		}
		return FireUtility.PlayFireSound(ref arg);
	}

	private int SetNextFireTimer(ref CommonWeaponArg arg)
	{
		if (IsAttackIntervalActive(arg.CurrentWeapon))
		{
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)((float)arg.ClientTime + (float)arg.CurrentWeapon.basicInfo.Info.AttackInterval * 0.9f);
		}
		else
		{
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval);
		}
		return 0;
	}

	private bool IsAttackIntervalActive(WeaponEntity argCurrentWeapon)
	{
		return (argCurrentWeapon.special.EffectLevel & INTERVAL_FLAG) > 0;
	}

	private int setFireAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
		}
		else if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime) && arg.Player.viewAnim.ViewAnimInfo.StateId != 36 && arg.Player.viewAnim.ViewAnimInfo.StateId != 37 && arg.Player.viewAnim.ViewAnimInfo.StateId != 17)
		{
			return arg.Player.viewAnim.ViewAnimInfo.StateId != 46;
		}
		return false;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		if (!arg.Cmd.PredicatedOnce)
		{
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
		}
		return 0;
	}
}

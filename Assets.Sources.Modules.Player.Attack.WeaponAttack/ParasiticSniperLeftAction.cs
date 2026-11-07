using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using share.constant;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ParasiticSniperLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public ParasiticSniperLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(BulletHiPlayerAction);
		AddAction(BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(LeftFireSetAnim);
		AddFire(FireNextAttack);
		AddFire(FovLeft);
		AddFire(OnFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(LeftFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	public static int LeftFireQkhhAfterFire(ref CommonWeaponArg arg)
	{
		if ((arg.Player.GetCurrentWeaponEffectLevel() & 1) == 0)
		{
			if (!StringUtil.IsNullOrEmpty(arg.Player.currentWeapon.SkinName))
			{
				return FireUtility.RightFireQkhhAfterFire(ref arg);
			}
			return FireUtility.LeftFireQkhhAfterFire(ref arg);
		}
		return 0;
	}

	public static int BulletHiPlayerAction(ref HitPlayerArgs arg)
	{
		if (!arg.currentWeapon.basicInfo.Data.SpecialMode)
		{
			HitUtility.BulletHiPlayerAction(ref arg);
		}
		return 0;
	}

	public static int BulletHitWorldAction(ref HitWorldArgs arg)
	{
		if (!arg.currentWeapon.basicInfo.Data.SpecialMode)
		{
			HitUtility.BulletHitWorldAction(ref arg);
		}
		return 0;
	}

	public static int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetViewAnimation(arg.Player, arg.CurrentWeapon.basicInfo.Data.SpecialMode ? 28 : ((arg.CurrentWeapon.basicInfo.Data.Power2 == 1) ? 15 : ((arg.CurrentWeapon.attack.ShotsFired > 3) ? 32 : 15)));
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	public static int FireNextAttack(ref CommonWeaponArg arg)
	{
		int num = (arg.CurrentWeapon.basicInfo.Data.SpecialMode ? 1000 : ((arg.CurrentWeapon.basicInfo.Data.Power2 == 1) ? 1400 : 400));
		arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + num);
		arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + num);
		return 0;
	}

	public static int FovLeft(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.Power2 == 1 && arg.Player.fov.IsZoom())
		{
			arg.Player.fov.ResumeZoom = false;
			arg.Player.fov.LastFov = arg.Player.fov.Fov;
			arg.Player.fov.DelayFov = 90;
			arg.Player.fov.Fov = 90;
		}
		return 0;
	}
}

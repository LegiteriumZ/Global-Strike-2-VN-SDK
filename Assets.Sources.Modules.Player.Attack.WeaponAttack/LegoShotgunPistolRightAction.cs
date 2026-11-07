using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class LegoShotgunPistolRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
{
	public LegoShotgunPistolRightAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.PostolFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(RightFireSetAnim);
		AddFire(FireNextAttack);
		AddFire(ShotGunFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(RightFireQkhhAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	public static int RightFireQkhhAfterFire(ref CommonWeaponArg arg)
	{
		arg.FireTranName = "qkhh_1";
		FireUtility.RightFireQkhhAfterFire(ref arg);
		return 0;
	}

	private int ShotGunFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		int seq = arg.Cmd.Seq;
		if (arg.CurrentWeapon.basicInfo.Info is IMutilFireBullets)
		{
			for (int i = 0; i < arg.CurrentWeapon.power.Power2; i++)
			{
				GunFire(ref arg, seq + i, shotDistance);
			}
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.power.RpgMaxPower == 1 && arg.ClientTime >= arg.CurrentWeapon.basicInfo.Data.NextSkillTimer)
		{
			return arg.CurrentWeapon.clip.Clip > 0;
		}
		return false;
	}

	private int RightFireSetAnim(ref CommonWeaponArg arg)
	{
		PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 40);
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}

	private int FireNextAttack(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.basicInfo.Data.NextSkillTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Data.Kill);
		return 0;
	}
}

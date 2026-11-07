using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RiderDouGunLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	private bool _doubleFire;

	public RiderDouGunLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireUtility.FireDescClip);
		AddFire(LeftFireSetAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(ShotGunFire);
		AddFire(FireUtility.RifleAfterFire);
		AddFire(FireUtility.PlayFireSound);
	}

	private int ShotGunFire(ref CommonWeaponArg arg)
	{
		if (arg.Cmd.PredicatedOnce)
		{
			return 0;
		}
		float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
		int seq = arg.Cmd.Seq;
		int num = 1 + arg.CurrentWeapon.basicInfo.Data.EffectLevel;
		for (int i = 0; i < num; i++)
		{
			GunFire(ref arg, seq + i, shotDistance);
		}
		if (!arg.Cmd.PredicatedOnce)
		{
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
			if (arg.Player.GetCurrentWeaponEffectLevel() == 1)
			{
				flag = false;
			}
			if (flag)
			{
				arg.FireParentTranName = "weapon_dummy_particle_fire_effect";
				FireUtility.LeftFireQkhhAfterFire(ref arg);
			}
			else
			{
				if (arg.Player.GetCurrentWeaponEffectLevel() != 1)
				{
					arg.FireParentTranName = "weapon_particle_fire_effect";
				}
				else
				{
					arg.FireParentTranName = "weapon_dummy_particle_fire_effect";
				}
				FireUtility.RightFireQkhhAfterFire(ref arg);
			}
			arg.FireParentTranName = null;
		}
		return 0;
	}

	protected override int OnFire(ref CommonWeaponArg arg)
	{
		int num = base.OnFire(ref arg);
		if (num == 0 && !arg.Cmd.PredicatedOnce)
		{
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
			if (arg.Player.GetCurrentWeaponEffectLevel() == 1)
			{
				flag = false;
			}
			if (flag)
			{
				arg.FireParentTranName = "weapon_dummy_particle_fire_effect";
				FireUtility.LeftFireQkhhAfterFire(ref arg);
			}
			else
			{
				if (arg.Player.GetCurrentWeaponEffectLevel() != 1)
				{
					arg.FireParentTranName = "weapon_particle_fire_effect";
				}
				else
				{
					arg.FireParentTranName = "weapon_dummy_particle_fire_effect";
				}
				FireUtility.RightFireQkhhAfterFire(ref arg);
			}
			arg.FireParentTranName = null;
		}
		return num;
	}

	public static int LeftFireSetAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.basicInfo.Data.EffectLevel == 1)
		{
			if (arg.CurrentWeapon.attack.ShotsFired > 3)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 41);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
			}
		}
		else
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
		}
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		return 0;
	}
}

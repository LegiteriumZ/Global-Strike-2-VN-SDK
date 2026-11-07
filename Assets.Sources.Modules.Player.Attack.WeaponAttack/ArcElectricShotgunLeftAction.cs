using Assets.Generated.Table;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using SSJJBase.Singleton;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ArcElectricShotgunLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
{
	public ArcElectricShotgunLeftAction(Contexts contexts)
		: base(contexts)
	{
		AddAction(HitUtility.BulletHiPlayerAction);
		AddAction(HitUtility.BulletHitWorldAction);
		AddFire(FireUtility.FireSetSpread);
		AddFire(FireUtility.RifleFireIncShotsFired);
		AddFire(FireUtility.FireSetAccuracy);
		AddFire(FireDescClip);
		AddFire(SetFireAnim);
		AddFire(FireUtility.FireNextAttack);
		AddFire(ResetReload);
		AddFire(ShotGunFire);
		AddFire(RifleAfterFire);
		AddFire(FireUtility.RightFireQkhhAfterFire);
		AddFire(PlayFireSound);
	}

	private int SetFireAnim(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 48))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 149);
			}
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
		}
		return 0;
	}

	protected override bool CanFire(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			if ((float)arg.ClientTime < arg.CurrentWeapon.attack.NextAttackTimer)
			{
				return false;
			}
			if (arg.CurrentWeapon.power.Power == 0)
			{
				return false;
			}
			return true;
		}
		return base.CanFire(ref arg);
	}

	private int FireDescClip(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			arg.CurrentWeapon.power.Power -= arg.CurrentWeapon.basicInfo.Info.ClipPerShot;
		}
		else
		{
			arg.CurrentWeapon.clip.Clip -= arg.CurrentWeapon.basicInfo.Info.ClipPerShot;
		}
		return 0;
	}

	private int PlayFireSound(ref CommonWeaponArg arg)
	{
		if (arg.CurrentWeapon.special.SpecialMode)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, arg.Player.isMyPlayer, SoundResourceUtility.GetWeaponSoundFire3AssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
		}
		else
		{
			FireUtility.PlayFireSound(ref arg);
		}
		return 0;
	}

	private int ShotGunFire(ref CommonWeaponArg arg)
	{
		if (!arg.CurrentWeapon.special.SpecialMode && !arg.Cmd.PredicatedOnce)
		{
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			int seq = arg.Cmd.Seq;
			if (arg.CurrentWeapon.basicInfo.Info is IMutilFireBullets)
			{
				int fireBullets = (arg.CurrentWeapon.basicInfo.Info as IMutilFireBullets).FireBullets;
				for (int i = 0; i < fireBullets; i++)
				{
					GunFire(ref arg, seq + i, shotDistance);
				}
			}
		}
		return 0;
	}

	private int RifleAfterFire(ref CommonWeaponArg arg)
	{
		if (!arg.CurrentWeapon.special.SpecialMode)
		{
			KickBack(ref arg);
		}
		return 0;
	}

	private void KickBack(ref CommonWeaponArg arg)
	{
		arg.Player.punchOrientation.PunchPitch += 2f;
	}

	private int ResetReload(ref CommonWeaponArg arg)
	{
		arg.CurrentWeapon.reload.ReloadEndTime = 0f;
		arg.CurrentWeapon.reload.IsStartReload = false;
		return 0;
	}
}

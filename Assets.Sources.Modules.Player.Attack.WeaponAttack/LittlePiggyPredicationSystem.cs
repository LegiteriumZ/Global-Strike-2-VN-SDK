using Assets.Generated.Table;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class LittlePiggyPredicationSystem : AbstractAttackPredicationSystem
{
	internal class LittlePiggyLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public LittlePiggyLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(FireUtility.LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(ResetReload);
			AddFire(ShotGunFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		private int ResetReload(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.reload.ReloadEndTime = 0f;
			arg.CurrentWeapon.reload.IsStartReload = false;
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
				int fireBullets = (arg.CurrentWeapon.basicInfo.Info as IMutilFireBullets).FireBullets;
				for (int i = 0; i < fireBullets; i++)
				{
					GunFire(ref arg, seq + i, shotDistance);
				}
			}
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Clip2 != 0)
			{
				return false;
			}
			return base.CanFire(ref arg);
		}
	}

	internal class LittlePiggyRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
	{
		public LittlePiggyRightAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireDescClip);
			AddFire(RightFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(OnRightFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(PlayFireSound);
		}

		private int FireDescClip(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.basicInfo.Data.Power2--;
			return 0;
		}

		public static int RightFireSetAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
			return 0;
		}

		public int FireNextAttack(ref CommonWeaponArg arg)
		{
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 20);
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + viewAnimDuration);
			return 0;
		}

		private int OnRightFire(ref CommonWeaponArg arg)
		{
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
			{
				return false;
			}
			if (arg.CurrentWeapon.basicInfo.Data.Power2 <= 0)
			{
				return false;
			}
			if (arg.CurrentWeapon.basicInfo.Data.Clip2 != 0)
			{
				return false;
			}
			return WeaponUtility.CanSecondaryAttack(ref arg);
		}

		public static int PlayFireSound(ref CommonWeaponArg arg)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Skill, arg.Player.isMyPlayer, SoundResourceUtility.GetWeaponSoundSecFireAssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
			return 0;
		}
	}

	internal class LittlePiggyFrameAction : AwmLegendSpecialFrameAction
	{
		public LittlePiggyFrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
			}
			if (IsSkill1Active(arg.CurrentWeapon))
			{
				MouseLogic(arg.Player, arg.CurrentWeapon);
			}
			return true;
		}

		protected override bool IsSkill1Active(WeaponEntity currentWeapon)
		{
			return currentWeapon.basicInfo.Data.Clip2 > 0;
		}

		protected override void MarkFailedHint()
		{
		}

		protected override AssetInfo GetMarkEffectAsset(WeaponEntity currentWeapon)
		{
			return new AssetInfo("weapon/" + currentWeapon.basicInfo.Data.WeaponName, $"Assets/Res/Assets/weapon/{currentWeapon.basicInfo.Data.WeaponName}/effect/little_piggy_biaoji/Prefab/little_piggy_biaoji.prefab");
		}
	}

	public LittlePiggyPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new LittlePiggyLeftAction(contexts));
		RightActions.Add(new LittlePiggyRightAction(contexts));
		FrameActions.Add(new LittlePiggyFrameAction(contexts));
	}
}

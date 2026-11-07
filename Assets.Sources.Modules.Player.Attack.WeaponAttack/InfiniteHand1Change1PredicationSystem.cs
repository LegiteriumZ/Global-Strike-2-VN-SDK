using System;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InfiniteHand1Change1PredicationSystem : AbstractAttackPredicationSystem
{
	internal class InfiniteHand1Change1LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public InfiniteHand1Change1LeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(ShotGunFire);
			AddFire(FireUtility.LeftFireQkhhAfterFire);
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
			for (int i = 0; i < 6; i++)
			{
				GunFire(ref arg, seq + i, shotDistance);
			}
			return 0;
		}

		public static int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 15);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}

		public int FireNextAttack(ref CommonWeaponArg arg)
		{
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 15);
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + viewAnimDuration);
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if ((double)Math.Abs(arg.CurrentWeapon.attack.NextSecondaryAttackTimer) < 0.0001)
			{
				return base.CanFire(ref arg);
			}
			return false;
		}
	}

	internal class InfiniteHand1Change1FrameAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
	{
		public InfiniteHand1Change1FrameAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.KnifeHitPlayerAction);
			AddAction(HitUtility.KnifeHitWorldAction);
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			arg.Player.SetWeaponLock(arg.CurrentWeapon.basicInfo.Data.Kill == 1);
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 1)
			{
				return true;
			}
			if (arg.Cmd.IsSecondaryAttackOn)
			{
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer += arg.Cmd.FrameInterval;
			}
			else
			{
				CheckRightAttack(ref arg);
				CheckRightAttack2(ref arg);
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer = 0f;
				if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64))
				{
					arg.CurrentWeapon.basicInfo.Data.Kill = 1;
					arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 400;
				}
			}
			if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > 500f && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 63);
			}
			return true;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			return false;
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			return 0;
		}

		protected void CheckRightAttack(ref CommonWeaponArg arg)
		{
			if (!((double)Math.Abs(arg.CurrentWeapon.attack.NextSecondaryAttackTimer) < 0.0001) && !(arg.CurrentWeapon.attack.NextSecondaryAttackTimer > 500f) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 31) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 30) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 29) && arg.CurrentWeapon.basicInfo.Info is RifleMeleeWeaponInfo rifleMeleeWeaponInfo)
			{
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + rifleMeleeWeaponInfo.StabSlashTime;
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				DelayKnifeFire(ref arg, rifleMeleeWeaponInfo);
			}
		}

		private void DelayKnifeFire(ref CommonWeaponArg arg, RifleMeleeWeaponInfo info)
		{
			float shotDistance = info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			if (!arg.Cmd.PredicatedOnce)
			{
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFire3Sound);
			}
		}

		protected void CheckRightAttack2(ref CommonWeaponArg arg)
		{
			if ((70 == arg.Player.viewAnim.ViewAnimInfo.StateId || 30 == arg.Player.viewAnim.ViewAnimInfo.StateId) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
				PlayerAnimationUtility.SetLeftViewAnimation(arg.Player, 29);
				if (arg.CurrentWeapon.basicInfo.Info is RifleMeleeWeaponInfo info)
				{
					DelayKnifeFire(ref arg, info);
				}
			}
		}
	}

	public InfiniteHand1Change1PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new InfiniteHand1Change1LeftAction(contexts));
		FrameActions.Add(new InfiniteHand1Change1FrameAction(contexts));
	}
}

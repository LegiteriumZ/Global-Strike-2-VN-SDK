using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class Qbz97PredicationSystem : AbstractAttackPredicationSystem
{
	internal class Qbz97RightAction : AbstractFireAction, IRightCmdAction, ICmdAction
	{
		public Qbz97RightAction(Contexts contexts)
			: base(contexts)
		{
			AddFire(FireNextSecAttack);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			return WeaponUtility.CanSecondaryAttack(ref arg);
		}

		private static int FireNextSecAttack(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.Player.GetClientTime() + 800;
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
			arg.CurrentWeapon.attack.NextAttackTimer = arg.Player.GetClientTime() + 800;
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			}
			return 0;
		}
	}

	internal class Qbz97FrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		public Qbz97FrameAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(BusrtRemainingFire);
			AddFire(FireSetLastFireTime);
			AddFire(FireUtility.PlayFireSound);
		}

		public int FireSetLastFireTime(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.attack.NextAttackTimer = arg.Player.GetClientTime() + 95 + 380;
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.burstMode.BurstModeShotsFired > 0)
			{
				return (float)arg.ClientTime - arg.CurrentWeapon.attack.NextAttackTimer + 380f + 95f > 60f;
			}
			return false;
		}

		private int BusrtRemainingFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			WeaponUtility.DescClip(arg.CurrentWeapon);
			if (arg.CurrentWeapon.clip.Clip < 0)
			{
				arg.CurrentWeapon.clip.Clip = 0;
				arg.CurrentWeapon.burstMode.BurstModeShotsFired = 0;
				return 0;
			}
			GunFire(ref arg, arg.Cmd.Seq + arg.CurrentWeapon.burstMode.BurstModeShotsFired, shotDistance);
			arg.CurrentWeapon.burstMode.BurstModeShotsFired--;
			arg.Player.punchOrientation.PunchPitch += 0.6f;
			return 0;
		}
	}

	internal class Qbz97LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public Qbz97LeftAction(Contexts contexts)
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
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.burstMode.BurstModeShotsFired > 0)
			{
				return false;
			}
			return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
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

		protected int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			return 0;
		}

		protected int FireNextAttack(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval + 380);
				arg.CurrentWeapon.burstMode.BurstModeShotsFired = 2;
				FireUtility.PlaySecFireSound(ref arg);
				arg.CurrentWeapon.attack.ShotsFired = 1;
			}
			else
			{
				FireUtility.FireNextAttack(ref arg);
			}
			return 0;
		}
	}

	public Qbz97PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new Qbz97LeftAction(contexts));
		RightActions.Add(new Qbz97RightAction(contexts));
		FrameActions.Add(new Qbz97FrameAction(contexts));
	}
}

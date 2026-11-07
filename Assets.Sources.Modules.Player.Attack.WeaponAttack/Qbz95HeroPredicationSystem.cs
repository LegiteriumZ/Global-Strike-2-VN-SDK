using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Qbz95HeroPredicationSystem : AbstractAttackPredicationSystem
{
	public class Qbz95HeroLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public Qbz95HeroLeftAction(Contexts contexts)
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
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (((Qbz95HeroAttach)arg.CurrentWeapon.attach.Data).CanKnifeAttack)
			{
				return false;
			}
			if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime))
			{
				return !arg.CurrentWeapon.special.SpecialMode;
			}
			return false;
		}
	}

	internal class RifleSawRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
	{
		public RifleSawRightAction(Contexts contexts)
			: base(contexts)
		{
			AddFire(FireNextSecAttack);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				return false;
			}
			if (((Qbz95HeroAttach)arg.CurrentWeapon.attach.Data).CanKnifeAttack)
			{
				return false;
			}
			return WeaponUtility.CanSecondaryAttack(ref arg);
		}

		private static void KnifeAttackStartAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 64);
		}

		private static int FireNextSecAttack(ref CommonWeaponArg arg)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65))
			{
				return 0;
			}
			if (arg.CurrentWeapon.power.Power < arg.CurrentWeapon.power.MaxPower)
			{
				KnifeAttackStartAnim(ref arg);
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 430);
				((Qbz95HeroAttach)arg.CurrentWeapon.attach.Data).CanKnifeAttack = true;
			}
			return 0;
		}
	}

	internal class RifleSawFrameAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
	{
		private int _lastAttackTime;

		public RifleSawFrameAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.KnifeHitPlayerAction);
			AddAction(HitUtility.KnifeHitWorldAction);
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (!CanFire(ref arg))
			{
				return false;
			}
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65))
			{
				((Qbz95HeroAttach)arg.CurrentWeapon.attach.Data).CanKnifeAttack = false;
				return false;
			}
			if (!arg.Cmd.IsSecondaryAttackOn)
			{
				ExitKnifeAttack(ref arg);
				return false;
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64))
			{
				return false;
			}
			if (arg.CurrentWeapon.power.Power2 > arg.CurrentWeapon.power.MaxPower2)
			{
				ExitKnifeAttack(ref arg);
				return false;
			}
			if (arg.ClientTime - _lastAttackTime < 100)
			{
				return false;
			}
			IEntitsWeaponInfo info = arg.CurrentWeapon.basicInfo.Info;
			_lastAttackTime = arg.ClientTime;
			float shotDistance = info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlaySecFireSound, isDelayAttackImmdiately: true);
			return true;
		}

		private void ExitKnifeAttack(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 65);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + 430;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + 430;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!(arg.CurrentWeapon.attach.Data is Qbz95HeroAttach))
			{
				return false;
			}
			Qbz95HeroAttach qbz95HeroAttach = (Qbz95HeroAttach)arg.CurrentWeapon.attach.Data;
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65) && qbz95HeroAttach != null)
			{
				return qbz95HeroAttach.CanKnifeAttack;
			}
			return false;
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			return 0;
		}
	}

	public Qbz95HeroPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new Qbz95HeroLeftAction(contexts));
		RightActions.Add(new RifleSawRightAction(contexts));
		FrameActions.Add(new RifleSawFrameAction(contexts));
	}
}

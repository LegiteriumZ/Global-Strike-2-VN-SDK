using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using data;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ElectricRiflePredicationSystem : AbstractAttackPredicationSystem
{
	internal class ElectricRifleRightAction : IRightCmdAction, ICmdAction
	{
		public ElectricRifleRightAction(Contexts contexts)
		{
		}

		private static bool CanFire(WeaponEntity currentWeapon, int clientTime)
		{
			if (!currentWeapon.special.SpecialMode)
			{
				return (float)clientTime < currentWeapon.attack.NextSecondaryAttackTimer;
			}
			return false;
		}

		private static void SecondaryFire(WeaponEntity currentWeapon, int clientTime)
		{
			if (!currentWeapon.special.SpecialMode && currentWeapon.burstMode.BurstModeShotsFired <= 0)
			{
				currentWeapon.attack.NextSecondaryAttackTimer = clientTime;
				currentWeapon.special.SpecialMode = true;
			}
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (CanFire(arg.CurrentWeapon, arg.ClientTime))
			{
				SecondaryFire(arg.CurrentWeapon, arg.ClientTime);
			}
			return true;
		}
	}

	internal class ElectricRifleFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		public ElectricRifleFrameAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(DecreaseShotsFired);
			AddFire(SetDoubleAttackAnim);
			AddFire(NextSecondaryAttack);
			AddFire(OnFire);
			AddFire(SetWeaponSpecialMode);
			AddFire(SetKickBack);
			AddFire(FireUtility.LeftFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		private static int NextSecondaryAttack(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval;
			return 0;
		}

		private static int SetDoubleAttackAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}

		public static int SetKickBack(ref CommonWeaponArg arg)
		{
			bool isWeightlessness = (Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().GetSceneMoveData() as SceneMoveData).isWeightlessness;
			KickBack(arg.Cmd.Seq + arg.CurrentWeapon.burstMode.BurstModeShotsFired, arg.Player, arg.CurrentWeapon, isWeightlessness);
			return 0;
		}

		private static void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
		{
			if (currentWeapon.basicInfo.Info is IGunWeaponInfo { KickbackLogic: not null } gunWeaponInfo)
			{
				gunWeaponInfo.KickbackLogic.KickBack(seed, player, currentWeapon, isWeightlessness);
			}
		}

		private static int SetWeaponSpecialMode(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.burstMode.BurstModeShotsFired == 0)
			{
				arg.CurrentWeapon.special.SpecialMode = false;
			}
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			bool forceFire = false;
			int num = (int)((float)arg.ClientTime - arg.CurrentWeapon.attack.NextSecondaryAttackTimer);
			if (num < 0)
			{
				return false;
			}
			SetWeaponLevel(out forceFire, num, arg.CurrentWeapon);
			if ((!arg.Cmd.IsSecondaryAttackOn || forceFire) && arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.burstMode.BurstModeShotsFired == 0)
			{
				arg.CurrentWeapon.burstMode.BurstModeShotsFired = (int)GetChargeInfo(num);
				FireUtility.FireDescClip(ref arg);
				arg.CurrentWeapon.attack.ShotsFired = 0;
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval;
				if (arg.CurrentWeapon.burstMode.BurstModeShotsFired == 1)
				{
					arg.CurrentWeapon.attack.DecreaseShotsFired = arg.ClientTime + 150;
					arg.CurrentWeapon.burstMode.BurstModeShotsFired = 0;
					arg.CurrentWeapon.special.SpecialMode = false;
				}
			}
			if (arg.CurrentWeapon.burstMode.BurstModeShotsFired > 0 && (float)arg.ClientTime > arg.CurrentWeapon.attack.NextSecondaryAttackTimer)
			{
				return true;
			}
			return false;
		}

		public static int DecreaseShotsFired(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.burstMode.BurstModeShotsFired--;
			return 0;
		}

		private static void SetWeaponLevel(out bool forceFire, int chargeTime, WeaponEntity currentWeapon)
		{
			forceFire = false;
			if (currentWeapon.special.SpecialMode && currentWeapon.burstMode.BurstModeShotsFired == 0)
			{
				if (chargeTime >= 10000)
				{
					forceFire = true;
				}
				if (GetChargeInfo(chargeTime) > 1 && GetChargeInfo(chargeTime) < 5)
				{
					currentWeapon.basicInfo.Data.Level = 1;
				}
				else if (GetChargeInfo(chargeTime) >= 5)
				{
					currentWeapon.basicInfo.Data.Level = 2;
				}
				else
				{
					currentWeapon.basicInfo.Data.Level = 0;
				}
			}
			else
			{
				currentWeapon.basicInfo.Data.Level = 0;
			}
		}

		private static uint GetChargeInfo(int chargeTime)
		{
			if (chargeTime < 400)
			{
				return 1u;
			}
			if (chargeTime < 1200)
			{
				return 3u;
			}
			if (chargeTime < 2000)
			{
				return 4u;
			}
			return 5u;
		}
	}

	internal class ElectricRifleLeftAction : RifleLeftAction
	{
		public ElectricRifleLeftAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!arg.CurrentWeapon.special.SpecialMode)
			{
				return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
			}
			return false;
		}
	}

	public ElectricRiflePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new ElectricRifleLeftAction(contexts));
		FrameActions.Add(new ElectricRifleFrameAction(contexts));
		RightActions.Add(new ElectricRifleRightAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
	}
}

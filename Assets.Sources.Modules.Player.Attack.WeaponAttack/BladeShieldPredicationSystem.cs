using System;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BladeShieldPredicationSystem : AbstractAttackPredicationSystem
{
	internal class BladeShieldLeftAction : KnifeLeftAction
	{
		public BladeShieldLeftAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.attack.NextAttackTimer > (float)arg.ClientTime || arg.CurrentWeapon.attack.NextSecondaryAttackTimer > 200f)
			{
				return false;
			}
			return true;
		}
	}

	internal class BladeShieldFrameAction : AbstractKnifeFireAction, IFrameCmdAction, ICmdAction
	{
		public BladeShieldFrameAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.KnifeHitPlayerAction);
			AddAction(HitUtility.KnifeHitWorldAction);
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsSecondaryAttackOn)
			{
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer += arg.Cmd.FrameInterval;
			}
			else
			{
				CheckSecondaryAttack(ref arg);
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer = 0f;
				if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 65);
					float shotDistance = (arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
					KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
				}
			}
			if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > 200f && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 63);
			}
			if (arg.Cmd.IsShowGun && CanChangeAnim(arg.Player))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
			}
			return true;
		}

		private bool CanChangeAnim(PlayerEntity playerEntity)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(playerEntity, 64) && !PlayerAnimationUtility.IsViewAnimEqual(playerEntity, 63) && !PlayerAnimationUtility.IsViewAnimEqual(playerEntity, 65) && !PlayerAnimationUtility.IsViewAnimEqual(playerEntity, 44))
			{
				return true;
			}
			return false;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			return false;
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			return 0;
		}

		protected override int GetDelayTime(ref CommonWeaponArg arg)
		{
			if (arg.Player.viewAnim.Equals(31) || arg.Player.viewAnim.Equals(65) || arg.Player.viewAnim.Equals(69) || arg.Player.viewAnim.Equals(15) || arg.Player.viewAnim.Equals(40))
			{
				return GetDelayAttackSlashTime(ref arg);
			}
			if (arg.Player.viewAnim.Equals(20) || arg.Player.viewAnim.Equals(72) || arg.Player.viewAnim.Equals(124) || arg.Player.viewAnim.Equals(122) || arg.Player.viewAnim.Equals(126))
			{
				return GetDelayAttackStabTime(ref arg);
			}
			if (arg.Player.viewAnim.Equals(29) || arg.Player.viewAnim.Equals(71))
			{
				int delayAttackSlashTime = GetDelayAttackSlashTime2(ref arg);
				if (delayAttackSlashTime > 0)
				{
					return delayAttackSlashTime;
				}
				return GetDelayAttackSlashTime(ref arg);
			}
			return 0;
		}

		protected void CheckSecondaryAttack(ref CommonWeaponArg arg)
		{
			if (!((double)Math.Abs(arg.CurrentWeapon.attack.NextSecondaryAttackTimer) < 0.0001) && !(arg.CurrentWeapon.attack.NextSecondaryAttackTimer > 200f) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 20) && arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo knifeWeaponInfo)
			{
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + knifeWeaponInfo.StabSlashTime;
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				float shotDistance = knifeWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
				if (!arg.Cmd.PredicatedOnce)
				{
					KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlaySecFireSound);
				}
			}
		}
	}

	public BladeShieldPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new BladeShieldLeftAction(contexts));
		FrameActions.Add(new BladeShieldFrameAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class M2MachineGunPredicationSystem : AbstractAttackPredicationSystem
{
	private class M2MachineGunLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public M2MachineGunLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			if (!arg.Cmd.PredicatedOnce)
			{
				if (arg.CurrentWeapon.basicInfo.Data.WeaponName.EndsWith("3") && arg.CurrentWeapon.attack.ShotsFired > 3)
				{
					for (int i = 0; i < 2; i++)
					{
						GunFire(ref arg, arg.Cmd.Seq + i, shotDistance);
					}
				}
				else
				{
					GunFire(ref arg, arg.Cmd.Seq, shotDistance);
				}
				SetFirePredictableEvent(ref arg);
			}
			return 0;
		}

		private void SetFirePredictableEvent(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.WeaponName.EndsWith("3"))
			{
				if (arg.CurrentWeapon.attack.ShotsFired > 3)
				{
					FireUtility.LeftFireQkhhAfterFire(ref arg);
					FireUtility.RightFireQkhhAfterFire(ref arg);
				}
				else if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
				{
					FireUtility.RightFireQkhhAfterFire(ref arg);
				}
				else
				{
					FireUtility.LeftFireQkhhAfterFire(ref arg);
				}
			}
			else
			{
				FireUtility.RightFireQkhhAfterFire(ref arg);
			}
			FireUtility.PlayFireSound(ref arg);
		}

		private int FireDescClip(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.WeaponName.EndsWith("3") && arg.CurrentWeapon.attack.ShotsFired > 3)
			{
				WeaponUtility.DescClip(arg.CurrentWeapon, 2);
			}
			else
			{
				WeaponUtility.DescClip(arg.CurrentWeapon, 1);
			}
			return 0;
		}

		private int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.WeaponName.EndsWith("3"))
			{
				if (arg.CurrentWeapon.attack.ShotsFired > 3)
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
				}
				else if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
				}
				else
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
				}
				arg.CurrentWeapon.basicInfo.Data.Kill = ((arg.CurrentWeapon.basicInfo.Data.Kill == 0) ? 1 : 0);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			else
			{
				if (arg.CurrentWeapon.attack.ShotsFired > 3)
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
				}
				else
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
				}
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			return 0;
		}
	}

	private class M2MachineGunFrameAction : AbstractFrameAction
	{
		public M2MachineGunFrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (base.Action(ref arg) && arg.Cmd.IsShowGun && !arg.Player.viewAnim.Equals(44) && arg.CurrentWeapon.basicInfo.Data.WeaponName.EndsWith("3"))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
			}
			return true;
		}
	}

	public M2MachineGunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new M2MachineGunLeftAction(contexts));
		FrameActions.Add(new M2MachineGunFrameAction(contexts));
	}
}

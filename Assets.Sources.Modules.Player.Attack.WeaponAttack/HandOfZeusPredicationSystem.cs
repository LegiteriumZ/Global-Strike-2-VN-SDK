using Assets.Sources.Constant;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HandOfZeusPredicationSystem : AbstractAttackPredicationSystem
{
	internal class HandOfZeusRightAction : RifleMeleeRightAction
	{
		public HandOfZeusRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!"hand_of_zeuss2".Equals(arg.CurrentWeapon.basicInfo.Data.WeaponName) || !RuleUtilty.IsRpg(arg.Contexts.battleRoom.roomData.Data.RaceType))
			{
				return base.CanFire(ref arg);
			}
			return false;
		}
	}

	internal class ShotGunLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public ShotGunLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(FireUtility.LeftFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(ShotGunFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		private int FireNextAttack(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.SpecialMode)
			{
				arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Data.WeaponTimer1);
			}
			else
			{
				arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval);
			}
			return 0;
		}

		private int ShotGunFire(ref CommonWeaponArg arg)
		{
			if (!arg.Cmd.PredicatedOnce)
			{
				float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
				int seq = arg.Cmd.Seq;
				if (!arg.CurrentWeapon.basicInfo.Data.SpecialMode && arg.CurrentWeapon.basicInfo.Info is IMutilFireBullets)
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
	}

	public HandOfZeusPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new ShotGunLeftAction(contexts));
		RightActions.Add(new HandOfZeusRightAction(contexts));
	}
}

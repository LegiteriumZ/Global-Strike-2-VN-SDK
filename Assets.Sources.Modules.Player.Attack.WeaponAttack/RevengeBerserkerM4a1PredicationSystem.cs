using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RevengeBerserkerM4a1PredicationSystem : AbstractAttackPredicationSystem
{
	internal class RevengeBerserkerM4a1LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public RevengeBerserkerM4a1LeftAction(Contexts contexts)
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
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
			{
				return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
			}
			return false;
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
	}

	public RevengeBerserkerM4a1PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new RevengeBerserkerM4a1LeftAction(contexts));
		RightActions.Add(new RifleMeleeRightAction(contexts));
	}
}

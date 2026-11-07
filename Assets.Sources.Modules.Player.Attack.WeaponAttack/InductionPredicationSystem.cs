using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class InductionPredicationSystem : AbstractAttackPredicationSystem
{
	internal class InductionRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
	{
		public InductionRightAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(RightFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(ShotGunFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlaySecFireSound);
		}

		private int FireSetSpread(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Info.SpreadLogic != null)
			{
				arg.CurrentWeapon.spread.Spread = 0.0675f;
			}
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
			for (int i = 0; i < 6; i++)
			{
				GunFire(ref arg, seq + i, shotDistance);
			}
			return 0;
		}

		public static int RightFireSetAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
			return 0;
		}

		public int FireNextAttack(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + 1000);
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!arg.CurrentWeapon.hasSpecial || !arg.CurrentWeapon.special.SpecialMode)
			{
				return WeaponUtility.CanSecondaryAttack(ref arg);
			}
			return false;
		}
	}

	public InductionPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RifleLeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		RightActions.Add(new InductionRightAction(contexts));
	}
}

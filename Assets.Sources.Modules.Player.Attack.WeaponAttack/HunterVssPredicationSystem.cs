using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class HunterVssPredicationSystem : AbstractAttackPredicationSystem
{
	internal class G3Sg1FrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		private readonly G3Sg1LeftAction _g3Sg1LeftAction;

		public G3Sg1FrameAction(Contexts contexts)
			: base(contexts)
		{
			_g3Sg1LeftAction = new G3Sg1LeftAction(contexts);
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power > 0)
			{
				_g3Sg1LeftAction.Action(ref arg);
			}
			return true;
		}
	}

	internal class G3Sg1LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public G3Sg1LeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		private int FireDescClip(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power < 0)
			{
				WeaponUtility.DescClip(arg.CurrentWeapon);
			}
			return 0;
		}

		public static int FireNextAttack(ref CommonWeaponArg arg)
		{
			int num = 1;
			if (arg.CurrentWeapon.power.Power > 0 || arg.CurrentWeapon.special.SpecialMode)
			{
				num = 3;
			}
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval / num);
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			return base.CanFire(ref arg);
		}

		public int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}

		public int FireSetSpread(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power > 0)
			{
				arg.CurrentWeapon.spread.Spread = 0.001f;
				return 0;
			}
			return FireUtility.FireSetSpread(ref arg);
		}
	}

	public HunterVssPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new G3Sg1LeftAction(contexts));
		IdleActions.Add(new RifleIdleAction(contexts));
		FrameActions.Add(new G3Sg1FrameAction(contexts));
	}
}

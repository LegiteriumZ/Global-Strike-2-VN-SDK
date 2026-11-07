using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

public class PhasewalkerPredicationSystem : AbstractAttackPredicationSystem
{
	internal class PhasewalkerLeftPredicationSystem : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public PhasewalkerLeftPredicationSystem(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(FireUtility.LeftFireSetAnim);
			AddFire(LeftFireSetAnim);
			AddFire(OnFire);
			AddFire(FireUtility.FireNextAttack);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		public static int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
				if (arg.CurrentWeapon.special.SpecialMode)
				{
					if (arg.CurrentWeapon.attack.ShotsFired > 3)
					{
						PlayerAnimationUtility.SetViewAnimation(arg.Player, 41);
					}
					else
					{
						PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
					}
				}
				else if (arg.CurrentWeapon.attack.ShotsFired > 3)
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 32);
				}
				else
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
				}
			}
			return 0;
		}
	}

	private class PhasewalkerFramePredicationSystem : IFrameCmdAction, ICmdAction
	{
		public virtual bool Action(ref CommonWeaponArg arg)
		{
			if ((arg.Cmd.Buttons & 0x10000) > 0)
			{
				if (arg.CurrentWeapon.special.SpecialMode)
				{
					if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 117))
					{
						PlayerAnimationUtility.SetViewAnimation(arg.Player, 117);
					}
				}
				else if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
				}
			}
			return true;
		}
	}

	public PhasewalkerPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new PhasewalkerLeftPredicationSystem(contexts));
		FrameActions.Add(new PhasewalkerFramePredicationSystem());
	}
}

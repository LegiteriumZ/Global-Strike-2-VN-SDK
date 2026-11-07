using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class PistolRiotshieldPredicationSystem : AbstractAttackPredicationSystem
{
	internal class PistolRiotshieldFrameAction : AbstractFrameAction
	{
		public PistolRiotshieldFrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		public PistolRiotshieldFrameAction(Contexts contexts, IIdleCmdAction action)
			: base(contexts, action)
		{
		}
	}

	internal class PistolRiotshieldRightAction : IRightCmdAction, ICmdAction
	{
		public PistolRiotshieldRightAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer < (float)arg.ClientTime)
			{
				if (!arg.CurrentWeapon.special.SpecialMode)
				{
					arg.CurrentWeapon.special.SpecialMode = true;
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 39);
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
					int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
					arg.CurrentWeapon.attack.NextSecondaryAttackTimer = viewAnimDuration + arg.ClientTime;
					FireUtility.PlaySecFireSound(ref arg);
				}
				else
				{
					arg.CurrentWeapon.special.SpecialMode = false;
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 13);
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
					int viewAnimDuration2 = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
					arg.CurrentWeapon.attack.NextSecondaryAttackTimer = viewAnimDuration2 + arg.ClientTime;
					arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
					FireUtility.PlaySecFireSound(ref arg);
				}
			}
			return false;
		}
	}

	internal class PistolRiotshieldLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public PistolRiotshieldLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.PostolFireIncShotsFired);
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
			if (base.CanFire(ref arg) && arg.CurrentWeapon.attack.ShotsFired < 1)
			{
				return !arg.CurrentWeapon.special.SpecialMode;
			}
			return false;
		}
	}

	public PistolRiotshieldPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new PistolRiotshieldLeftAction(contexts));
		RightActions.Add(new PistolRiotshieldRightAction(contexts));
		FrameActions.Add(new PistolRiotshieldFrameAction(contexts));
	}
}

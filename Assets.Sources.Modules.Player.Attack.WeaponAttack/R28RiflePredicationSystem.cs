using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class R28RiflePredicationSystem : AbstractAttackPredicationSystem
{
	internal class R28RifleLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public R28RifleLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(UpdateWeaponParams);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(R28DescClip);
			AddFire(FireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		public static int R28DescClip(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.clip.Clip -= ((!arg.CurrentWeapon.special.SpecialMode) ? 1 : 2);
			return 0;
		}

		public static int UpdateWeaponParams(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.basicInfo.Info.AttackInterval = (arg.CurrentWeapon.special.SpecialMode ? 60 : 95);
			return 0;
		}

		private static int FireSetAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}
	}

	internal class R28RifleFrameAction : IFrameCmdAction, ICmdAction
	{
		private bool _tempFlag;

		public R28RifleFrameAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && arg.CurrentWeapon.special.EffectLevel == 0)
			{
				if (_tempFlag)
				{
					if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17))
					{
						arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
						if (arg.CurrentWeapon.special.SpecialMode)
						{
							NormalToSpecialModel(ref arg);
						}
						if (!arg.CurrentWeapon.special.SpecialMode)
						{
							SpecialToNormalModel(ref arg);
						}
					}
					_tempFlag = false;
				}
				else
				{
					_tempFlag = true;
				}
			}
			return true;
		}

		private static void SpecialToNormalModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		}

		private static void NormalToSpecialModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
		}
	}

	public R28RiflePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new R28RifleLeftAction(contexts));
		FrameActions.Add(new R28RifleFrameAction(contexts));
	}
}

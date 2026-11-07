using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using data;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class GlockHellSnakePredicationSystem : AbstractAttackPredicationSystem
{
	internal class GlockHellSnakeFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		private bool _tempFlag;

		public GlockHellSnakeFrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			_ = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (arg.Cmd.IsShowGun && arg.CurrentWeapon.power.MaxPower == 1)
			{
				if (_tempFlag)
				{
					if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17))
					{
						arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
						if (arg.CurrentWeapon.special.SpecialMode)
						{
							NormalToSpecialModel(arg.Player, arg.CurrentWeapon, arg.ClientTime);
						}
						if (!arg.CurrentWeapon.special.SpecialMode)
						{
							SpecialToNormalModel(arg.Player, arg.CurrentWeapon, arg.ClientTime);
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

		private static void SpecialToNormalModel(PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 37);
			currentWeapon.attack.NextAttackTimer = clientTime + viewAnimDuration;
		}

		private static void NormalToSpecialModel(PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 36);
			currentWeapon.attack.NextAttackTimer = clientTime + viewAnimDuration;
		}
	}

	internal class GlockHellSnakeLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public GlockHellSnakeLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.PostolFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				return base.CanFire(ref arg);
			}
			if (base.CanFire(ref arg))
			{
				return arg.CurrentWeapon.attack.ShotsFired < 1;
			}
			return false;
		}

		public static int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				if (arg.CurrentWeapon.attack.ShotsFired > 3 && arg.CurrentWeapon.basicInfo.Info.HasDoubleAttack)
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 41);
				}
				else
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
				}
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}

		private int RifleAfterFire(ref CommonWeaponArg arg)
		{
			bool isWeightlessness = (Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().GetSceneMoveData() as SceneMoveData).isWeightlessness;
			KickBack(arg.Cmd.Seq, arg.Player, arg.CurrentWeapon, isWeightlessness);
			return 0;
		}

		private void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
		{
			player.punchOrientation.PunchPitch += (currentWeapon.special.SpecialMode ? 1 : 2);
		}
	}

	internal class GlockHellSnakeMeleeRightAction : RifleMeleeRightAction
	{
		public GlockHellSnakeMeleeRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo && WeaponUtility.CanSecondaryAttack(ref arg))
			{
				return !arg.CurrentWeapon.special.SpecialMode;
			}
			return false;
		}
	}

	public GlockHellSnakePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new GlockHellSnakeLeftAction(contexts));
		IdleActions.Add(new PistolIdleAction(contexts));
		RightActions.Add(new GlockHellSnakeMeleeRightAction(contexts));
		FrameActions.Add(new GlockHellSnakeFrameAction(contexts));
	}
}

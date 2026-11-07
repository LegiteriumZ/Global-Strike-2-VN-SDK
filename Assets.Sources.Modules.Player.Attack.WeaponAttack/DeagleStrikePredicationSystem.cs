using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.Player;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using data;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DeagleStrikePredicationSystem : AbstractAttackPredicationSystem
{
	internal class DeagleStrikeFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		private readonly DeagleStrikeMeleeRightAction _action;

		public DeagleStrikeFrameAction(Contexts contexts)
			: base(contexts)
		{
			_action = new DeagleStrikeMeleeRightAction(contexts);
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			doubleGunLogic(ref arg);
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64))
			{
				arg.Player.SetWeaponLock(b: true);
			}
			else
			{
				arg.Player.SetWeaponLock(b: false);
			}
			return true;
		}

		private void doubleGunLogic(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsAttackOn && arg.CurrentWeapon.power.RpgMaxPower == 1)
			{
				if (!arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.special.Level != 0)
				{
				}
			}
			else
			{
				arg.CurrentWeapon.special.Level = 0;
				arg.CurrentWeapon.special.Kil = 0;
				if (arg.CurrentWeapon.special.SpecialMode && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 72) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65))
				{
					specialAttack(ref arg);
				}
			}
			if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.clip.Clip < 1 && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 72) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65))
			{
				arg.CurrentWeapon.special.Level = 1;
				specialAttack(ref arg);
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
			{
				arg.CurrentWeapon.special.SpecialMode = true;
			}
			if ((PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 72) && arg.Player.viewAnim.RemainTime < 50) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39))
			{
				SpecialToNormalModel(arg.Player, arg.CurrentWeapon, arg.Player.clientTime.ClientTime);
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65))
			{
				arg.CurrentWeapon.special.SpecialMode = false;
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 72) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39))
			{
				arg.CurrentWeapon.special.Kil = 0;
			}
		}

		private void specialAttack(ref CommonWeaponArg arg)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 72) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && arg.CurrentWeapon.basicInfo.Info is DefaultWeaponInfo defaultWeaponInfo)
			{
				float shotDistance = defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
				_action.KnifeFire(ref arg, arg.Cmd.Seq, shotDistance + (float)arg.CurrentWeapon.power.MaxPower2, FireUtility.PlaySecFireSound);
			}
		}

		private bool CanChangeAnim(PlayerEntity player)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(player, 64) && !PlayerAnimationUtility.IsViewAnimEqual(player, 65) && !PlayerAnimationUtility.IsViewAnimEqual(player, 63) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(player, 72) && !PlayerAnimationUtility.IsViewAnimEqual(player, 39))
			{
				return true;
			}
			return false;
		}

		private void SpecialToNormalModel(PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 65);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 65);
			currentWeapon.attack.NextAttackTimer = clientTime + viewAnimDuration;
			currentWeapon.attack.NextSecondaryAttackTimer = clientTime + viewAnimDuration;
		}

		private void NormalToSpecialModel(PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 64);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 64);
			currentWeapon.attack.NextAttackTimer = clientTime + viewAnimDuration;
			currentWeapon.attack.NextSecondaryAttackTimer = clientTime + viewAnimDuration;
		}
	}

	internal class DeagleStrikeLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public DeagleStrikeLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireSetSpread);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.PostolFireIncShotsFired);
			AddFire(FireUtility.FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(RifleAfterFire);
			AddFire(FireUtility.LeftFireQkhhAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		public int FireSetSpread(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = 150;
			}
			else
			{
				arg.CurrentWeapon.basicInfo.Info.AttackInterval = 190;
			}
			IEntitsWeaponInfo info = arg.CurrentWeapon.basicInfo.Info;
			bool isWeightlessness = (Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().GetSceneMoveData() as SceneMoveData).isWeightlessness;
			if (info.SpreadLogic != null)
			{
				BeforeFire(ref arg.CurrentWeapon.spread.Spread, arg.Player, arg.CurrentWeapon, isWeightlessness);
			}
			return 0;
		}

		public void BeforeFire(ref float spread, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
		{
			float num = ((!player.OnGround() && !isWeightlessness) ? 1.5f : ((PlayerUtility.PlayerLength2D(player) > 13f) ? 0.09f : ((player.DuckState() != 0) ? 0.09f : 0.08f)));
			spread = num * (1f - currentWeapon.accuracy.Accuracy);
			spread *= 1f - (float)currentWeapon.power.Power2 * 1f / 1000f;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 65) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 72) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39))
			{
				return false;
			}
			if (arg.CurrentWeapon.special.Level == 1)
			{
				return false;
			}
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
			if (!arg.CurrentWeapon.special.SpecialMode)
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
			player.punchOrientation.PunchPitch += (currentWeapon.special.SpecialMode ? 1.3f : 2.3f);
		}
	}

	internal class DeagleStrikeMeleeRightAction : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
	{
		public DeagleStrikeMeleeRightAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.KnifeHitPlayerAction);
			AddAction(HitUtility.KnifeHitWorldAction);
			AddFire(SetAttackAnim);
			AddFire(OnFire);
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + base.AttackInterval);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
			if ((arg.CurrentWeapon.special.EffectLevel & 8) > 0)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 29);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, base.ViewAnimId);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
			}
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo && WeaponUtility.CanSecondaryAttack(ref arg))
			{
				return !arg.CurrentWeapon.special.SpecialMode;
			}
			return false;
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo rifleMeleeWeaponInfo)
			{
				float shotDistance = rifleMeleeWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance + (float)arg.CurrentWeapon.power.MaxPower2, null);
				FireUtility.PlaySecFireSound(ref arg);
			}
			return 0;
		}

		protected override int GetDelayTime(ref CommonWeaponArg arg)
		{
			if (arg.Player.viewAnim.Equals(69) || arg.Player.viewAnim.Equals(29) || arg.Player.viewAnim.Equals(71))
			{
				return GetDelayAttackSlashTime(ref arg);
			}
			if (arg.Player.viewAnim.Equals(20) || arg.Player.viewAnim.Equals(31) || arg.Player.viewAnim.Equals(72) || arg.Player.viewAnim.Equals(122) || arg.Player.viewAnim.Equals(170) || arg.Player.viewAnim.Equals(28) || arg.Player.viewAnim.Equals(96) || arg.Player.viewAnim.Equals(16))
			{
				return GetDelayAttackStabTime(ref arg);
			}
			return 0;
		}
	}

	public DeagleStrikePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new DeagleStrikeLeftAction(contexts));
		IdleActions.Add(new PistolIdleAction(contexts));
		RightActions.Add(new DeagleStrikeMeleeRightAction(contexts));
		FrameActions.Add(new DeagleStrikeFrameAction(contexts));
	}
}

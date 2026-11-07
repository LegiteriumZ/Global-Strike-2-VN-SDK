using Assets.Generated.Table;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using SSJJBase.Singleton;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class ThunderScepterPredicationSystem : AbstractAttackPredicationSystem
{
	internal class ThunderScepterRifleLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public ThunderScepterRifleLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(PlayFireSound);
		}

		public static int FireNextAttack(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
			{
				arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval);
			}
			return 0;
		}

		public static int PlayFireSound(ref CommonWeaponArg arg)
		{
			if (!arg.Cmd.PredicatedOnce && arg.CurrentWeapon.basicInfo.Data.Kill == 0)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Shoot, arg.Player.isMyPlayer, SoundResourceUtility.GetWeaponSoundFireAssetInfo(arg.CurrentWeapon.basicInfo.Data.WeaponName), GameSoundManager.Config.WeaponVolume);
			}
			return 0;
		}

		private static int FireDescClip(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 1)
			{
				if (arg.ClientTime >= arg.CurrentWeapon.basicInfo.Data.WeaponTimer1)
				{
					arg.CurrentWeapon.basicInfo.Data.WeaponTimer1 = (uint)(arg.ClientTime + 500);
					arg.CurrentWeapon.clip.Clip--;
				}
			}
			else
			{
				arg.CurrentWeapon.clip.Clip -= arg.CurrentWeapon.basicInfo.Info.ClipPerShot;
			}
			return 0;
		}

		public static int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 0)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			}
			else if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 63);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}
	}

	internal class ThunderScepterRifleRightAction : AbstractFireAction, IRightCmdAction, ICmdAction
	{
		public ThunderScepterRifleRightAction(Contexts contexts)
			: base(contexts)
		{
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireDescClip);
			AddFire(RightFireSetAnim);
			AddFire(FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Power > 0)
			{
				return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
			}
			return false;
		}

		private static int FireDescClip(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Data.Kill == 1)
			{
				if (arg.ClientTime >= arg.CurrentWeapon.basicInfo.Data.WeaponTimer1)
				{
					arg.CurrentWeapon.basicInfo.Data.WeaponTimer1 += 500L;
					arg.CurrentWeapon.clip.Clip--;
				}
			}
			else
			{
				arg.CurrentWeapon.clip.Clip -= arg.CurrentWeapon.basicInfo.Info.ClipPerShot;
			}
			return 0;
		}

		public static int RightFireSetAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 28);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 28);
			return 0;
		}

		public static int FireNextAttack(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 16) + PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 28));
			return 0;
		}
	}

	internal class ThunderScepterFrameAction : AbstractFrameAction
	{
		public ThunderScepterFrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			CheckAttackLoopEnd(ref arg);
			CheckSkillAnimEnd(ref arg);
			return true;
		}

		private void CheckAttackLoopEnd(ref CommonWeaponArg arg)
		{
			if (((arg.Cmd.Buttons & 0x40) <= 0 || arg.CurrentWeapon.basicInfo.Data.Clip == 0) && PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 65);
			}
		}

		private void CheckSkillAnimEnd(ref CommonWeaponArg arg)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 28) && (double)arg.Player.basicInfo.Current.ViewAnimationTimer < 66.6666666)
			{
				arg.CurrentWeapon.basicInfo.Data.EffectLevel = 0;
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 16);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 16);
			}
		}
	}

	public ThunderScepterPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new ThunderScepterRifleLeftAction(contexts));
		RightActions.Add(new ThunderScepterRifleRightAction(contexts));
		FrameActions.Add(new ThunderScepterFrameAction(contexts));
	}
}

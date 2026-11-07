using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class TwinsInfinitePredicationSystem : AbstractAttackPredicationSystem
{
	private class TwinsInfiniteLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		private Contexts contexts;

		public TwinsInfiniteLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.PostolFireIncShotsFired);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireDescClip);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(setFireAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(setFireHoles);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		private int FireDescClip(ref CommonWeaponArg arg)
		{
			if (isLeftAttack(arg.CurrentWeapon))
			{
				WeaponUtility.DescClip(arg.CurrentWeapon);
			}
			else
			{
				WeaponUtility.DescClip2(arg.CurrentWeapon);
			}
			return 0;
		}

		private int setFireHoles(ref CommonWeaponArg arg)
		{
			if (isLeftAttack(arg.CurrentWeapon) && arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
			{
				arg.FireParentTranName = "weapon_left_particle_fire_effect";
				FireUtility.LeftFireQkhhAfterFire(ref arg);
			}
			if (!isLeftAttack(arg.CurrentWeapon) && arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
			{
				arg.FireParentTranName = "weapon_particle_fire_effect";
				FireUtility.RightFireQkhhAfterFire(ref arg);
			}
			arg.FireParentTranName = null;
			base.OnFire(ref arg);
			return 0;
		}

		private int setFireAnim(ref CommonWeaponArg arg)
		{
			if ((arg.CurrentWeapon.basicInfo.Data.WeaponName == "twins_infinity1" || arg.CurrentWeapon.basicInfo.Data.WeaponName == "twins_infinity2") && (arg.CurrentWeapon.basicInfo.Data.EffectLevel & 2) > 0)
			{
				return 1;
			}
			if (isLeftAttack(arg.CurrentWeapon))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, LEFT_ATTACK_ANIM);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 15);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (canFireWeapon(arg))
			{
				return canFirePlayerButton(arg);
			}
			return false;
		}

		private bool canFireWeapon(CommonWeaponArg arg)
		{
			if ((float)arg.ClientTime < arg.CurrentWeapon.attack.NextAttackTimer)
			{
				return false;
			}
			if (isHasFire(arg.CurrentWeapon))
			{
				return false;
			}
			if (isLeftAttack(arg.CurrentWeapon))
			{
				if (arg.CurrentWeapon.clip.Clip <= 0)
				{
					return false;
				}
			}
			else if (arg.CurrentWeapon.clip.Clip2 <= 0)
			{
				return false;
			}
			return true;
		}
	}

	public class TwinsInfiniteRightAction : RifleMeleeRightAction
	{
		public TwinsInfiniteRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.power.RpgMaxPower = 0;
			setMeleeStartAttack(arg.CurrentWeapon, meleeStartAttack: true);
			return 0;
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 20) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 72))
			{
				return 1;
			}
			if (isLeftAttack(arg.CurrentWeapon))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (base.CanFire(ref arg))
			{
				return canFirePlayerButton(arg);
			}
			return false;
		}
	}

	private class TwinsInfiniteFrameAction : AbstractFrameAction
	{
		public TwinsInfiniteFrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		public TwinsInfiniteFrameAction(Contexts contexts, IIdleCmdAction action)
			: base(contexts, action)
		{
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return true;
			}
			base.Action(ref arg);
			knifeDelayAttack(ref arg);
			checkShowGun(ref arg);
			checkAutoChangeHand(ref arg);
			return true;
		}

		private void checkAutoChangeHand(ref CommonWeaponArg commonWeaponArg)
		{
			if (needAutoChangeHandForClip(ref commonWeaponArg))
			{
				changeAttackDirection(ref commonWeaponArg);
			}
		}

		private bool needAutoChangeHandForClip(ref CommonWeaponArg arg)
		{
			if ((arg.Cmd.Buttons & 0x40) == 0)
			{
				return false;
			}
			if (isLeftAttack(arg.CurrentWeapon) && arg.CurrentWeapon.clip.Clip <= 0 && arg.CurrentWeapon.clip.Clip2 + arg.CurrentWeapon.clip.CarryClip2 > 0)
			{
				return true;
			}
			if (!isLeftAttack(arg.CurrentWeapon) && arg.CurrentWeapon.clip.Clip2 <= 0 && arg.CurrentWeapon.clip.Clip + arg.CurrentWeapon.clip.CarryClip > 0)
			{
				return true;
			}
			return false;
		}

		private void checkDelayChangeHand(ref CommonWeaponArg arg)
		{
			checkChangeHandDelayBreak(ref arg);
			if (isDelayChange(ref arg))
			{
				changeAttackDirection(ref arg);
			}
		}

		private void changeAttackDirection(ref CommonWeaponArg arg)
		{
			if (isLeftAttack(arg.CurrentWeapon))
			{
				setLeftAttack(arg.CurrentWeapon, value: false);
				WeaponUtility.ReloadClipRight(arg.CurrentWeapon);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			}
			else
			{
				setLeftAttack(arg.CurrentWeapon, value: true);
				WeaponUtility.ReloadClipLeft(arg.CurrentWeapon);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			}
		}

		private bool isDelayChange(ref CommonWeaponArg arg)
		{
			if (!isHasFire(arg.CurrentWeapon))
			{
				return false;
			}
			int num = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - 50;
			if (arg.Player.viewAnim.RightCurrentTime >= num)
			{
				setHasFire(arg.CurrentWeapon, value: false);
				return true;
			}
			return false;
		}

		private void checkChangeHandDelayBreak(ref CommonWeaponArg arg)
		{
			if (isHasFire(arg.CurrentWeapon) && !arg.Player.viewAnim.Equals(15) && !arg.Player.viewAnim.Equals(LEFT_ATTACK_ANIM))
			{
				setHasFire(arg.CurrentWeapon, value: false);
			}
		}

		private void checkShowGun(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && !arg.Player.viewAnim.Equals(44) && !arg.Player.viewAnim.Equals(117))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, ((arg.Player.basicInfo.Current.CurrentWeaponEffectLevel & LEFT_ATTACK) <= 0) ? 44 : 117);
			}
		}

		private void knifeDelayAttack(ref CommonWeaponArg arg)
		{
			checkMeleeStartAttack(ref arg);
			if (delayAttck(ref arg))
			{
				if (arg.CurrentWeapon.power.RpgMaxPower == 1)
				{
					rightAction.AttackImmed(ref arg, arg.Cmd.Seq, 140f, FireUtility.PlaySecFireSound);
				}
				else
				{
					rightAction.AttackImmed(ref arg, arg.Cmd.Seq, 140f, null);
				}
			}
		}

		private bool delayAttck(ref CommonWeaponArg arg)
		{
			if (!isMeleeStartAttack(arg.CurrentWeapon) || arg.CurrentWeapon.power.RpgMaxPower == 5)
			{
				return false;
			}
			int num = 0;
			switch (arg.Player.viewAnim.ViewAnimInfo.StateId)
			{
			case 20:
			case 72:
				num = CONTINUES_ATTACK_INTERVAL[arg.CurrentWeapon.power.RpgMaxPower];
				break;
			case 16:
			case 47:
				num = RAISE_ATTACK_DELAY;
				break;
			default:
				return false;
			}
			if (arg.Player.viewAnim.RightCurrentTime >= num)
			{
				if (arg.Player.viewAnim.Equals(20) || (arg.Player.viewAnim.Equals(72) && arg.CurrentWeapon.power.RpgMaxPower < 5))
				{
					arg.CurrentWeapon.power.RpgMaxPower++;
					setMeleeStartAttack(arg.CurrentWeapon, meleeStartAttack: true);
					return true;
				}
				setMeleeStartAttack(arg.CurrentWeapon, meleeStartAttack: false);
				arg.CurrentWeapon.power.RpgMaxPower = 0;
				return true;
			}
			return false;
		}

		protected virtual void checkMeleeStartAttack(ref CommonWeaponArg arg)
		{
			if (isMeleeStartAttack(arg.CurrentWeapon) && !arg.Player.viewAnim.Equals(20) && !arg.Player.viewAnim.Equals(72) && !arg.Player.viewAnim.Equals(16) && !arg.Player.viewAnim.Equals(47))
			{
				setMeleeStartAttack(arg.CurrentWeapon, meleeStartAttack: false);
			}
		}
	}

	public static readonly int SKILL_ON = 2;

	public static readonly int LEFT_ATTACK = 4;

	public static readonly int MELEE_START_ATTACK = 8;

	public static readonly int HAS_FIRE = 16;

	public static readonly int SKILL_STAND = 32;

	public static readonly int SLASH_SLASH_TIME = 1000;

	public static readonly int SLASH_STAB_TIME = 1000;

	public static readonly int STAB_SLASH_TIME = 1700;

	public static readonly int STAB_STAB_TIME = 1700;

	public static readonly int DELAY_ATTACK_SLASH_TIME = 300;

	public static readonly int DELAY_ATTACK_STAB_TIME = 650;

	public static readonly int RAISE_ATTACK_DELAY = 400;

	public static readonly int LEFT_RELOAD_ANIM = 46;

	public static readonly int RIGHT_RELOAD_ANIM = 17;

	public static readonly int LEFT_ATTACK_ANIM = 40;

	public static readonly int[] CONTINUES_ATTACK_INTERVAL = new int[5] { 100, 400, 700, 1100, 1400 };

	public static TwinsInfiniteRightAction rightAction;

	public TwinsInfinitePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		rightAction = new TwinsInfiniteRightAction(contexts);
		LeftActions.Add(new TwinsInfiniteLeftAction(contexts));
		RightActions.Add(rightAction);
		FrameActions.Add(new TwinsInfiniteFrameAction(contexts));
	}

	public static bool isLeftAttack(WeaponEntity weapon)
	{
		return (weapon.special.EffectLevel & LEFT_ATTACK) > 0;
	}

	public static bool isHasFire(WeaponEntity weapon)
	{
		return (weapon.special.EffectLevel & HAS_FIRE) > 0;
	}

	public static void setHasFire(WeaponEntity weapon, bool value)
	{
		if (value)
		{
			weapon.special.EffectLevel |= HAS_FIRE;
		}
		else
		{
			weapon.special.EffectLevel &= ~HAS_FIRE;
		}
	}

	public static bool isMeleeStartAttack(WeaponEntity weapon)
	{
		return (weapon.special.EffectLevel & MELEE_START_ATTACK) > 0;
	}

	public static void setMeleeStartAttack(WeaponEntity weapon, bool meleeStartAttack)
	{
		if (meleeStartAttack)
		{
			weapon.special.EffectLevel |= MELEE_START_ATTACK;
		}
		else
		{
			weapon.special.EffectLevel &= ~MELEE_START_ATTACK;
		}
	}

	private static void setLeftAttack(WeaponEntity weapon, bool value)
	{
		if (value)
		{
			weapon.special.EffectLevel |= LEFT_ATTACK;
		}
		else
		{
			weapon.special.EffectLevel &= ~LEFT_ATTACK;
		}
	}

	public static bool isSkillOn(WeaponEntity currentWeapon)
	{
		return (currentWeapon.special.EffectLevel & SKILL_ON) > 0;
	}

	public static bool isSkillStand(WeaponEntity currentWeapon)
	{
		return (currentWeapon.special.EffectLevel & SKILL_STAND) > 0;
	}

	public static bool canFirePlayerButton(CommonWeaponArg arg)
	{
		if (!arg.Player.viewAnim.Equals(LEFT_RELOAD_ANIM) && !arg.Player.viewAnim.Equals(RIGHT_RELOAD_ANIM) && !arg.Player.viewAnim.Equals(36) && !arg.Player.viewAnim.Equals(37) && !arg.Player.viewAnim.Equals(28) && !arg.Player.viewAnim.Equals(96))
		{
			return !isSkillOn(arg.CurrentWeapon);
		}
		return false;
	}
}

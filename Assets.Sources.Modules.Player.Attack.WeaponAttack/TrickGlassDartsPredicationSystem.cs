using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class TrickGlassDartsPredicationSystem : AbstractAttackPredicationSystem
{
	internal class TrickGlassDartsLeftAction : RifleLeftAction
	{
		public TrickGlassDartsLeftAction(Contexts contexts)
			: base(contexts)
		{
			Reset();
			AddFire(setFireAnim);
		}
	}

	internal class TrickGlassDartsFrameAction : IFrameCmdAction, ICmdAction
	{
		public bool Action(ref CommonWeaponArg arg)
		{
			checkBreakThrow(ref arg);
			if (timeToThrow(ref arg))
			{
				FireUtility.FireDescClip(ref arg);
				setStartThrow(arg.CurrentWeapon, b: false);
				setHideWeapon(arg.CurrentWeapon, hideWeapon: true);
			}
			checkBreakContinuesHit(arg);
			checkShowWeapon(arg);
			if (arg.Player != null && arg.Player.hasFirstPersonUnityObjects)
			{
				arg.Player.firstPersonUnityObjects.WeaponGameObject.SetObjectActive(!isHideWeapon(arg.CurrentWeapon));
			}
			FireUtility.CheckShowGun(arg);
			return true;
		}

		private void checkShowWeapon(CommonWeaponArg arg)
		{
			bool hideWeapon = false;
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 31 && (double)arg.Player.viewAnim.RemainTime <= 166.5)
			{
				hideWeapon = true;
			}
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 30 && (double)arg.Player.viewAnim.RemainTime >= 133.2)
			{
				hideWeapon = true;
			}
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 170)
			{
				if ((double)arg.Player.viewAnim.RemainTime <= 199.79999999999998)
				{
					hideWeapon = true;
				}
				if ((double)arg.Player.viewAnim.RemainTime >= 299.7)
				{
					hideWeapon = true;
				}
			}
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 169 && (double)arg.Player.viewAnim.RemainTime >= 133.2)
			{
				hideWeapon = true;
			}
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 172)
			{
				hideWeapon = true;
			}
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 171 && (double)arg.Player.viewAnim.RemainTime >= 233.09999999999997)
			{
				hideWeapon = true;
			}
			if (arg.Player.viewAnim.ViewAnimInfo.StateId == 16 && (double)arg.Player.viewAnim.RemainTime <= 333.0 && (double)arg.Player.viewAnim.RemainTime <= 566.0999999999999)
			{
				hideWeapon = true;
			}
			setHideWeapon(arg.CurrentWeapon, hideWeapon);
		}

		private void checkBreakThrow(ref CommonWeaponArg arg)
		{
			if (isStartThrow(arg.CurrentWeapon) && arg.Player.viewAnim.ViewAnimInfo.StateId != 31 && arg.Player.viewAnim.ViewAnimInfo.StateId != 170 && arg.Player.viewAnim.ViewAnimInfo.StateId != 172 && arg.Player.viewAnim.ViewAnimInfo.StateId != 30 && arg.Player.viewAnim.ViewAnimInfo.StateId != 169 && arg.Player.viewAnim.ViewAnimInfo.StateId != 171 && arg.Player.viewAnim.ViewAnimInfo.StateId != 16)
			{
				setStartThrow(arg.CurrentWeapon, b: false);
			}
		}

		private bool timeToThrow(ref CommonWeaponArg arg)
		{
			if (isStartThrow(arg.CurrentWeapon))
			{
				return (float)arg.Player.clientTime.ClientTime > getDelayTime(arg.CurrentWeapon);
			}
			return false;
		}

		private void checkBreakContinuesHit(CommonWeaponArg arg)
		{
			if (arg.Cmd.IsAttackOn && (float)arg.Player.clientTime.ClientTime < arg.CurrentWeapon.attack.NextAttackTimer && arg.CurrentWeapon.clip.Clip > 0)
			{
				setOtherFireAnim(arg);
			}
		}

		protected void setOtherFireAnim(CommonWeaponArg arg)
		{
			if (!isStartThrow(arg.CurrentWeapon) && (arg.Player.viewAnim.ViewAnimInfo.StateId == 30 || arg.Player.viewAnim.ViewAnimInfo.StateId == 169) && arg.Player.viewAnim.RightCurrentTime < 50)
			{
				setFireAnim(ref arg);
			}
		}
	}

	private static readonly int[] ATTACK_INTERVAL = new int[3] { 866, 900, 1033 };

	private static readonly int[] ATTACK_DELAY = new int[3] { 200, 240, 400 };

	private static readonly int RAISE_DELAY = 120;

	private static readonly int RAISE_INTERVAL = 733;

	private static readonly int HIDE_WEAPON = 2;

	public TrickGlassDartsPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new TrickGlassDartsLeftAction(contexts));
		FrameActions.Add(new TrickGlassDartsFrameAction());
	}

	public static int getAttackIndex(WeaponEntity weapon)
	{
		return (int)weapon.basicInfo.Data.NextSkillTimer;
	}

	public static void setAttackIndex(WeaponEntity weapon, int attackIndex)
	{
		weapon.basicInfo.Data.NextSkillTimer = (uint)attackIndex;
	}

	public static int getNextAttackIndexByRaiseAnim(WeaponEntity argCurrentWeapon, PlayerEntity argPlayer)
	{
		return argPlayer.viewAnim.ViewAnimInfo.StateId switch
		{
			30 => 1, 
			169 => 2, 
			_ => 0, 
		};
	}

	public static int getAttackAnim(int attackIndex)
	{
		return attackIndex switch
		{
			0 => 31, 
			1 => 170, 
			2 => 172, 
			_ => 31, 
		};
	}

	public static void setStartThrow(WeaponEntity argCurrentWeapon, bool b)
	{
		argCurrentWeapon.special.SpecialMode = b;
	}

	public static bool isStartThrow(WeaponEntity argCurrentWeapon)
	{
		return argCurrentWeapon.special.SpecialMode;
	}

	public static void setDelayTime(WeaponEntity argCurrentWeapon, long b)
	{
		argCurrentWeapon.attack.NextSecondaryAttackTimer = b;
	}

	public static float getDelayTime(WeaponEntity argCurrentWeapon)
	{
		return argCurrentWeapon.attack.NextSecondaryAttackTimer;
	}

	public static void setHideWeapon(WeaponEntity argCurrentWeapon, bool hideWeapon)
	{
		if (hideWeapon)
		{
			argCurrentWeapon.special.EffectLevel |= HIDE_WEAPON;
		}
		else
		{
			argCurrentWeapon.special.EffectLevel &= ~HIDE_WEAPON;
		}
	}

	private static int setFireAnim(ref CommonWeaponArg arg)
	{
		setAttackIndex(arg.CurrentWeapon, getNextAttackIndexByRaiseAnim(arg.CurrentWeapon, arg.Player));
		setStartThrow(arg.CurrentWeapon, b: true);
		setDelayTime(arg.CurrentWeapon, arg.Player.clientTime.ClientTime + ATTACK_DELAY[getAttackIndex(arg.CurrentWeapon)]);
		arg.CurrentWeapon.attack.NextAttackTimer = arg.Player.clientTime.ClientTime + ATTACK_INTERVAL[getAttackIndex(arg.CurrentWeapon)];
		int attackAnim = getAttackAnim(getAttackIndex(arg.CurrentWeapon));
		PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
		PlayerAnimationUtility.SetViewAnimation(arg.Player, attackAnim);
		switch (getAttackIndex(arg.CurrentWeapon))
		{
		case 0:
			FireUtility.PlayFireSound(ref arg);
			break;
		case 1:
			FireUtility.PlayFire3Sound(ref arg);
			break;
		case 2:
			FireUtility.PlayFire4Sound(ref arg);
			break;
		}
		return 0;
	}

	public static bool isHideWeapon(WeaponEntity argCurrentWeapon)
	{
		return (argCurrentWeapon.special.EffectLevel & HIDE_WEAPON) > 0;
	}
}

using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class TrickDaggerPredicationSystem : AbstractAttackPredicationSystem
{
	internal class TrickDaggerFrameAction : AbstractKnifeFrameAction
	{
		protected override bool CheckDelayAttack(ref CommonWeaponArg arg)
		{
			if (!arg.Player.viewAnim.Equals(31) && !arg.Player.viewAnim.Equals(29) && !arg.Player.viewAnim.Equals(20) && !arg.Player.viewAnim.Equals(72) && !arg.Player.viewAnim.Equals(47) && !arg.Player.viewAnim.Equals(30))
			{
				return false;
			}
			return true;
		}
	}

	internal class TrickDaggerRightAction : KnifeRightAction
	{
		public TrickDaggerRightAction(Contexts contexts, bool raise)
			: base(contexts)
		{
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			_ = arg.CurrentWeapon.basicInfo.Info;
			float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			if (arg.Player.viewAnim.Equals(20))
			{
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlaySecFireSound);
			}
			if (arg.Player.viewAnim.Equals(72))
			{
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFire4Sound);
			}
			return 0;
		}

		protected override int SetNextAttack(ref CommonWeaponArg arg)
		{
			KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashSlashTime * (1f - GetTrickAttackSpeed(arg.CurrentWeapon)));
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.CurrentWeapon.attack.NextAttackTimer;
			return 0;
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			int index = 2;
			if (arg.CurrentWeapon.GetComponent(index) is AttachComponent attachComponent)
			{
				TrickDaggerAttach trickDaggerAttach = attachComponent.Data as TrickDaggerAttach;
				if (!IsSecondSweep(arg.CurrentWeapon))
				{
					if (trickDaggerAttach != null)
					{
						trickDaggerAttach.sweep = false;
					}
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
				}
				else
				{
					if (trickDaggerAttach != null)
					{
						trickDaggerAttach.sweep = true;
					}
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
				}
			}
			arg.Player.viewAnim.RightSpeed = 1f + GetTrickAttackSpeed(arg.CurrentWeapon);
			return 0;
		}

		protected override int GetDelayTime(ref CommonWeaponArg arg)
		{
			return GetDelayAttackTime(ref arg);
		}
	}

	internal class TrickDaggerLeftAction : KnifeLeftAction
	{
		public TrickDaggerLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddFire(SetAttackAnim);
			AddFire(SetNextAttack);
			AddFire(OnFire);
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			base.OnFire(ref arg);
			float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			if (arg.Player.viewAnim.Equals(31))
			{
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
			}
			if (arg.Player.viewAnim.Equals(29))
			{
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
			}
			return 0;
		}

		protected override int SetNextAttack(ref CommonWeaponArg arg)
		{
			KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				arg.CurrentWeapon.attack.NextAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashSlashTime * (1f - GetTrickAttackSpeed(arg.CurrentWeapon)));
			}
			else
			{
				arg.CurrentWeapon.attack.NextAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashStabTime * (1f - GetTrickAttackSpeed(arg.CurrentWeapon)));
			}
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.CurrentWeapon.attack.NextAttackTimer;
			return 0;
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			arg.Player.viewAnim.RightSpeed = 1f + GetTrickAttackSpeed(arg.CurrentWeapon);
			return 0;
		}

		protected override int GetDelayTime(ref CommonWeaponArg arg)
		{
			return GetDelayAttackTime(ref arg);
		}
	}

	public static readonly int DELAY_ATTACK_SLASH_TIME = 300;

	public static readonly int DELAY_ATTACK_STAB_TIME = 433;

	public static readonly int RAISE_ATTACK_DELAY = 233;

	public static readonly int ATTACK2_DELAY = 400;

	public TrickDaggerPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new TrickDaggerLeftAction(contexts));
		RightActions.Add(new TrickDaggerRightAction(contexts, raise: false));
		FrameActions.Add(new TrickDaggerFrameAction());
	}

	private static bool IsSecondSweep(WeaponEntity argCurrentWeapon)
	{
		return GetTrickStage(argCurrentWeapon) >= 3;
	}

	public static float GetTrickAttackSpeed(WeaponEntity argCurrentWeapon)
	{
		float result = 0f;
		switch (GetTrickStage(argCurrentWeapon))
		{
		case 4:
			result = 0.1f;
			break;
		case 5:
			result = 0.2f;
			break;
		}
		return result;
	}

	public static int GetTrickStage(WeaponEntity argCurrentWeapon)
	{
		return argCurrentWeapon.power.Power2;
	}

	protected static int GetDelayAttackTime(ref CommonWeaponArg arg)
	{
		int num = 0;
		return arg.Player.viewAnim.ViewAnimInfo.StateId switch
		{
			31 => DELAY_ATTACK_SLASH_TIME, 
			20 => DELAY_ATTACK_STAB_TIME, 
			72 => 600, 
			29 => ATTACK2_DELAY, 
			47 => RAISE_ATTACK_DELAY, 
			_ => RAISE_ATTACK_DELAY, 
		};
	}
}

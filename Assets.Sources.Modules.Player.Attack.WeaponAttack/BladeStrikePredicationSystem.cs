using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class BladeStrikePredicationSystem : AbstractAttackPredicationSystem
{
	public class PistolFrameAction : AbstractFrameAction
	{
		public PistolFrameAction(Contexts contexts)
			: base(contexts)
		{
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			return base.Action(ref arg);
		}

		protected override bool IsPistol()
		{
			return true;
		}
	}

	internal class BladeStrikeRightAction : KnifeRightAction
	{
		private bool tmpSweepFlag;

		public BladeStrikeRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override int SetNextAttack(ref CommonWeaponArg arg)
		{
			KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.StabStabTime);
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.StabSlashTime);
			return 0;
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			if ((arg.CurrentWeapon.special.EffectLevel & 0x80000) > 0 || (arg.CurrentWeapon.special.EffectLevel & 0x20000) > 0)
			{
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 40);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
				tmpSweepFlag = true;
			}
			else
			{
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
			}
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
			{
				return false;
			}
			if (!WeaponUtility.CanSecondaryAttack(ref arg))
			{
				return false;
			}
			return true;
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			_ = arg.CurrentWeapon.basicInfo.Info;
			KnifeFire(ref arg, arg.Cmd.Seq, 145 + arg.CurrentWeapon.power.Power, FireUtility.PlaySecFireSound);
			tmpSweepFlag = false;
			FireUtility.RightFireQkhhAfterFire(ref arg);
			return 0;
		}
	}

	public BladeStrikePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new KnifeLeftAction(contexts));
		RightActions.Add(new BladeStrikeRightAction(contexts));
	}
}

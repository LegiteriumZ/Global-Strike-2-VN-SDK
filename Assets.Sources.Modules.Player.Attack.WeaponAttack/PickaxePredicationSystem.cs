using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class PickaxePredicationSystem : AbstractAttackPredicationSystem
{
	internal class PickaxeLeftAction : KnifeLeftAction
	{
		public static int DELAY_ATTACK_SLASH_TIME = 200;

		public PickaxeLeftAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override int SetNextAttack(ref CommonWeaponArg arg)
		{
			KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			float num = 1f + (float)arg.CurrentWeapon.basicInfo.Data.Power * 0.05f;
			arg.Player.viewAnim.RightSpeed = num;
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashSlashTime / num);
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)((float)arg.ClientTime + (float)knifeWeaponInfo.SlashStabTime / num);
			WeaponUtility.SetDelayAttackSlashTime(ref arg, (int)((float)DELAY_ATTACK_SLASH_TIME / num));
			return 0;
		}
	}

	internal class PickaxeRightAction : KnifeRightAction
	{
		public static int DELAY_ATTACK_STAB_TIME = 500;

		public PickaxeRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
			{
				return false;
			}
			if (!arg.Cmd.IsSecondaryAttackOn)
			{
				return false;
			}
			if (!CanSecondaryAttack(ref arg))
			{
				return false;
			}
			return true;
		}

		private bool CanSecondaryAttack(ref CommonWeaponArg arg)
		{
			if ((arg.CurrentWeapon.basicInfo.Data.EffectLevel & 1) <= 0)
			{
				return (float)arg.ClientTime >= arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
			}
			if (arg.ClientTime < arg.CurrentWeapon.basicInfo.Data.NextSkillTimer)
			{
				return (float)arg.ClientTime >= arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
			}
			return false;
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}

		protected override int SetNextAttack(ref CommonWeaponArg arg)
		{
			KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			float num = 1f + (float)arg.CurrentWeapon.basicInfo.Data.Power * 0.05f;
			arg.Player.viewAnim.RightSpeed = num;
			arg.CurrentWeapon.attack.NextAttackTimer = (float)arg.ClientTime + (float)knifeWeaponInfo.StabSlashTime / num;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (float)arg.ClientTime + (float)knifeWeaponInfo.StabStabTime / num;
			WeaponUtility.SetDelayAttackStabTime(ref arg, (int)((float)DELAY_ATTACK_STAB_TIME / num));
			return 0;
		}
	}

	public PickaxePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new PickaxeLeftAction(contexts));
		RightActions.Add(new PickaxeRightAction(contexts));
	}
}

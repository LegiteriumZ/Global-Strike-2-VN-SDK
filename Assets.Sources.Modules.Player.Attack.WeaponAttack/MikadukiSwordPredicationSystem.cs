using System;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class MikadukiSwordPredicationSystem : AbstractAttackPredicationSystem
{
	internal class MikadukiSwordLeftAction : AbstractKnifeFireAction, ILeftCmdAction, ICmdAction
	{
		public MikadukiSwordLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.KnifeHitPlayerAction);
			AddAction(HitUtility.KnifeHitWorldAction);
			AddFire(SetAttackAnim);
			AddFire(SetNextAttack);
			AddFire(OnFire);
			AddAction(HitPlayer);
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			_ = arg.CurrentWeapon.basicInfo.Info;
			int num = 140 + Math.Max(0, arg.CurrentWeapon.power.Power / 5);
			int delayTime = 300;
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				delayTime = 100;
			}
			KnifeFireWithSureDelayTime(ref arg, arg.Cmd.Seq, num, delayTime, FireUtility.PlayFireSound);
			return 0;
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 69) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 70) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 69);
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
				}
			}
			else if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 31);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			}
			return 0;
		}

		protected override int SetNextAttack(ref CommonWeaponArg arg)
		{
			KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.SlashSlashTime);
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + knifeWeaponInfo.SlashStabTime);
			return 0;
		}

		protected int HitPlayer(ref HitPlayerArgs arg)
		{
			arg.currentWeapon.attack.NextAttackTimer += 50f;
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
			{
				return false;
			}
			bool result = false;
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				if (arg.CurrentWeapon.special.SpecialMode && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 69) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 70) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46))
				{
					result = true;
				}
			}
			else if (WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime))
			{
				result = true;
			}
			else if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && (70 == arg.Player.viewAnim.ViewAnimInfo.StateId || 30 == arg.Player.viewAnim.ViewAnimInfo.StateId) && !arg.CurrentWeapon.hasDelayAttack && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
			{
				result = true;
			}
			return result;
		}
	}

	internal class MikadukiSwordRightAction : KnifeRightAction
	{
		public MikadukiSwordRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
			{
				return false;
			}
			if (arg.Cmd.IsAttackOn)
			{
				return false;
			}
			if (!WeaponUtility.CanSecondaryAttack(ref arg) || arg.CurrentWeapon.special.SpecialMode)
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
			int num = 140 + Math.Max(0, arg.CurrentWeapon.power.Power / 5);
			KnifeFire(ref arg, arg.Cmd.Seq, num, FireUtility.PlaySecFireSound);
			return 0;
		}
	}

	public MikadukiSwordPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new MikadukiSwordLeftAction(contexts));
		RightActions.Add(new MikadukiSwordRightAction(contexts));
		FrameActions.Add(new MikadukiSwordFrameAction(contexts));
	}
}

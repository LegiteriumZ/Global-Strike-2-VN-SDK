using System;
using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using math;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class MikadukiSwordDklPredicationSystem : AbstractAttackPredicationSystem
{
	internal class MikadukiSwordDklFrameAction : IFrameCmdAction, ICmdAction
	{
		private static int[] config = new int[5] { 200, 300, 400, 50, -25 };

		public MikadukiSwordDklFrameAction(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			int index = 2;
			if (!(arg.CurrentWeapon.GetComponent(index) is AttachComponent { Data: not null } attachComponent) || !(attachComponent.Data is MikadukiSwordBaseAttach))
			{
				return false;
			}
			MikadukiSwordBaseAttach mikadukiSwordBaseAttach = attachComponent.Data as MikadukiSwordBaseAttach;
			config[3] = mikadukiSwordBaseAttach.pardon;
			config[4] = mikadukiSwordBaseAttach.offset;
			if (!arg.CurrentWeapon.special.SpecialMode)
			{
				resetParm(arg.CurrentWeapon);
				WeaponUtility.SetDelayAttackSlashTime(ref arg, 300);
			}
			else
			{
				WeaponUtility.SetDelayAttackSlashTime(ref arg, 100);
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 13) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 14))
			{
				arg.CurrentWeapon.special.SpecialMode = false;
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 69) && arg.Player.viewAnim.RemainTime < 450 && arg.Player.viewAnim.RemainTime > 400 && (arg.CurrentWeapon.special.EffectLevel & 0x2000) > 0)
			{
				enterSpecialStep(ref arg);
			}
			if (arg.Cmd.IsDemolitionOn)
			{
				if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && !arg.CurrentWeapon.special.SpecialMode)
				{
					arg.CurrentWeapon.special.SpecialMode = true;
					NormalToSpecialModel(ref arg);
				}
				if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 69) && arg.Player.viewAnim.RemainTime < 400 && arg.Player.viewAnim.RemainTime > 0 && (arg.CurrentWeapon.special.EffectLevel & 0x2000) > 0)
				{
					sucess(ref arg);
				}
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 70) && arg.Player.viewAnim.RemainTime < 70)
			{
				SpecialToNormalModel(ref arg);
				arg.CurrentWeapon.special.SpecialMode = false;
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 70))
			{
				resetParm(arg.CurrentWeapon);
			}
			return true;
		}

		private void sucess(ref CommonWeaponArg arg)
		{
			if (Math.Abs(arg.ClientTime - arg.CurrentWeapon.special.Level + config[4]) > config[3] && !getDoublePctMustSucceed(arg.CurrentWeapon))
			{
				resetParm(arg.CurrentWeapon);
				return;
			}
			resetParm(arg.CurrentWeapon);
			if (!getDoublePctMustSucceed(arg.CurrentWeapon) || !arg.Cmd.IsAttackOn || !arg.Cmd.IsShowGun)
			{
				shouDao(ref arg);
			}
		}

		private void enterSpecialStep(ref CommonWeaponArg arg)
		{
			if (config == null)
			{
				resetParm(arg.CurrentWeapon);
				return;
			}
			arg.CurrentWeapon.special.Level = arg.ClientTime + UniformRandom.RandomInt(arg.Cmd.Seq, config[0], config[1]);
			arg.CurrentWeapon.power.Power2 = arg.ClientTime;
			arg.CurrentWeapon.power.MaxPower2 = arg.ClientTime + config[2];
		}

		private void resetParm(WeaponEntity currentWeapon)
		{
			currentWeapon.power.Power2 = 0;
			currentWeapon.power.MaxPower2 = 0;
			currentWeapon.special.Level = 0;
		}

		private static void shouDao(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 46);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 46);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		}

		private static void NormalToSpecialModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		}

		private static void SpecialToNormalModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
		}

		public static bool getDoublePctMustSucceed(WeaponEntity currentWeapon)
		{
			return (currentWeapon.special.EffectLevel & int.MinValue) != 0;
		}
	}

	internal class MikadukiSwordDklLeftAction : AbstractKnifeFireAction, ILeftCmdAction, ICmdAction
	{
		public MikadukiSwordDklLeftAction(Contexts contexts)
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
			int num = 140 + Math.Max(0, arg.CurrentWeapon.power.Power / 10);
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

	internal class MikadukiSwordDklRightAction : KnifeRightAction
	{
		public MikadukiSwordDklRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
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
			int num = 140 + Math.Max(0, arg.CurrentWeapon.power.Power / 10);
			KnifeFire(ref arg, arg.Cmd.Seq, num, FireUtility.PlaySecFireSound);
			return 0;
		}
	}

	public MikadukiSwordDklPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new MikadukiSwordDklLeftAction(contexts));
		RightActions.Add(new MikadukiSwordDklRightAction(contexts));
		FrameActions.Add(new MikadukiSwordDklFrameAction(contexts));
	}
}

using System.Collections.Generic;
using Assets.Sources.Info.Weapon.WeaponInfo;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;
using Sources.Modules.Player.Chain;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Type91DaggerPredicationSystem : AbstractAttackPredicationSystem
{
	internal class Type91DaggerLeftAction : AbstractKnifeFireAction, ILeftCmdAction, ICmdAction
	{
		public Type91DaggerLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(KnifeHitWorldAction);
			AddAction(KnifeHitPlayerAction);
			AddAction(HitPlayer);
			AddCondition();
		}

		private void AddCondition()
		{
			WeaponChain<CommonWeaponArg> weaponChain = base.OnFireFunc.AddChain(0, (WeaponFireChain)SetNextAttack);
			weaponChain.AddChain((WeaponFireChain)SetAttackAnim);
			weaponChain.AddChain((WeaponFireChain)OnFire);
			WeaponChain<CommonWeaponArg> weaponChain2 = base.OnFireFunc.AddChain(1, (WeaponFireChain)SetOtherFireAnim);
			weaponChain2.AddChain((WeaponFireChain)SetNextAttack);
			weaponChain2.AddChain((WeaponFireChain)SetAttackAnim);
			weaponChain2.AddChain((WeaponFireChain)OnFire);
			weaponChain2.AddChain((WeaponFireChain)ResetMode);
		}

		protected virtual int SetOtherFireAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && !arg.CurrentWeapon.hasDelayAttack && (70 == arg.Player.viewAnim.ViewAnimInfo.StateId || 30 == arg.Player.viewAnim.ViewAnimInfo.StateId) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
			{
				arg.CurrentWeapon.special.SpecialMode = true;
				return 0;
			}
			return -1;
		}

		protected virtual int ResetMode(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.special.SpecialMode = false;
			return 0;
		}

		protected override int SetNextAttack(ref CommonWeaponArg arg)
		{
			KnifeWeaponInfo knifeWeaponInfo = arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo;
			arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + (((arg.CurrentWeapon.basicInfo.Data.EffectLevel & 1) > 0) ? knifeWeaponInfo.SlashSlashTime : knifeWeaponInfo.SlashStabTime));
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.CurrentWeapon.attack.NextAttackTimer;
			return 0;
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			if ((arg.CurrentWeapon.basicInfo.Data.EffectLevel & 1) > 0)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, arg.CurrentWeapon.special.SpecialMode ? 71 : 69);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, arg.CurrentWeapon.special.SpecialMode ? 29 : 31);
			}
			return 0;
		}

		protected virtual int HitPlayer(ref HitPlayerArgs arg)
		{
			if (arg.cmd != null)
			{
				if (arg.cmd.IsAttackOn)
				{
					arg.currentWeapon.attack.NextAttackTimer += 50f;
				}
				else
				{
					arg.currentWeapon.attack.NextAttackTimer += 100f;
					arg.currentWeapon.attack.NextSecondaryAttackTimer += 100f;
				}
			}
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (!(arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo))
			{
				return false;
			}
			return WeaponUtility.CanAttack(arg.CurrentWeapon, arg.ClientTime);
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			base.OnFireFunc.Step(ref arg);
			return true;
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			_ = arg.CurrentWeapon.basicInfo.Info;
			float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
			return 0;
		}

		protected int OnFireInDelayTime(ref CommonWeaponArg arg, int delayTime)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			_ = arg.CurrentWeapon.basicInfo.Info;
			float shotDistance = (arg.CurrentWeapon.basicInfo.Info as DefaultWeaponInfo).ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
			if (delayTime > 0)
			{
				if (arg.CurrentWeapon.hasDelayAttack)
				{
					arg.CurrentWeapon.delayAttack.DelayFireRemain = delayTime;
					arg.CurrentWeapon.delayAttack.IsLeftAttack = arg.Cmd.IsAttackOn;
					arg.CurrentWeapon.delayAttack.Player = arg.Player;
					arg.CurrentWeapon.delayAttack.CurrentWeapon = arg.CurrentWeapon;
					arg.CurrentWeapon.delayAttack.Seq = arg.Cmd.Seq;
					arg.CurrentWeapon.delayAttack.Distance = shotDistance;
					arg.CurrentWeapon.delayAttack.SoundFunc = new FireUtility.FireFunc(FireUtility.PlayFireSound);
					arg.CurrentWeapon.delayAttack.CallBack = base.DelayAttackDone;
					arg.CurrentWeapon.delayAttack.CurrentFrameInterval = arg.Cmd.FrameInterval;
					arg.CurrentWeapon.delayAttack.Cmds.Clear();
				}
				else
				{
					arg.CurrentWeapon.AddDelayAttack(delayTime, arg.Cmd.IsAttackOn, arg.Player, arg.CurrentWeapon, arg.Cmd.Seq, shotDistance, new FireUtility.FireFunc(FireUtility.PlayFireSound), newIsDelayAttackImmdiately: false, arg.Cmd.FrameInterval, new Dictionary<int, IUserCmd>(), base.DelayAttackDone);
				}
			}
			return 0;
		}

		public static int KnifeHitWorldAction(ref HitWorldArgs arg)
		{
			if ((arg.currentWeapon.basicInfo.Data.EffectLevel & 1) <= 0)
			{
				HitUtility.KnifeHitWorldAction(ref arg);
			}
			return 0;
		}

		public static int KnifeHitPlayerAction(ref HitPlayerArgs arg)
		{
			if ((arg.currentWeapon.basicInfo.Data.EffectLevel & 1) <= 0)
			{
				HitUtility.KnifeHitPlayerAction(ref arg);
			}
			return 0;
		}
	}

	internal class Type91DaggerRightActions : AbstractKnifeFireAction, IRightCmdAction, ICmdAction
	{
		public Type91DaggerRightActions(Contexts contexts)
			: base(contexts)
		{
			AddAction(KnifeHitPlayerAction);
			AddAction(KnifeHitWorldAction);
			AddAction(HitPlayer);
			AddCondition();
		}

		public static int KnifeHitWorldAction(ref HitWorldArgs arg)
		{
			if (arg.currentWeapon.basicInfo.Data.Power == 0)
			{
				if (arg.player.clientTime.ClientTime > arg.currentWeapon.basicInfo.Data.NextSkillTimer)
				{
					arg.currentWeapon.basicInfo.Data.NextSkillTimer = (uint)(arg.player.clientTime.ClientTime + 50000);
				}
				else
				{
					HitUtility.KnifeHitWorldAction(ref arg);
				}
			}
			else if ((arg.currentWeapon.basicInfo.Data.EffectLevel & 1) <= 0)
			{
				HitUtility.KnifeHitWorldAction(ref arg);
			}
			return 0;
		}

		public static int KnifeHitPlayerAction(ref HitPlayerArgs arg)
		{
			if (arg.currentWeapon.basicInfo.Data.Power == 0)
			{
				if (arg.player.clientTime.ClientTime > arg.currentWeapon.basicInfo.Data.NextSkillTimer)
				{
					arg.currentWeapon.basicInfo.Data.NextSkillTimer = (uint)(arg.player.clientTime.ClientTime + 50000);
				}
				else
				{
					HitUtility.KnifeHitPlayerAction(ref arg);
				}
			}
			else if ((arg.currentWeapon.basicInfo.Data.EffectLevel & 1) <= 0)
			{
				HitUtility.KnifeHitPlayerAction(ref arg);
			}
			return 0;
		}

		private void AddCondition()
		{
			WeaponChain<CommonWeaponArg> weaponChain = base.OnFireFunc.AddChain(0, (WeaponFireChain)SetNextAttack);
			weaponChain.AddChain((WeaponFireChain)SetAttackAnim);
			weaponChain.AddChain((WeaponFireChain)OnFire);
		}

		protected virtual int SetOtherFireAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Info.HasOtherFire && !arg.CurrentWeapon.hasDelayAttack && (70 == arg.Player.viewAnim.ViewAnimInfo.StateId || 30 == arg.Player.viewAnim.ViewAnimInfo.StateId) && PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, arg.Player.viewAnim.ViewAnimInfo.StateId) - arg.Player.viewAnim.RemainTime < 50)
			{
				arg.CurrentWeapon.special.SpecialMode = true;
				return 0;
			}
			return -1;
		}

		protected override int SetNextAttack(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo knifeWeaponInfo)
			{
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer = (uint)(arg.ClientTime + (((arg.CurrentWeapon.basicInfo.Data.EffectLevel & 1) > 0) ? knifeWeaponInfo.StabSlashTime : knifeWeaponInfo.StabStabTime));
				arg.CurrentWeapon.attack.NextAttackTimer = arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
			}
			return 0;
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			if (arg.CurrentWeapon.basicInfo.Data.Power == 0)
			{
				if (arg.ClientTime > arg.CurrentWeapon.basicInfo.Data.NextSkillTimer)
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 28);
				}
				else
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
				}
			}
			else if ((arg.CurrentWeapon.basicInfo.Data.EffectLevel & 1) > 0)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
			}
			else
			{
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
			if (arg.Cmd.IsAttackOn)
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
			if (arg.CurrentWeapon.basicInfo.Info is DefaultWeaponInfo defaultWeaponInfo)
			{
				float shotDistance = defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlaySecFireSound);
			}
			return 0;
		}

		protected int OnFireInDelayTime(ref CommonWeaponArg arg, int delayTime)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			_ = arg.CurrentWeapon.basicInfo.Info;
			if (arg.CurrentWeapon.basicInfo.Info is DefaultWeaponInfo defaultWeaponInfo)
			{
				float shotDistance = defaultWeaponInfo.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: true);
				KnifeFire(ref arg, arg.Cmd.Seq, shotDistance, FireUtility.PlayFireSound);
			}
			return 0;
		}

		protected virtual int HitPlayer(ref HitPlayerArgs arg)
		{
			if (arg.cmd != null)
			{
				if (arg.cmd.IsAttackOn)
				{
					arg.currentWeapon.attack.NextAttackTimer += 50f;
				}
				else
				{
					arg.currentWeapon.attack.NextAttackTimer += 100f;
					arg.currentWeapon.attack.NextSecondaryAttackTimer += 100f;
				}
			}
			return 0;
		}
	}

	internal class Type91DaggerFrameAction : AbstractKnifeFrameAction
	{
		protected override bool CheckDelayAttack(ref CommonWeaponArg arg)
		{
			if (!arg.Player.viewAnim.Equals(29) && !arg.Player.viewAnim.Equals(71) && !arg.Player.viewAnim.Equals(28) && !arg.Player.viewAnim.Equals(31) && !arg.Player.viewAnim.Equals(69) && !arg.Player.viewAnim.Equals(20) && !arg.Player.viewAnim.Equals(72))
			{
				return false;
			}
			return true;
		}

		protected override void PostFrame(ref CommonWeaponArg arg)
		{
			ShowWeapon(ref arg);
			if (arg.Player.viewAnim.Equals(28) && arg.Player.viewAnim.RemainTime < 50)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 16);
			}
		}

		private void ShowWeapon(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && (arg.CurrentWeapon.basicInfo.Data.EffectLevel & 1) > 0 && CanShowWeaponAnim(ref arg))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 117);
			}
		}

		private bool CanShowWeaponAnim(ref CommonWeaponArg arg)
		{
			if (!arg.Player.viewAnim.Equals(31) && !arg.Player.viewAnim.Equals(29) && !arg.Player.viewAnim.Equals(20) && !arg.Player.viewAnim.Equals(28) && !arg.Player.viewAnim.Equals(36) && !arg.Player.viewAnim.Equals(37) && !arg.Player.viewAnim.Equals(69) && !arg.Player.viewAnim.Equals(71) && !arg.Player.viewAnim.Equals(72))
			{
				return !arg.Player.viewAnim.Equals(117);
			}
			return false;
		}
	}

	public Type91DaggerPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new Type91DaggerLeftAction(contexts));
		RightActions.Add(new Type91DaggerRightActions(contexts));
		FrameActions.Add(new Type91DaggerFrameAction());
	}
}

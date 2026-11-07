using System;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RevolverBattlePredicationSystem : AbstractAttackPredicationSystem
{
	internal class RevolverBattleLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public RevolverBattleLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.PostolFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(FireUtility.LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if ((arg.CurrentWeapon.special.EffectLevel & 0x40) > 0 || arg.CurrentWeapon.power.Power > 0 || arg.CurrentWeapon.attack.ShotsFired >= 1 || arg.CurrentWeapon.special.Level == 1)
			{
				return false;
			}
			return base.CanFire(ref arg);
		}

		protected override int OnFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			arg.CurrentWeapon.attack.ShotsFired++;
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval;
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			GunFire(ref arg, arg.Cmd.Seq, shotDistance);
			return 0;
		}
	}

	internal class RevolverBattleFrameAction : PistolFrameAction
	{
		private readonly MessageContext _messageContext;

		public RevolverBattleFrameAction(Contexts contexts, IIdleCmdAction action)
			: base(contexts, action)
		{
			AddFrameAction(PostFrame);
			AddFrameAction(BusrtRemainingFire);
			AddFrameAction(XuliFireQkhhAfterFire);
			_messageContext = contexts.message;
		}

		public static int XuliFireQkhhAfterFire(ref CommonWeaponArg arg)
		{
			if (arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
			{
				WeaponUtility.AllFire(arg.Player.firstPersonUnityObjects.RightFires, (arg.CurrentWeapon.special.EffectLevel & 0x40) > 0);
			}
			return 0;
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			base.Action(ref arg);
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (arg.CurrentWeapon.special.Level == 1)
			{
				arg.Player.SetWeaponLock(b: true);
			}
			else
			{
				arg.Player.SetWeaponLock(b: false);
			}
			if (arg.Cmd.IsDemolitionOn && arg.CurrentWeapon.special.SpecialMode)
			{
				if ((arg.CurrentWeapon.special.EffectLevel & 0x10) > 0)
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_NOENERGY"));
					NotifyManager.ForceInvoke(38);
				}
				else if ((arg.CurrentWeapon.special.EffectLevel & 0x20) > 0)
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_CHOOSE_TARGET"));
					NotifyManager.ForceInvoke(38);
				}
				else if ((arg.CurrentWeapon.special.EffectLevel & 0x80) > 0)
				{
					_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_IN_BATTLE"));
					NotifyManager.ForceInvoke(38);
				}
			}
			if (arg.Cmd.IsSecondaryAttackOn && (float)arg.ClientTime > arg.CurrentWeapon.attack.NextAttackTimer && arg.CurrentWeapon.power.Power2 == 0 && RuleUtilty.IsGeneralPve(raceType) && arg.CurrentWeapon.basicInfo.Data.Clip > 0)
			{
				arg.CurrentWeapon.power.MaxPower2 += arg.Cmd.FrameInterval;
			}
			if (arg.CurrentWeapon.power.MaxPower2 > 500 && (arg.CurrentWeapon.special.EffectLevel & 0x40) == 0 && arg.CurrentWeapon.power.Power2 == 0)
			{
				arg.CurrentWeapon.special.EffectLevel |= 64;
				if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 149))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 63);
				}
			}
			if (!arg.Cmd.IsSecondaryAttackOn)
			{
				if ((arg.CurrentWeapon.special.EffectLevel & 0x40) > 0 && arg.CurrentWeapon.power.MaxPower2 >= arg.CurrentWeapon.power.RpgMaxPower + 500)
				{
					gofFireAction(ref arg);
				}
				arg.CurrentWeapon.power.MaxPower2 = 0;
				arg.CurrentWeapon.special.EffectLevel &= -65;
			}
			if (arg.Cmd.IsSecondaryAttackOn && (float)arg.ClientTime > arg.CurrentWeapon.attack.NextAttackTimer + (float)arg.CurrentWeapon.basicInfo.Info.AttackInterval && arg.CurrentWeapon.power.Power2 == 1 && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 149) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 148))
			{
				gofFireAction(ref arg);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime;
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) && (arg.CurrentWeapon.special.EffectLevel & 0x40) == 0)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 13);
			}
			return true;
		}

		private void gofFireAction(ref CommonWeaponArg arg)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 148) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 149) && arg.CurrentWeapon.basicInfo.Data.Clip > 0)
			{
				IEntitsWeaponInfo info = arg.CurrentWeapon.basicInfo.Info;
				if (info.SpreadLogic != null)
				{
					info.SpreadLogic.BeforeFire(out arg.CurrentWeapon.spread.Spread, arg.Player, arg.CurrentWeapon, arg.Cmd, isWeightlessness: true);
				}
				FireUtility.FireSetAccuracy(ref arg);
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 149);
				arg.CurrentWeapon.power.Power = Math.Min(arg.CurrentWeapon.basicInfo.Data.Clip, 6);
			}
		}

		private int PostFrame(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power > 0 && (float)arg.ClientTime - arg.CurrentWeapon.attack.NextAttackTimer + (float)arg.CurrentWeapon.basicInfo.Info.AttackInterval + 355f > 125f && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 149))
			{
				return 0;
			}
			return -1;
		}

		private int BusrtRemainingFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			WeaponUtility.DescClip(arg.CurrentWeapon);
			if (arg.CurrentWeapon.clip.Clip < 0)
			{
				arg.CurrentWeapon.clip.Clip = 0;
				arg.CurrentWeapon.power.Power = 0;
				return 0;
			}
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval + 355;
			if (BindAction is AbstractFireAction abstractFireAction)
			{
				abstractFireAction.GunFire(ref arg, arg.Cmd.Seq + arg.CurrentWeapon.power.Power, shotDistance);
			}
			FireUtility.PlayFireSound(ref arg);
			arg.Player.punchOrientation.PunchPitch += 0.3f;
			arg.CurrentWeapon.power.Power--;
			if (arg.CurrentWeapon.power.Power == 0)
			{
				if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 148))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 16);
				}
				arg.CurrentWeapon.special.EffectLevel &= -65;
			}
			return 0;
		}
	}

	public RevolverBattlePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		RevolverBattleLeftAction revolverBattleLeftAction = new RevolverBattleLeftAction(contexts);
		LeftActions.Add(revolverBattleLeftAction);
		IdleActions.Add(new PistolIdleAction(contexts));
		FrameActions.Add(new RevolverBattleFrameAction(contexts, revolverBattleLeftAction));
	}
}

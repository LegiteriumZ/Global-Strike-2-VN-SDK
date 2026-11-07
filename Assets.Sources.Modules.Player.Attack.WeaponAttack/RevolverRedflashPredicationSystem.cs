using System;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJBase.Logger;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class RevolverRedflashPredicationSystem : AbstractAttackPredicationSystem
{
	internal class RevolverRedflashLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public RevolverRedflashLeftAction(Contexts contexts)
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
			if (base.CanFire(ref arg) && arg.CurrentWeapon.basicInfo.Data.ShotsFired < 1 && !arg.CurrentWeapon.special.SpecialMode)
			{
				return arg.CurrentWeapon.power.Power == 0;
			}
			return false;
		}
	}

	internal class RevolverRedflashFrameAction : AbstractFireAction, IFrameCmdAction, ICmdAction
	{
		public RevolverRedflashFrameAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(BusrtRemainingFire);
			AddFire(XuliFireQkhhAfterFire);
		}

		public static int XuliFireQkhhAfterFire(ref CommonWeaponArg arg)
		{
			if (arg.Player.hasFirstPersonUnityObjects && !arg.Player.fov.IsZoom() && !arg.Cmd.PredicatedOnce)
			{
				WeaponUtility.AllFire(arg.Player.firstPersonUnityObjects.RightFires, arg.CurrentWeapon.special.SpecialMode);
			}
			return 0;
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (CanFire(ref arg))
			{
				OnFireFunc.Step(ref arg);
			}
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (arg.Cmd.IsSecondaryAttackOn && (float)arg.ClientTime > arg.CurrentWeapon.attack.NextAttackTimer && arg.CurrentWeapon.power.Power2 == 0 && RuleUtilty.IsGeneralPve(raceType) && arg.CurrentWeapon.basicInfo.Data.Clip > 0)
			{
				arg.CurrentWeapon.power.MaxPower2 += arg.Cmd.FrameInterval;
			}
			if (arg.CurrentWeapon.power.MaxPower2 > 500 && !arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.power.Power2 == 0)
			{
				arg.CurrentWeapon.special.SpecialMode = true;
				if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 64) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 149))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 64);
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 63);
				}
			}
			if (!arg.Cmd.IsSecondaryAttackOn)
			{
				if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.power.MaxPower2 >= arg.CurrentWeapon.power.RpgMaxPower + 500)
				{
					gofFireAction(arg.Player, arg.CurrentWeapon, arg.Cmd);
				}
				arg.CurrentWeapon.power.MaxPower2 = 0;
				arg.CurrentWeapon.special.SpecialMode = false;
			}
			if (arg.Cmd.IsSecondaryAttackOn && (float)arg.ClientTime > arg.CurrentWeapon.attack.NextAttackTimer + (float)arg.CurrentWeapon.basicInfo.Info.AttackInterval && arg.CurrentWeapon.power.Power2 == 1 && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 149) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 148))
			{
				gofFireAction(arg.Player, arg.CurrentWeapon, arg.Cmd);
				arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime;
			}
			if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 63) && !arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 13);
			}
			return true;
		}

		private void gofFireAction(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(player, 64) && !PlayerAnimationUtility.IsViewAnimEqual(player, 148) && !PlayerAnimationUtility.IsViewAnimEqual(player, 149) && currentWeapon.basicInfo.Data.Clip > 0)
			{
				IEntitsWeaponInfo info = currentWeapon.basicInfo.Info;
				if (info.SpreadLogic != null)
				{
					info.SpreadLogic.BeforeFire(out currentWeapon.spread.Spread, player, currentWeapon, cmd, isWeightlessness: true);
				}
				if (info.AccuracyLogic != null)
				{
					info.AccuracyLogic.BeforeFire(cmd.Seq, player, currentWeapon, player.clientTime.ClientTime);
				}
				PlayerAnimationUtility.SetViewAnimation(player, 149);
				currentWeapon.power.Power = Math.Min(currentWeapon.basicInfo.Data.Clip, 6);
			}
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.Power > 0 && (float)arg.ClientTime - arg.CurrentWeapon.attack.NextAttackTimer + (float)arg.CurrentWeapon.basicInfo.Info.AttackInterval + 355f > 125f)
			{
				return !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 149);
			}
			return false;
		}

		private int BusrtRemainingFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			this.DebugFormat("BusrtRemainingFire,{0},{1}", arg.ClientTime, arg.Cmd.Seq);
			WeaponUtility.DescClip(arg.CurrentWeapon);
			if (arg.CurrentWeapon.clip.Clip < 0)
			{
				arg.CurrentWeapon.clip.Clip = 0;
				arg.CurrentWeapon.power.Power = 0;
				return 0;
			}
			GunFire(ref arg, arg.Cmd.Seq + arg.CurrentWeapon.power.Power, shotDistance);
			FireUtility.PlayFireSound(ref arg);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + arg.CurrentWeapon.basicInfo.Info.AttackInterval + 355;
			arg.CurrentWeapon.power.Power--;
			if (arg.CurrentWeapon.power.Power == 0)
			{
				if (PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 148))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 16);
				}
				arg.CurrentWeapon.special.SpecialMode = false;
			}
			arg.Player.punchOrientation.PunchPitch += 0.3f;
			return 0;
		}
	}

	public RevolverRedflashPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		LeftActions.Add(new RevolverRedflashLeftAction(contexts));
		IdleActions.Add(new PistolIdleAction(contexts));
		FrameActions.Add(new RevolverRedflashFrameAction(contexts));
	}
}

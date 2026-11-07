using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class JudgeEyeRifle1PredicationSystem : AbstractAttackPredicationSystem
{
	internal class JudgeEyeRifleLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public JudgeEyeRifleLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(M4a1ProLeftAction.LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}
	}

	internal class JudgeEyeRifleFrameAction : IFrameCmdAction, ICmdAction
	{
		private int _baseAttackInterval = 100;

		private readonly Contexts contexts;

		public JudgeEyeRifleFrameAction(Contexts contexts)
		{
			this.contexts = contexts;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			showSkillAnim(ref arg);
			perConsumePowerAnim(ref arg);
			showGunLogic(ref arg);
			return true;
		}

		private void showSkillAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.power.MaxPower > 0 && (arg.Cmd.Buttons & 0x800) > 0 && arg.CurrentWeapon.hasBasicInfo && arg.ClientTime >= arg.CurrentWeapon.basicInfo.Data.NextSkillTimer && canChangeAnim(ref arg))
			{
				if (arg.CurrentWeapon.special.SpecialMode)
				{
					arg.CurrentWeapon.special.SpecialMode = false;
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
					int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
					arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
				}
				else if ((float)arg.ClientTime > arg.CurrentWeapon.attack.NextAttackTimer && checkTargetPlayer(ref arg))
				{
					arg.CurrentWeapon.special.SpecialMode = true;
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
					int viewAnimDuration2 = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
					arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration2;
					arg.CurrentWeapon.basicInfo.Data.WeaponTimer1 = (uint)(arg.ClientTime + 1000);
				}
			}
		}

		private bool checkTargetPlayer(ref CommonWeaponArg arg)
		{
			if (RuleUtilty.IsRpg((contexts.battleRoom != null) ? contexts.battleRoom.roomData.Data.RaceType : 0))
			{
				return UiIEventCondition.Get_tdSkillStateData_CurrentMp() >= (arg.CurrentWeapon.special.SpecialMode ? arg.CurrentWeapon.basicInfo.Data.Kill : arg.CurrentWeapon.power.RpgMaxPower);
			}
			return arg.CurrentWeapon.power.Power >= (arg.CurrentWeapon.special.SpecialMode ? arg.CurrentWeapon.basicInfo.Data.Kill : arg.CurrentWeapon.power.RpgMaxPower);
		}

		private void perConsumePowerAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode && arg.ClientTime > arg.CurrentWeapon.basicInfo.Data.WeaponTimer1)
			{
				arg.CurrentWeapon.basicInfo.Data.WeaponTimer1 = (uint)(arg.ClientTime + 1000);
				if (!checkTargetPlayer(ref arg))
				{
					arg.CurrentWeapon.special.SpecialMode = false;
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
					int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
					arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
				}
			}
		}

		private void showGunLogic(ref CommonWeaponArg arg)
		{
			if (!arg.Cmd.IsShowGun || !canChangeAnim(ref arg))
			{
				return;
			}
			if (!arg.CurrentWeapon.special.SpecialMode)
			{
				if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 44))
				{
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 44);
				}
			}
			else if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 117))
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 117);
			}
		}

		private bool canChangeAnim(ref CommonWeaponArg arg)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 36))
			{
				return !PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 37);
			}
			return false;
		}
	}

	public JudgeEyeRifle1PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new JudgeEyeRifleLeftAction(contexts));
		FrameActions.Add(new JudgeEyeRifleFrameAction(contexts));
	}
}

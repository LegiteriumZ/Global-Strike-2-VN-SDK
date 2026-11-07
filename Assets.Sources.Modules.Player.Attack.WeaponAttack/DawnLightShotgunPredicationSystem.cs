using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class DawnLightShotgunPredicationSystem : AbstractAttackPredicationSystem
{
	internal class DawnLightShotgunLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public DawnLightShotgunLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(ResetReload);
			AddFire(ShotGunFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		public int FireDescClip(ref CommonWeaponArg arg)
		{
			if (!arg.CurrentWeapon.special.SpecialMode)
			{
				WeaponUtility.DescClip(arg.CurrentWeapon);
			}
			return 0;
		}

		public int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			return 0;
		}

		private int ResetReload(ref CommonWeaponArg arg)
		{
			arg.CurrentWeapon.reload.ReloadEndTime = 0f;
			arg.CurrentWeapon.reload.IsStartReload = false;
			return 0;
		}

		private int ShotGunFire(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.PredicatedOnce)
			{
				return 0;
			}
			float shotDistance = arg.CurrentWeapon.basicInfo.Info.ShotDistanceLogic.GetShotDistance(arg.Cmd, arg.CurrentWeapon, isMelee: false);
			int seq = arg.Cmd.Seq;
			if (arg.CurrentWeapon.basicInfo.Info is IMutilFireBullets)
			{
				int fireBullets = (arg.CurrentWeapon.basicInfo.Info as IMutilFireBullets).FireBullets;
				for (int i = 0; i < fireBullets; i++)
				{
					GunFire(ref arg, seq + i, shotDistance);
				}
			}
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				if (WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime))
				{
					if ((arg.CurrentWeapon.special.EffectLevel & 2) > 0)
					{
						FireUtility.PlayFire3Sound(ref arg);
					}
					arg.CurrentWeapon.attack.NextAttackTimer = (uint)(arg.ClientTime + 100);
				}
				return false;
			}
			return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
		}
	}

	internal class DawnLightShotgunRightAction : RifleMeleeRightAction
	{
		public DawnLightShotgunRightAction(Contexts contexts)
			: base(contexts)
		{
		}

		protected override int SetAttackAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 72);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 72);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 20);
				PlayerAnimationUtility.SetTorseAnimation(arg.Player, 20);
			}
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if ((arg.CurrentWeapon.special.EffectLevel & 2) <= 0)
			{
				if (arg.CurrentWeapon.basicInfo.Info is IRifleMeleeWeaponInfo)
				{
					return WeaponUtility.CanSecondaryAttack(ref arg);
				}
				return false;
			}
			return false;
		}
	}

	internal class DawnLightShotgunFrameAction : AbstractFrameAction
	{
		private readonly MessageContext _messageContext;

		public DawnLightShotgunFrameAction(Contexts contexts)
			: base(contexts)
		{
			_messageContext = contexts.message;
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if ((arg.CurrentWeapon.special.EffectLevel & 2) > 0)
			{
				FireUtility.RightFireQkhhAfterFire(ref arg);
				if (!arg.Player.viewAnim.Equals(40))
				{
					PlayerAnimationUtility.SetTorseAnimation(arg.Player, 40);
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
				}
			}
			if (arg.CurrentWeapon.power.Power2 == 0 && arg.Cmd.IsAttackOn && arg.CurrentWeapon.basicInfo.Data.Kill == 0 && UiIEventCondition.Get_uiRoomData_GameRule().IsGeneralPve())
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("EV_NOENERGY"));
				NotifyManager.ForceInvoke(38);
			}
			return true;
		}
	}

	public DawnLightShotgunPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new PistolIdleAction(contexts));
		LeftActions.Add(new DawnLightShotgunLeftAction(contexts));
		RightActions.Add(new DawnLightShotgunRightAction(contexts));
		FrameActions.Add(new DawnLightShotgunFrameAction(contexts));
	}
}

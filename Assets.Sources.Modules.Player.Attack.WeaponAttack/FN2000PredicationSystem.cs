using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class FN2000PredicationSystem : AbstractAttackPredicationSystem
{
	internal class FN2000LeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public FN2000LeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(FireUtility.LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		public override bool Action(ref CommonWeaponArg arg)
		{
			if (CanFire(ref arg))
			{
				if (arg.CurrentWeapon.special.SpecialMode)
				{
					int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 40);
					arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
					arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
					PlayerAnimationUtility.SetViewAnimation(arg.Player, 40);
					FireUtility.RightFireQkhhAfterFire(ref arg);
					FireUtility.PlayFire3Sound(ref arg);
				}
				else
				{
					OnFireFunc.Step(ref arg);
				}
			}
			return true;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.special.EffectLevel == 1)
			{
				return false;
			}
			return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
		}
	}

	internal class FN2000RightAction : IRightCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		public FN2000RightAction(Contexts contexts)
		{
			_messageContext = contexts.message;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.attack.NextSecondaryAttackTimer > (float)arg.ClientTime)
			{
				return false;
			}
			if (CanSwitchMode(arg.Player))
			{
				if (!arg.CurrentWeapon.special.SpecialMode)
				{
					if (arg.CurrentWeapon.special.EffectLevel == 1)
					{
						_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("NoGrenade"));
						NotifyManager.ForceInvoke(38);
					}
					else
					{
						NormalToSpecialModel(ref arg);
					}
				}
				else
				{
					SpecialToNormalModel(ref arg);
				}
			}
			return true;
		}

		private bool CanSwitchMode(PlayerEntity player)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46))
			{
				return !PlayerAnimationUtility.IsViewAnimEqual(player, 17);
			}
			return false;
		}

		private void NormalToSpecialModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = true;
		}

		private void SpecialToNormalModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = false;
		}
	}

	public FN2000PredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new FN2000LeftAction(contexts));
		RightActions.Add(new FN2000RightAction(contexts));
	}
}

using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

public class Mp7a1TacticPredicationSystem : AbstractAttackPredicationSystem
{
	private class Mp7a1TacticLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public Mp7a1TacticLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(SetFireAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		private static int SetFireAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, 29);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, (arg.CurrentWeapon.attack.ShotsFired > 3) ? 32 : 15);
			}
			PlayerAnimationUtility.SetTorseAnimation(arg.Player, 15);
			return 0;
		}

		protected override bool CanFire(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.attack.ShotsFired >= 1)
			{
				return false;
			}
			return WeaponUtility.CanFire(arg.CurrentWeapon, arg.ClientTime);
		}
	}

	private class Mp7a1TacticFrameAction : IFrameCmdAction, ICmdAction
	{
		private readonly Contexts _contexts;

		private readonly MessageContext _messageContext;

		public Mp7a1TacticFrameAction(Contexts contexts)
		{
			_contexts = contexts;
			_messageContext = contexts.message;
		}

		bool ICmdAction.Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsShowGun && CanChangeMode(arg.Player))
			{
				ChangeShoootMode(ref arg);
			}
			return true;
		}

		private bool CanChangeMode(PlayerEntity player)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46))
			{
				return !PlayerAnimationUtility.IsViewAnimEqual(player, 17);
			}
			return false;
		}

		private void ChangeShoootMode(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = !arg.CurrentWeapon.special.SpecialMode;
			if (arg.CurrentWeapon.special.SpecialMode)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("SemiAutomatic"));
				NotifyManager.ForceInvoke(38);
			}
			else
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("FullyAutomatic"));
				NotifyManager.ForceInvoke(38);
			}
		}
	}

	public Mp7a1TacticPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new Mp7a1TacticLeftAction(contexts));
		FrameActions.Add(new Mp7a1TacticFrameAction(contexts));
	}
}

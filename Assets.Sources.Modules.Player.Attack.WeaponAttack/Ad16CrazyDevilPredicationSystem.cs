using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Modules.Player.Attack.Utils;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class Ad16CrazyDevilPredicationSystem : AbstractAttackPredicationSystem
{
	internal class Ad16CrazyDevilLeftAction : AbstractFireAction, ILeftCmdAction, ICmdAction
	{
		public Ad16CrazyDevilLeftAction(Contexts contexts)
			: base(contexts)
		{
			AddAction(HitUtility.BulletHiPlayerAction);
			AddAction(HitUtility.BulletHitWorldAction);
			AddFire(FireUtility.FireSetSpread);
			AddFire(FireUtility.RifleFireIncShotsFired);
			AddFire(FireUtility.FireSetAccuracy);
			AddFire(FireUtility.FireDescClip);
			AddFire(LeftFireSetAnim);
			AddFire(FireUtility.FireNextAttack);
			AddFire(OnFire);
			AddFire(FireUtility.RifleAfterFire);
			AddFire(FireUtility.RightFireQkhhAfterFire);
			AddFire(FireUtility.PlayFireSound);
		}

		private static int LeftFireSetAnim(ref CommonWeaponArg arg)
		{
			if (arg.CurrentWeapon.special.EffectLevel == 1)
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, (arg.CurrentWeapon.attack.ShotsFired > 3) ? 41 : 40);
			}
			else
			{
				PlayerAnimationUtility.SetViewAnimation(arg.Player, (arg.CurrentWeapon.attack.ShotsFired > 3) ? 32 : 15);
			}
			return 0;
		}
	}

	internal class Ad16CrazyDevilFrameAcions : IFrameCmdAction, ICmdAction
	{
		public Ad16CrazyDevilFrameAcions(Contexts contexts)
		{
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (arg.Cmd.IsSecondaryAttackOn)
			{
				arg.CurrentWeapon.attack.NextSecondaryAttackTimer += arg.ClientTime - arg.CurrentWeapon.basicInfo.Data.NextSkillTimer;
			}
			if (!arg.Cmd.IsSecondaryAttackOn || arg.CurrentWeapon.attack.ShotsFired < 3)
			{
				if (arg.CurrentWeapon.special.SpecialMode && CanChangeAnim(arg.Player))
				{
					SpecialToNormalModel(arg.Player, arg.CurrentWeapon, arg.ClientTime);
				}
				ClearState(arg.CurrentWeapon);
				if ((PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 39) || PlayerAnimationUtility.IsViewAnimEqual(arg.Player, 48)) && !arg.CurrentWeapon.special.SpecialMode)
				{
					SpecialToNormalModel(arg.Player, arg.CurrentWeapon, arg.ClientTime);
				}
			}
			if (arg.CurrentWeapon.attack.ShotsFired >= 3 && !arg.CurrentWeapon.special.SpecialMode && arg.CurrentWeapon.attack.NextSecondaryAttackTimer > 0f)
			{
				arg.CurrentWeapon.special.SpecialMode = true;
				arg.CurrentWeapon.special.EffectLevel = 1;
				NormalToSpecialModel(arg.Player, arg.CurrentWeapon, arg.ClientTime);
			}
			arg.CurrentWeapon.basicInfo.Data.NextSkillTimer = (uint)arg.ClientTime;
			return true;
		}

		private void ClearState(WeaponEntity currentWeapon)
		{
			currentWeapon.attack.NextSecondaryAttackTimer = 0f;
			currentWeapon.special.SpecialMode = false;
			currentWeapon.special.EffectLevel = 0;
		}

		private bool CanChangeAnim(PlayerEntity player)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46))
			{
				return !PlayerAnimationUtility.IsViewAnimEqual(player, 17);
			}
			return false;
		}

		public void NormalToSpecialModel(PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 36);
			currentWeapon.attack.NextSecondaryAttackTimer = clientTime + viewAnimDuration;
		}

		public void SpecialToNormalModel(PlayerEntity player, WeaponEntity currentWeapon, int clientTime)
		{
			PlayerAnimationUtility.SetViewAnimation(player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 37);
			currentWeapon.attack.NextAttackTimer = clientTime + viewAnimDuration;
			currentWeapon.attack.NextSecondaryAttackTimer = clientTime + viewAnimDuration;
		}
	}

	public Ad16CrazyDevilPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new Ad16CrazyDevilLeftAction(contexts));
		FrameActions.Add(new Ad16CrazyDevilFrameAcions(contexts));
	}
}

using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class PhaseWalkerReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public PhaseWalkerReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (!currentWeapon.reload.IsStartReload && currentWeapon.clip.CarryClip != 0 && currentWeapon.clip.Clip < currentWeapon.clip.MaxClip && !PlayerAnimationUtility.IsViewAnimEqual(player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(player, 18) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37))
		{
			currentWeapon.reload.IsStartReload = true;
			player.fov.ResetFov();
			int animId = 17;
			if (currentWeapon.special.SpecialMode)
			{
				animId = 46;
			}
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, animId);
			viewAnimDuration += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 18);
			currentWeapon.reload.ReloadEndTime = player.clientTime.ClientTime + viewAnimDuration;
			currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
			if (!currentWeapon.special.SpecialMode)
			{
				PlayerAnimationUtility.SetTorseAnimation(player, animId);
			}
			PlayerAnimationUtility.SetViewAnimation(player, animId);
		}
	}
}

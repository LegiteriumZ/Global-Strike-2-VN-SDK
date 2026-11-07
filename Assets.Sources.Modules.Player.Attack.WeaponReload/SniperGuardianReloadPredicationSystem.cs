using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class SniperGuardianReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public SniperGuardianReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			CheckReloadLogic(player, cmd, currentWeaponEntity);
		}
	}

	private void CheckReloadLogic(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon)
	{
		if (cmd.IsReloadOn)
		{
			CheckReload(player, cmd, currentWeapon);
		}
		else if (CanReloadAnim(player) && currentWeapon.basicInfo.Data.Clip == 0 && currentWeapon.basicInfo.Data.CarryClip > 0 && (!player.fov.IsZoom() || LoadingProgressBar(currentWeapon)))
		{
			StartReload(player, cmd, currentWeapon);
		}
	}

	private bool LoadingProgressBar(WeaponEntity currentWeapon)
	{
		return currentWeapon.basicInfo.Data.Power == currentWeapon.basicInfo.Data.MaxPower;
	}

	private void CheckReload(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon)
	{
		if (cmd.IsReloadOn)
		{
			if ((float)player.clientTime.ClientTime >= currentWeapon.reload.ReloadEndTime)
			{
				currentWeapon.reload.IsStartReload = false;
				WeaponUtility.ReloadClipRight(currentWeapon);
				currentWeapon.basicInfo.Data.Power = 0;
			}
			else if (!CanReloadAnim(player))
			{
				currentWeapon.reload.IsStartReload = false;
				currentWeapon.reload.ReloadEndTime = 0f;
				currentWeapon.basicInfo.Data.Power = 0;
			}
		}
	}

	private void StartReload(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon)
	{
		if (cmd.IsReloadOn || currentWeapon.basicInfo.Data.CarryClip == 0 || currentWeapon.basicInfo.Data.Clip >= currentWeapon.clip.MaxClip || player.viewAnim.Equals(17) || player.viewAnim.Equals(18))
		{
			return;
		}
		currentWeapon.reload.IsStartReload = true;
		if (!LoadingProgressBar(currentWeapon))
		{
			ResetFov(player);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 17);
			currentWeapon.reload.ReloadEndTime = player.clientTime.ClientTime + viewAnimDuration;
			currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
			currentWeapon.attack.NextSecondaryAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
			PlayerAnimationUtility.SetViewAnimation(player, 17);
			if (PlayerAnimationUtility.IsTorseAnimationExist(player, 17))
			{
				PlayerAnimationUtility.SetTorseAnimation(player, 17);
			}
		}
		WeaponUtility.Depoly(currentWeapon);
	}

	private void ResetFov(PlayerEntity player)
	{
		player.fov.Fov = 90;
		player.fov.LastFov = 90;
		player.fov.ResumeZoom = false;
	}
}

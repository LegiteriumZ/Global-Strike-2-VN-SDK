using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class ShotGunReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	public ShotGunReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
		_weaponContext = contexts.weapon;
	}

	protected override void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		if (cmd.IsReloadOn && WeaponUtility.CanReload(currentWeaponEntity))
		{
			SetReloadAnim(player, currentWeaponEntity);
		}
		if (CanReloadAnim(player) && !currentWeaponEntity.reload.IsStartReload && currentWeaponEntity.clip.Clip == 0 && currentWeaponEntity.clip.CarryClip > 0)
		{
			SetReloadAnim(player, currentWeaponEntity);
		}
		if (currentWeaponEntity.reload.IsStartReload)
		{
			if (currentWeaponEntity.reload.ReloadEndTime <= (float)player.clientTime.ClientTime)
			{
				currentWeaponEntity.reload.IsStartReload = false;
				ReloadClip(player, currentWeaponEntity);
			}
			else if (!CanReloadAnim(player))
			{
				currentWeaponEntity.reload.IsStartReload = false;
				currentWeaponEntity.reload.ReloadEndTime = 0f;
			}
		}
	}

	private void ReloadClip(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.clip.Clip < currentWeapon.basicInfo.Info.MaxClip && currentWeapon.clip.CarryClip > 0)
		{
			currentWeapon.clip.Clip++;
			currentWeapon.clip.CarryClip--;
		}
		if (currentWeapon.clip.Clip < currentWeapon.basicInfo.Info.MaxClip && currentWeapon.clip.CarryClip > 0)
		{
			PlayerAnimationUtility.SetTorseAnimation(player, 17);
			PlayerAnimationUtility.SetViewAnimation(player, 34);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 34);
			currentWeapon.reload.IsStartReload = true;
			currentWeapon.reload.ReloadEndTime = player.clientTime.ClientTime + viewAnimDuration;
		}
		else
		{
			PlayerAnimationUtility.SetViewAnimation(player, 35);
		}
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		int stateId = player.viewAnim.ViewAnimInfo.StateId;
		if (stateId != 20 && stateId != 31 && stateId != 30)
		{
			return true;
		}
		return false;
	}

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		player.fov.ResetFov();
		int clientTime = player.clientTime.ClientTime;
		clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 33);
		if (PlayerAnimationUtility.IsViewAnimExist(currentWeapon.basicInfo.Info, 18))
		{
			clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 34);
		}
		currentWeapon.reload.IsStartReload = true;
		currentWeapon.attack.NextAttackTimer = clientTime;
		currentWeapon.reload.ReloadEndTime = clientTime;
		currentWeapon.attack.NextSecondaryAttackTimer = clientTime;
		PlayerAnimationUtility.SetViewAnimation(player, 33);
		if (PlayerAnimationUtility.IsTorseAnimationExist(player, 17))
		{
			PlayerAnimationUtility.SetTorseAnimation(player, 17);
		}
	}
}

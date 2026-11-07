using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class M4A1ProReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public M4A1ProReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		if (cmd.IsReloadOn && CanReload(currentWeaponEntity) && CanReloadAnim(player))
		{
			SetReloadAnim(player, currentWeaponEntity);
		}
		if (CanReloadAnim(player) && !currentWeaponEntity.reload.IsStartReload && currentWeaponEntity.clip.Clip == 0 && currentWeaponEntity.clip.CarryClip > 0)
		{
			SetReloadAnim(player, currentWeaponEntity);
		}
		if (currentWeaponEntity.reload.IsStartReload)
		{
			if (CanReload(currentWeaponEntity))
			{
				currentWeaponEntity.reload.IsStartReload = false;
				currentWeaponEntity.reload.ReloadEndTime = 0f;
			}
			if (currentWeaponEntity.reload.ReloadEndTime < (float)player.clientTime.ClientTime)
			{
				currentWeaponEntity.reload.IsStartReload = false;
				currentWeaponEntity.reload.ReloadEndTime = 0f;
				WeaponUtility.ReloadClipRight(currentWeaponEntity);
			}
		}
	}

	private bool CanReload(WeaponEntity weapon)
	{
		if (!weapon.reload.IsStartReload && weapon.clip.CarryClip > 0)
		{
			return weapon.clip.Clip < weapon.clip.MaxClip;
		}
		return false;
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		if (!PlayerAnimationUtility.IsViewAnimEqual(player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37))
		{
			return !PlayerAnimationUtility.IsViewAnimEqual(player, 18);
		}
		return false;
	}
}

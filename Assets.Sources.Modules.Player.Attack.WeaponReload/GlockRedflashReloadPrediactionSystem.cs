using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class GlockRedflashReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public GlockRedflashReloadPrediactionSystem(Contexts contexts)
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

	public bool CanReload(WeaponEntity weapon)
	{
		int num = weapon.special.EffectLevel switch
		{
			2 => 33, 
			4 => 17, 
			_ => weapon.basicInfo.Info.MaxClip, 
		};
		if (!weapon.reload.IsStartReload && weapon.clip.CarryClip > 0)
		{
			return weapon.clip.Clip < num;
		}
		return false;
	}
}

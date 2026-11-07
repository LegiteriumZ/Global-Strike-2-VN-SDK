using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class Ak47UniqueReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public Ak47UniqueReloadPredicationSystem(Contexts contexts)
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
		bool specialMode = Contexts.sharedInstance.weapon.currentWeaponEntity.special.SpecialMode;
		int stateId = player.viewAnim.ViewAnimInfo.StateId;
		if (!specialMode && stateId != 15 && stateId != 32 && stateId != 20)
		{
			return true;
		}
		if (specialMode && stateId != 40 && stateId != 72)
		{
			return true;
		}
		return false;
	}
}

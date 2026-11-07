using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class Cz75ReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	public Cz75ReloadPrediactionSystem(Contexts contexts)
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
		if (cmd.IsReloadOn && !cmd.IsAttackOn && WeaponUtility.CanReload(currentWeaponEntity))
		{
			SetReloadAnim(player, currentWeaponEntity);
		}
		if (CanReloadAnim(player) && !currentWeaponEntity.reload.IsStartReload && currentWeaponEntity.clip.Clip == 0 && currentWeaponEntity.clip.CarryClip > 0)
		{
			SetReloadAnim(player, currentWeaponEntity);
		}
		if (currentWeaponEntity.reload.IsStartReload)
		{
			if (WeaponUtility.CanReload(currentWeaponEntity))
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

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		int stateId = player.viewAnim.ViewAnimInfo.StateId;
		if (stateId != 20 && stateId != 31 && stateId != 36 && stateId != 30)
		{
			return true;
		}
		return false;
	}

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		player.fov.ResetFov();
		int clientTime = player.clientTime.ClientTime;
		int animId = 36;
		if (currentWeapon.special.SpecialMode)
		{
			animId = 46;
		}
		else
		{
			currentWeapon.special.SpecialMode = true;
		}
		clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, animId);
		clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 18);
		currentWeapon.reload.IsStartReload = true;
		currentWeapon.attack.NextAttackTimer = clientTime;
		currentWeapon.reload.ReloadEndTime = clientTime;
		currentWeapon.attack.NextSecondaryAttackTimer = clientTime;
		WeaponUtility.Depoly(currentWeapon);
		PlayerAnimationUtility.SetViewAnimation(player, animId);
		if (PlayerAnimationUtility.IsTorseAnimationExist(player, 17))
		{
			PlayerAnimationUtility.SetTorseAnimation(player, 17);
		}
	}
}

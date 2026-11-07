using Assets.Sources.Framework;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class AbstractReloadPrediactionSystem : IPredicateSystem
{
	protected readonly WeaponContext WeaponContext;

	public AbstractReloadPrediactionSystem(Contexts contexts)
	{
		WeaponContext = contexts.weapon;
	}

	public virtual void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		PredictCmdOnWeapon(myPlayer, cmd);
	}

	protected virtual void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		if (cmd.IsReloadOn && WeaponUtility.CanReload(currentWeaponEntity) && CanReloadAnim(player))
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

	protected virtual bool CanReloadAnim(PlayerEntity player)
	{
		int stateId = player.viewAnim.ViewAnimInfo.StateId;
		if (stateId != 20 && stateId != 31 && stateId != 30 && stateId != 169 && stateId != 171 && stateId != 173 && stateId != 175 && stateId != 170 && stateId != 172 && stateId != 174 && stateId != 176 && stateId != 122 && stateId != 124 && stateId != 126)
		{
			return true;
		}
		return false;
	}

	protected virtual void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon, int hand)
	{
	}

	protected virtual void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		player.fov.ResetFov();
		int clientTime = player.clientTime.ClientTime;
		int animId = 17;
		if (currentWeapon.special.SpecialMode)
		{
			if (PlayerAnimationUtility.IsViewAnimExist(currentWeapon.basicInfo.Info, 46))
			{
				animId = 46;
			}
			else if (PlayerAnimationUtility.IsViewAnimExist(currentWeapon.basicInfo.Info, 38))
			{
				animId = 38;
			}
		}
		clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, animId);
		if (PlayerAnimationUtility.IsViewAnimExist(currentWeapon.basicInfo.Info, 18))
		{
			clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 18);
		}
		currentWeapon.reload.IsStartReload = true;
		currentWeapon.attack.NextAttackTimer = clientTime;
		currentWeapon.reload.ReloadEndTime = clientTime;
		PlayerAnimationUtility.SetViewAnimation(player, animId);
		if (PlayerAnimationUtility.IsTorseAnimationExist(player, 17))
		{
			PlayerAnimationUtility.SetTorseAnimation(player, 17);
		}
		WeaponUtility.Depoly(currentWeapon);
	}
}

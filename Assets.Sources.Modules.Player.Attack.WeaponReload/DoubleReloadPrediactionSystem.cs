using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class DoubleReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	private const int Left = 1;

	private const int Right = 0;

	private readonly WeaponContext _weaponContext;

	public DoubleReloadPrediactionSystem(Contexts contexts)
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
			SetReloadAnim(player, currentWeaponEntity, 1);
			SetReloadAnim(player, currentWeaponEntity, 0);
		}
		if (CanReloadAnim(player) && !currentWeaponEntity.reload.IsStartReload && currentWeaponEntity.clip.Clip == 0 && currentWeaponEntity.clip.CarryClip > 0)
		{
			SetReloadAnim(player, currentWeaponEntity, 1);
		}
		if (!currentWeaponEntity.reload.IsStartReload2 && currentWeaponEntity.clip.Clip2 == 0 && currentWeaponEntity.clip.CarryClip2 > 0)
		{
			SetReloadAnim(player, currentWeaponEntity, 0);
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
				WeaponUtility.ReloadClipLeft(currentWeaponEntity);
			}
		}
		if (currentWeaponEntity.reload.IsStartReload2 && currentWeaponEntity.reload.ReloadEndTime2 < (float)player.clientTime.ClientTime)
		{
			currentWeaponEntity.reload.IsStartReload2 = false;
			currentWeaponEntity.reload.ReloadEndTime2 = 0f;
			WeaponUtility.ReloadClipRight(currentWeaponEntity);
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

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon, int hand)
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
		if (1 == hand)
		{
			currentWeapon.reload.IsStartReload = true;
			currentWeapon.attack.NextAttackTimer = clientTime;
			currentWeapon.reload.ReloadEndTime = clientTime;
			PlayerAnimationUtility.SetViewAnimation(player, animId);
			if (PlayerAnimationUtility.IsTorseAnimationExist(player, 17))
			{
				PlayerAnimationUtility.SetTorseAnimation(player, 17);
			}
		}
		else
		{
			currentWeapon.reload.IsStartReload2 = true;
			currentWeapon.attack.NextSecondaryAttackTimer = clientTime;
			currentWeapon.reload.ReloadEndTime2 = clientTime;
			PlayerAnimationUtility.SetLeftViewAnimation(player, animId);
			if (PlayerAnimationUtility.IsTorseAnimationExist(player, 17))
			{
				PlayerAnimationUtility.SetTorseAnimation(player, 17);
			}
		}
	}
}

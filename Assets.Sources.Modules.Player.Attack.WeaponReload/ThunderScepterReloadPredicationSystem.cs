using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class ThunderScepterReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public ThunderScepterReloadPredicationSystem(Contexts contexts)
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
		else if (currentWeapon.basicInfo.Data.Clip == 0 && currentWeapon.basicInfo.Data.CarryClip > 0)
		{
			if (currentWeapon.basicInfo.Data.NextSkillTimer == 0L)
			{
				currentWeapon.basicInfo.Data.NextSkillTimer = (uint)(player.clientTime.ClientTime + 800);
			}
			else if (player.clientTime.ClientTime > currentWeapon.basicInfo.Data.NextSkillTimer && CanReloadAnim(player))
			{
				currentWeapon.basicInfo.Data.NextSkillTimer = 0L;
				StartReload(player, cmd, currentWeapon);
			}
		}
		else
		{
			currentWeapon.basicInfo.Data.NextSkillTimer = 0L;
		}
	}

	private void CheckReload(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon)
	{
		if (cmd.IsReloadOn)
		{
			if ((float)player.clientTime.ClientTime >= currentWeapon.reload.ReloadEndTime)
			{
				currentWeapon.reload.IsStartReload = false;
				WeaponUtility.ReloadClipRight(currentWeapon);
			}
			else if (!CanReloadAnim(player))
			{
				currentWeapon.reload.IsStartReload = false;
				currentWeapon.reload.ReloadEndTime = 0f;
			}
		}
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		int stateId = player.viewAnim.ViewAnimInfo.StateId;
		if (stateId != 20 && stateId != 31 && stateId != 30 && stateId != 169 && stateId != 171 && stateId != 173 && stateId != 175 && stateId != 170 && stateId != 172 && stateId != 174 && stateId != 176 && stateId != 122 && stateId != 124 && stateId != 126 && stateId != 64 && stateId != 63 && stateId != 65 && stateId != 15)
		{
			return true;
		}
		return false;
	}

	private void StartReload(PlayerEntity player, IUserCmd cmd, WeaponEntity currentWeapon)
	{
		if (!cmd.IsReloadOn && currentWeapon.basicInfo.Data.CarryClip != 0 && currentWeapon.basicInfo.Data.Clip < currentWeapon.clip.MaxClip && !player.viewAnim.Equals(17) && !player.viewAnim.Equals(18))
		{
			currentWeapon.reload.IsStartReload = true;
			player.fov.ResetFov();
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 17);
			currentWeapon.reload.ReloadEndTime = player.clientTime.ClientTime + viewAnimDuration;
			currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
			currentWeapon.attack.NextSecondaryAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
			PlayerAnimationUtility.SetViewAnimation(player, 17);
			if (PlayerAnimationUtility.IsTorseAnimationExist(player, 17))
			{
				PlayerAnimationUtility.SetTorseAnimation(player, 17);
			}
			WeaponUtility.Depoly(currentWeapon);
		}
	}
}

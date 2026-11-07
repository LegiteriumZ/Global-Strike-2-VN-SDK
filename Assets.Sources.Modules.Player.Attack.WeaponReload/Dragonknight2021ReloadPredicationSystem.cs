using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class Dragonknight2021ReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public Dragonknight2021ReloadPredicationSystem(Contexts contexts)
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
		if (stateId != 15 && stateId != 32 && stateId != 20)
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
			int num = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 17) / currentWeapon.power.RpgMaxPower;
			num += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 18);
			currentWeapon.reload.ReloadEndTime = player.clientTime.ClientTime + num;
			currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + num;
			currentWeapon.attack.NextSecondaryAttackTimer = player.clientTime.ClientTime + num;
			player.viewAnim.RightSpeed = currentWeapon.power.RpgMaxPower;
			PlayerAnimationUtility.SetViewAnimation(player, 17);
			if (PlayerAnimationUtility.IsTorseAnimationExist(player, 17))
			{
				PlayerAnimationUtility.SetTorseAnimation(player, 17);
			}
			WeaponUtility.Depoly(currentWeapon);
		}
	}
}

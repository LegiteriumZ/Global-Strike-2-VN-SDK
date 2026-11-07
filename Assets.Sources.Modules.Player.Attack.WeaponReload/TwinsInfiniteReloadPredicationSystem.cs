using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class TwinsInfiniteReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public TwinsInfiniteReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void PredictCmdOnWeapon(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			if (cmd.IsReloadOn)
			{
				StartReload(currentWeaponEntity, player);
			}
			CheckReloadEndLogic(player, currentWeaponEntity);
			CheckAutoReloadLogic(player, currentWeaponEntity);
		}
	}

	private void CheckAutoReloadLogic(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (TwinsInfinitePredicationSystem.isLeftAttack(currentWeapon) && RightNoClip(currentWeapon) && NeedAutoReload(currentWeapon, left: true))
		{
			StartReload(currentWeapon, player);
		}
		if (!TwinsInfinitePredicationSystem.isLeftAttack(currentWeapon) && leftNoClip(currentWeapon) && NeedAutoReload(currentWeapon, left: false))
		{
			StartReload(currentWeapon, player);
		}
	}

	private bool NeedAutoReload(WeaponEntity currentWeapon, bool left)
	{
		if (!left)
		{
			if (currentWeapon.clip.Clip2 == 0 && currentWeapon.clip.CarryClip2 != 0)
			{
				return true;
			}
		}
		else if (currentWeapon.clip.Clip == 0 && currentWeapon.clip.CarryClip != 0)
		{
			return true;
		}
		return false;
	}

	private bool leftNoClip(WeaponEntity currentWeapon)
	{
		if (currentWeapon.clip.Clip == 0)
		{
			return currentWeapon.clip.CarryClip == 0;
		}
		return false;
	}

	private bool RightNoClip(WeaponEntity currentWeapon)
	{
		if (currentWeapon.clip.Clip2 == 0)
		{
			return currentWeapon.clip.CarryClip2 == 0;
		}
		return false;
	}

	private static void CheckReloadEndLogic(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.reload.IsStartReload)
		{
			if (!CanReload(currentWeapon, player))
			{
				currentWeapon.reload.IsStartReload = false;
				currentWeapon.reload.ReloadEndTime = 0f;
			}
			if (currentWeapon.reload.ReloadEndTime < (float)player.clientTime.ClientTime)
			{
				currentWeapon.reload.IsStartReload = false;
				currentWeapon.reload.ReloadEndTime = 0f;
				WeaponUtility.ReloadClipRight(currentWeapon);
			}
		}
		if (currentWeapon.reload.IsStartReload2)
		{
			if (!CanReload(currentWeapon, player))
			{
				currentWeapon.reload.IsStartReload = false;
				currentWeapon.reload.ReloadEndTime = 0f;
			}
			if (currentWeapon.reload.ReloadEndTime2 < (float)player.clientTime.ClientTime)
			{
				currentWeapon.reload.IsStartReload2 = false;
				currentWeapon.reload.ReloadEndTime2 = 0f;
				WeaponUtility.ReloadClipLeft(currentWeapon);
			}
		}
	}

	private static bool CanReload(WeaponEntity currentWeapon, PlayerEntity player)
	{
		if (player.viewAnim.Equals(15) || player.viewAnim.Equals(40) || player.viewAnim.Equals(20) || player.viewAnim.Equals(72) || player.viewAnim.Equals(28) || player.viewAnim.Equals(96))
		{
			return false;
		}
		return true;
	}

	private void StartReload(WeaponEntity currentWeapon, PlayerEntity player)
	{
		if ((!currentWeapon.reload.IsStartReload2 || !currentWeapon.reload.IsStartReload) && IsClipNeedToReload(currentWeapon) && !player.viewAnim.Equals(TwinsInfinitePredicationSystem.LEFT_RELOAD_ANIM) && !player.viewAnim.Equals(TwinsInfinitePredicationSystem.RIGHT_RELOAD_ANIM))
		{
			currentWeapon.reload.IsStartReload = true;
			currentWeapon.reload.IsStartReload2 = true;
			int animId = (TwinsInfinitePredicationSystem.isLeftAttack(currentWeapon) ? TwinsInfinitePredicationSystem.LEFT_RELOAD_ANIM : TwinsInfinitePredicationSystem.RIGHT_RELOAD_ANIM);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, animId);
			viewAnimDuration += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 18);
			currentWeapon.reload.ReloadEndTime = player.clientTime.ClientTime + viewAnimDuration;
			currentWeapon.reload.ReloadEndTime2 = player.clientTime.ClientTime + viewAnimDuration;
			currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
			PlayerAnimationUtility.SetViewAnimation(player, animId);
		}
	}

	private bool IsClipNeedToReload(WeaponEntity currentWeapon)
	{
		if (!NeedReload(currentWeapon, left: true))
		{
			return NeedReload(currentWeapon, left: false);
		}
		return true;
	}

	private bool NeedReload(WeaponEntity currentWeapon, bool left)
	{
		if (left)
		{
			if (currentWeapon.clip.Clip2 < currentWeapon.clip.MaxClip && currentWeapon.clip.CarryClip2 != 0)
			{
				return true;
			}
		}
		else if (currentWeapon.clip.Clip < currentWeapon.clip.MaxClip && currentWeapon.clip.CarryClip != 0)
		{
			return true;
		}
		return false;
	}
}

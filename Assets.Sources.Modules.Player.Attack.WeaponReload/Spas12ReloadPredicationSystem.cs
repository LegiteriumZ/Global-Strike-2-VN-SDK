using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class Spas12ReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	public Spas12ReloadPredicationSystem(Contexts contexts)
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
		if (IsClipNotFull(currentWeapon) && currentWeapon.clip.CarryClip > 0)
		{
			if (currentWeapon.special.SpecialMode)
			{
				currentWeapon.clip.Clip++;
				currentWeapon.clip.CarryClip--;
			}
			else if (currentWeapon.attach.Data is Spas12Attach spas12Attach)
			{
				spas12Attach.ClipSum++;
			}
		}
		if (IsClipNotFull(currentWeapon) && currentWeapon.clip.CarryClip > 0)
		{
			Spas12Attach spas12Attach2 = currentWeapon.attach.Data as Spas12Attach;
			PlayerAnimationUtility.SetTorseAnimation(player, 17);
			PlayerAnimationUtility.SetViewAnimation(player, 34);
			int num = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 34);
			if (spas12Attach2 != null && spas12Attach2.ReloadCount >= 2)
			{
				num /= 2;
				player.viewAnim.RightSpeed = 2f;
			}
			currentWeapon.reload.IsStartReload = true;
			currentWeapon.reload.ReloadEndTime = player.clientTime.ClientTime + num;
			if (spas12Attach2 != null)
			{
				spas12Attach2.ReloadCount = 0;
			}
		}
		else
		{
			if (!currentWeapon.special.SpecialMode && currentWeapon.attach.Data is Spas12Attach spas12Attach3)
			{
				currentWeapon.clip.Clip += spas12Attach3.ClipSum;
				currentWeapon.clip.CarryClip -= spas12Attach3.ClipSum;
			}
			PlayerAnimationUtility.SetViewAnimation(player, 35);
		}
	}

	private bool IsClipNotFull(WeaponEntity currentWeapon)
	{
		if (currentWeapon.special.SpecialMode)
		{
			return currentWeapon.clip.Clip < currentWeapon.basicInfo.Info.MaxClip;
		}
		if (currentWeapon.attach.Data is Spas12Attach spas12Attach)
		{
			return spas12Attach.ClipSum + currentWeapon.clip.Clip < currentWeapon.basicInfo.Info.MaxClip;
		}
		return false;
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
		if (currentWeapon.attach.Data is Spas12Attach spas12Attach)
		{
			spas12Attach.ReloadCount = 0;
			spas12Attach.ClipSum = 0;
		}
	}
}

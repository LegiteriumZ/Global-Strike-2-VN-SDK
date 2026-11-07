using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class CorbettReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public CorbettReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	public int ShowButtonIcon(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (currentWeapon.reload.IsStartReload && !currentWeapon.special.SpecialMode && PlayerAnimationUtility.IsViewAnimEqual(player, 17) && player.basicInfo.Current.ViewAnimationTimer < 1300 && player.basicInfo.Current.ViewAnimationTimer > 300)
		{
			return 1;
		}
		return 0;
	}

	public override void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && cmd.IsReloadOn)
		{
			ForceReload(myPlayer, currentWeaponEntity, cmd);
		}
	}

	public void ForceReload(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if (ShowButtonIcon(player, currentWeapon) == 1)
		{
			ThrowClip(player, currentWeapon);
		}
		else if (!PlayerAnimationUtility.IsViewAnimEqual(player, 28))
		{
			PredictCmdOnWeapon(player, cmd);
		}
	}

	private void ThrowClip(PlayerEntity player, WeaponEntity currentWeapon)
	{
		currentWeapon.special.SpecialMode = true;
		currentWeapon.reload.IsStartReload = false;
		currentWeapon.clip.Clip = 0;
		PlayerAnimationUtility.SetViewAnimation(player, 28);
	}

	protected void ReloadClip(PlayerEntity player, WeaponEntity currentWeapon)
	{
		WeaponUtility.ReloadClipRight(currentWeapon);
		currentWeapon.special.SpecialMode = false;
	}

	protected new bool CanReloadAnim(PlayerEntity player)
	{
		if (!base.CanReloadAnim(player))
		{
			return false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(player, 28))
		{
			return true;
		}
		return false;
	}
}

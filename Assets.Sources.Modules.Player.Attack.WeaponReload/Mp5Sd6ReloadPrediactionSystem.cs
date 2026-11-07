using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class Mp5Sd6ReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public Mp5Sd6ReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		int stateId = player.viewAnim.ViewAnimInfo.StateId;
		if (stateId != 17 && stateId != 46)
		{
			return stateId != 18;
		}
		return false;
	}

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		player.fov.ResetFov();
		currentWeapon.reload.IsStartReload = true;
		currentWeapon.special.SpecialMode = !currentWeapon.special.SpecialMode;
		int clientTime = player.clientTime.ClientTime;
		int animId;
		if (currentWeapon.special.SpecialMode)
		{
			clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 46);
			animId = 46;
		}
		else
		{
			clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 17);
			animId = 17;
		}
		currentWeapon.attack.NextAttackTimer = clientTime;
		currentWeapon.reload.ReloadEndTime = clientTime;
		currentWeapon.attack.NextSecondaryAttackTimer = clientTime;
		WeaponUtility.Depoly(currentWeapon);
		PlayerAnimationUtility.SetViewAnimation(player, animId);
		PlayerAnimationUtility.SetTorseAnimation(player, 17);
	}
}

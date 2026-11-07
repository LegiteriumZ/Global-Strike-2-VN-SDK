using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class RiderDouGunReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public RiderDouGunReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		player.fov.ResetFov();
		int animId = 17;
		int clientTime = player.clientTime.ClientTime;
		if (currentWeapon.basicInfo.Data.EffectLevel == 1)
		{
			animId = 46;
		}
		clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, animId);
		currentWeapon.reload.IsStartReload = true;
		currentWeapon.attack.NextAttackTimer = clientTime;
		currentWeapon.reload.ReloadEndTime = clientTime;
		PlayerAnimationUtility.SetViewAnimation(player, animId);
		PlayerAnimationUtility.SetTorseAnimation(player, 17);
		WeaponUtility.Depoly(currentWeapon);
	}
}

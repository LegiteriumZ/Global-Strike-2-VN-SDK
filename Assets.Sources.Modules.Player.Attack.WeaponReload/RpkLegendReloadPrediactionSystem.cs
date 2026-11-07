using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJBase.Logger;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class RpkLegendReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	private static readonly int FAST_RELOAD_TIME = 15000;

	public RpkLegendReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		player.fov.ResetFov();
		int clientTime = player.clientTime.ClientTime;
		int animId = ((player.clientTime.ClientTime - currentWeapon.power.Power2 > FAST_RELOAD_TIME) ? 38 : 17);
		clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, animId);
		currentWeapon.reload.IsStartReload = true;
		currentWeapon.attack.NextAttackTimer = clientTime;
		currentWeapon.reload.ReloadEndTime = clientTime;
		PlayerAnimationUtility.SetViewAnimation(player, animId);
		PlayerAnimationUtility.SetTorseAnimation(player, 17);
		WeaponUtility.Depoly(currentWeapon);
		this.Info($"startReload:{clientTime}");
	}
}

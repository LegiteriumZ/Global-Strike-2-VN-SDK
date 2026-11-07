using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class Ak47StrikeReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public Ak47StrikeReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		player.fov.ResetFov();
		int clientTime = player.clientTime.ClientTime;
		int animId = 17;
		clientTime += (int)((float)PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, animId) / (1f + (float)currentWeapon.special.Kil * 1f / 100f));
		clientTime += (int)((float)PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 18) / (1f + (float)currentWeapon.special.Kil * 1f / 100f));
		currentWeapon.reload.IsStartReload = true;
		currentWeapon.attack.NextAttackTimer = clientTime;
		currentWeapon.reload.ReloadEndTime = clientTime;
		PlayerAnimationUtility.SetViewAnimation(player, animId);
		PlayerAnimationUtility.SetTorseAnimation(player, 17);
		player.viewAnim.RightSpeed = 1f + (float)currentWeapon.special.Kil * 1f / 100f;
	}
}

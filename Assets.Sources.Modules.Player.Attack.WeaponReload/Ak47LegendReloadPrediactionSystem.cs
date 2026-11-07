using Assets.Sources.Info.Weapon.Attach;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class Ak47LegendReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public Ak47LegendReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetReloadAnim(PlayerEntity player, WeaponEntity currentWeapon)
	{
		player.fov.ResetFov();
		Ak47LegendAttach ak47LegendAttach = currentWeapon.attach.Data as Ak47LegendAttach;
		int num = ((player.clientTime.ClientTime - ak47LegendAttach.LastFastReloadTime > Ak47LegendAttach.FastReloadTime) ? 38 : 17);
		if (num == 38 || currentWeapon.special.EffectLevel == 1)
		{
			currentWeapon.special.EffectLevel = 0;
			ak47LegendAttach.LastFastReloadTime = player.clientTime.ClientTime;
			num = 38;
		}
		int clientTime = player.clientTime.ClientTime;
		clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, num);
		clientTime += PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, 18);
		currentWeapon.reload.IsStartReload = true;
		currentWeapon.attack.NextAttackTimer = clientTime;
		currentWeapon.reload.ReloadEndTime = clientTime;
		PlayerAnimationUtility.SetViewAnimation(player, num);
		PlayerAnimationUtility.SetTorseAnimation(player, 17);
		WeaponUtility.Depoly(currentWeapon);
	}
}

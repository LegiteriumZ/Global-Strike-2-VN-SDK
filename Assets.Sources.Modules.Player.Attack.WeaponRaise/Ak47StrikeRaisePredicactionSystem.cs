using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class Ak47StrikeRaisePredicactionSystem : AbstractRaisePredicactionSystem
{
	public Ak47StrikeRaisePredicactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		return 16;
	}

	protected override void SetRaiseAnim(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		int raiseAdminId = GetRaiseAdminId(player, currentWeapon, cmd);
		if (WeaponUtility.HasLeftAnim(currentWeapon.basicInfo.Info))
		{
			PlayerAnimationUtility.SetLeftViewAnimation(player, raiseAdminId);
		}
		PlayerAnimationUtility.SetViewAnimation(player, raiseAdminId);
		PlayerAnimationUtility.SetTorseAnimation(player, raiseAdminId);
		float num = 1f + (float)currentWeapon.power.MaxPower2 * 1f / 100f;
		float rightSpeed = player.viewAnim.RightSpeed;
		if (num > rightSpeed)
		{
			player.viewAnim.RightSpeed = num;
		}
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, raiseAdminId);
		player.viewAnim.RemainTime = (int)((float)player.viewAnim.RemainTime / player.viewAnim.RightSpeed);
		viewAnimDuration = (int)((float)viewAnimDuration / player.viewAnim.RightSpeed);
		currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
		currentWeapon.attack.NextSecondaryAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
	}
}

using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class FeatherBowRaisePredicationSystem : AbstractRaisePredicactionSystem
{
	public FeatherBowRaisePredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if (!currentWeapon.special.SpecialMode)
		{
			return 16;
		}
		return 47;
	}

	protected override void RaiseAction(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		SetRaiseAnim(player, currentWeapon, lastWeapon, cmd);
		RightAfterRaisedLogic(player, currentWeapon, lastWeapon, cmd);
		if (WeaponUtility.HasLeftAnim(currentWeapon.basicInfo.Info))
		{
			LeftAfterRaised(player, currentWeapon, lastWeapon, cmd);
		}
	}

	private void RightAfterRaisedLogic(PlayerEntity player, WeaponEntity currentWeapon, WeaponEntity lastWeapon, IUserCmd cmd)
	{
		int raiseAdminId = GetRaiseAdminId(player, currentWeapon, cmd);
		setViewRaiseAnim(player, raiseAdminId, currentWeapon);
		float raiseSpeed = GetRaiseSpeed(player, currentWeapon, lastWeapon);
		player.viewAnim.RightSpeed = raiseSpeed;
		player.viewAnim.LeftSpeed = raiseSpeed;
		int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(currentWeapon.basicInfo.Info, raiseAdminId);
		viewAnimDuration = (int)((float)viewAnimDuration / raiseSpeed);
		currentWeapon.attack.NextAttackTimer = player.clientTime.ClientTime + viewAnimDuration;
		if (player.hasBasicInfo && !player.basicInfo.IsDead)
		{
			setTorsoRaiseAnim(player, raiseAdminId, currentWeapon);
		}
	}
}

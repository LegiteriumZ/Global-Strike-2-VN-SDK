using Assets.Sources.Utils.PlayerAnim;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponLock;

internal class M60LockPredicationSystem : AbstractLockPrediactionSystem
{
	public M60LockPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void SetLockAndDuck(PlayerEntity player, IUserCmd cmd)
	{
		bool flag = PlayerAnimationUtility.IsViewAnimEqual(player, 36) || PlayerAnimationUtility.IsViewAnimEqual(player, 37) || PlayerAnimationUtility.IsViewAnimEqual(player, 40) || PlayerAnimationUtility.IsViewAnimEqual(player, 46) || PlayerAnimationUtility.IsViewAnimEqual(player, 39) || PlayerAnimationUtility.IsViewAnimEqual(player, 41);
		player.SetWeaponLock(flag);
		player.SetWeaponCanDuck(!flag);
	}
}

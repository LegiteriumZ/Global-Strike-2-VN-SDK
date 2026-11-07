using Assets.Sources.Utils.PlayerAnim;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponLock;

internal class GatlingGLockPredicationSystem : AbstractLockPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	public GatlingGLockPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		_weaponContext = contexts.weapon;
	}

	protected override void SetLockAndDuck(PlayerEntity player, IUserCmd cmd)
	{
		player.SetWeaponLock(PlayerAnimationUtility.IsViewAnimEqual(player, 36) || PlayerAnimationUtility.IsViewAnimEqual(player, 37) || PlayerAnimationUtility.IsViewAnimEqual(player, 40) || PlayerAnimationUtility.IsViewAnimEqual(player, 46) || PlayerAnimationUtility.IsViewAnimEqual(player, 39) || PlayerAnimationUtility.IsViewAnimEqual(player, 41));
		player.SetWeaponCanDuck(b: true);
		if (_weaponContext.currentWeaponEntity.special.SpecialMode)
		{
			player.SetWeaponCanDuck(b: false);
		}
		else if (PlayerAnimationUtility.IsViewAnimEqual(player, 100) || PlayerAnimationUtility.IsViewAnimEqual(player, 99))
		{
			player.SetWeaponCanDuck(b: false);
		}
	}
}

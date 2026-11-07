using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class RevolverBattleReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	public RevolverBattleReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		_weaponContext = contexts.weapon;
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity.power.Power > 0 || currentWeaponEntity.special.Level == 1)
		{
			return false;
		}
		if (currentWeaponEntity.burstMode.BurstModeShotsFired > 0)
		{
			return false;
		}
		if (PlayerAnimationUtility.IsViewAnimEqual(player, 17) || PlayerAnimationUtility.IsViewAnimEqual(player, 18) || PlayerAnimationUtility.IsViewAnimEqual(player, 16))
		{
			return false;
		}
		return base.CanReloadAnim(player);
	}
}

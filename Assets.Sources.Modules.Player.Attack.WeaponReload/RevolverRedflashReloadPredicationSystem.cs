using Assets.Sources.Utils.PlayerAnim;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class RevolverRedflashReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	public RevolverRedflashReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		_weaponContext = contexts.weapon;
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		if (_weaponContext.currentWeaponEntity.power.Power > 0 || PlayerAnimationUtility.IsViewAnimEqual(player, 16))
		{
			return false;
		}
		return base.CanReloadAnim(player);
	}
}

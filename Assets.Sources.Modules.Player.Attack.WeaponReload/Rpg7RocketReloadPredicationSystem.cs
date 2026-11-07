namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class Rpg7RocketReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	public Rpg7RocketReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
		_weaponContext = contexts.weapon;
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity.special.EffectLevel > 0)
		{
			return false;
		}
		if (base.CanReloadAnim(player))
		{
			return (float)player.clientTime.ClientTime > currentWeaponEntity.attack.NextAttackTimer;
		}
		return false;
	}
}

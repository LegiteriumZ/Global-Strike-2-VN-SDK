namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class SanDanHeroReloadPredictionSystem : AbstractReloadPrediactionSystem
{
	private readonly WeaponContext _weaponContext;

	public SanDanHeroReloadPredictionSystem(Contexts contexts)
		: base(contexts)
	{
		_weaponContext = contexts.weapon;
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		if (_weaponContext.currentWeaponEntity.special.SpecialMode)
		{
			return false;
		}
		return base.CanReloadAnim(player);
	}
}

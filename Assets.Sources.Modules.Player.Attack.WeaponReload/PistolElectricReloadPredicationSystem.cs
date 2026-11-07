namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class PistolElectricReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public PistolElectricReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		return false;
	}
}

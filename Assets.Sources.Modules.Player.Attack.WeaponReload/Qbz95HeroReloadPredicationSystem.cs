namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class Qbz95HeroReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public Qbz95HeroReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		if (!base.CanReloadAnim(player))
		{
			return false;
		}
		if (!player.viewAnim.Equals(64) && !player.viewAnim.Equals(65) && !player.viewAnim.Equals(63))
		{
			return true;
		}
		return false;
	}
}

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class GatlingGReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public GatlingGReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override bool CanReloadAnim(PlayerEntity player)
	{
		if (!base.CanReloadAnim(player))
		{
			return false;
		}
		int stateId = player.viewAnim.ViewAnimInfo.StateId;
		if (stateId != 36 && stateId != 37)
		{
			return true;
		}
		return false;
	}
}

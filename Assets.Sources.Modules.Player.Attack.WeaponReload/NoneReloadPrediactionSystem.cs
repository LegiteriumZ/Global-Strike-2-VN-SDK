using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class NoneReloadPrediactionSystem : AbstractReloadPrediactionSystem
{
	public NoneReloadPrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	public override void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
	}
}

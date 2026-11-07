using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class DefaultRaisePrediactionSystem : AbstractRaisePredicactionSystem
{
	public DefaultRaisePrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		return 16;
	}
}

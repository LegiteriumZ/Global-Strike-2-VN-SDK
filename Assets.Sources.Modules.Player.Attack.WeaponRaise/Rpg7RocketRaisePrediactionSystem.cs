using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class Rpg7RocketRaisePrediactionSystem : AbstractRaisePredicactionSystem
{
	public Rpg7RocketRaisePrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if (currentWeapon.power.Power != 0)
		{
			return 16;
		}
		return 47;
	}
}

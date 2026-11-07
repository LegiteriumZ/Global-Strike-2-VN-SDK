using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class UavRaisePredicactionSystem : AbstractRaisePredicactionSystem
{
	public UavRaisePredicactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if (currentWeapon.special.Level == 0)
		{
			return 16;
		}
		return 47;
	}
}

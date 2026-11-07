using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class VoidSpearRaisePredicationSystem : AbstractRaisePredicactionSystem
{
	public VoidSpearRaisePredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if (currentWeapon.special.SpecialMode)
		{
			return 47;
		}
		return 16;
	}
}

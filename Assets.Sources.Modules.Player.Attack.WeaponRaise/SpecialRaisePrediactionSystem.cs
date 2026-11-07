using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class SpecialRaisePrediactionSystem : AbstractRaisePredicactionSystem
{
	public SpecialRaisePrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if (!currentWeapon.special.SpecialMode)
		{
			return 16;
		}
		return 47;
	}
}

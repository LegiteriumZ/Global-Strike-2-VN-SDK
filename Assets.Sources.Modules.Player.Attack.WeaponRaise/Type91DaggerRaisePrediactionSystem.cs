using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class Type91DaggerRaisePrediactionSystem : AbstractRaisePredicactionSystem
{
	public Type91DaggerRaisePrediactionSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		if ((currentWeapon.basicInfo.Data.EffectLevel & 1) <= 0)
		{
			return 16;
		}
		return 47;
	}
}

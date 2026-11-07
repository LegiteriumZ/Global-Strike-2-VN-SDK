using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class M249MoonRaisePredicationSystem : AbstractRaisePredicactionSystem
{
	public M249MoonRaisePredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		return 16;
	}

	protected override float GetNextWeaponRaisedSpeed(PlayerEntity player, WeaponEntity currentWeaponEntity, WeaponEntity nextWeaponEntity)
	{
		if (nextWeaponEntity != null)
		{
			return 1f + (float)nextWeaponEntity.basicInfo.Data.Power * 0.01f;
		}
		return 1f;
	}
}

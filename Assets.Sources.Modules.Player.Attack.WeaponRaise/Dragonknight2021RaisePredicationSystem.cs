using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class Dragonknight2021RaisePredicationSystem : AbstractRaisePredicactionSystem
{
	public Dragonknight2021RaisePredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		return 16;
	}

	protected override float GetNextWeaponRaisedSpeed(PlayerEntity player, WeaponEntity currentWeaponEntity, WeaponEntity nextWeaponEntity)
	{
		if (nextWeaponEntity != null && nextWeaponEntity.hasBasicInfo && nextWeaponEntity.basicInfo.Data.WeaponName == "dragonknight2021" && (nextWeaponEntity.basicInfo.Data.EffectLevel & 1) > 0)
		{
			return 1.1f;
		}
		return 1f;
	}
}

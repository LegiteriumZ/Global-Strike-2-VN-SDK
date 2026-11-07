using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class ScarLegendRaisePredicationSystem : AbstractRaisePredicactionSystem
{
	public ScarLegendRaisePredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		return 16;
	}

	protected override float GetNextWeaponRaisedSpeed(PlayerEntity player, WeaponEntity currentWeaponEntity, WeaponEntity nextWeaponEntity)
	{
		if (nextWeaponEntity != null && nextWeaponEntity.hasBasicInfo && nextWeaponEntity.basicInfo.Data.WeaponName.StartsWith("scar_legend"))
		{
			return (float)nextWeaponEntity.basicInfo.Data.Power * 0.01f;
		}
		return 1f;
	}
}

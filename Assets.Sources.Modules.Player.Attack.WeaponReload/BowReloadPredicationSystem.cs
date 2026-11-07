using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponReload;

internal class BowReloadPredicationSystem : AbstractReloadPrediactionSystem
{
	public BowReloadPredicationSystem(Contexts contexts)
		: base(contexts)
	{
	}

	public override void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity.clip.Clip == 0 && currentWeaponEntity.clip.CarryClip > 0)
		{
			WeaponUtility.ReloadClipRight(currentWeaponEntity);
		}
	}
}

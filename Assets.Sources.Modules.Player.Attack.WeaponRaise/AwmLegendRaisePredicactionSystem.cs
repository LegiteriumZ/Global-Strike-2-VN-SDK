using Assets.Sources.Components.Weapon;
using Assets.Sources.Info.Weapon.Attach;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack.WeaponRaise;

internal class AwmLegendRaisePredicactionSystem : AbstractRaisePredicactionSystem
{
	private readonly Contexts _contexts;

	public AwmLegendRaisePredicactionSystem(Contexts contexts)
		: base(contexts)
	{
		_contexts = contexts;
	}

	protected override int GetRaiseAdminId(PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd)
	{
		return 16;
	}

	protected override float GetNextWeaponRaisedSpeed(PlayerEntity player, WeaponEntity currentWeaponEntity, WeaponEntity nextWeaponEntity)
	{
		if (currentWeaponEntity == null)
		{
			return 1f;
		}
		int index = 2;
		if (currentWeaponEntity.GetComponent(index) is AttachComponent { Data: AwmLegendAttach { isFire: not false } data })
		{
			data.isFire = false;
			return 1.3f;
		}
		return 1f;
	}
}

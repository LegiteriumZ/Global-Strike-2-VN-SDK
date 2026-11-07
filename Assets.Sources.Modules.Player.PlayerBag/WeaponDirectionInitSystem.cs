using Assets.Sources.Components.Weapon;
using NetData;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class WeaponDirectionInitSystem : WeaponInitSystemBase<DirectionComponent>
{
	public WeaponDirectionInitSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override DirectionComponent GetComponent(WeaponEntity entity)
	{
		return entity.direction;
	}

	protected override void InitComponent(DirectionComponent comp, BaseWeaponData data)
	{
		comp.Direction = data.Direction;
	}
}

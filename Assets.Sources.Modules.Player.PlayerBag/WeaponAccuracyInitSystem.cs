using Assets.Sources.Components.Weapon;
using NetData;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class WeaponAccuracyInitSystem : WeaponInitSystemBase<AccuracyComponent>
{
	public WeaponAccuracyInitSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override AccuracyComponent GetComponent(WeaponEntity entity)
	{
		return entity.accuracy;
	}

	protected override void InitComponent(AccuracyComponent comp, BaseWeaponData data)
	{
		comp.Accuracy = data.Accuracy;
	}
}

using Assets.Sources.Components.Weapon;
using NetData;

namespace Assets.Sources.Modules.Player.PlayerBag;

internal class WeaponPowerInitSystem : WeaponInitSystemBase<PowerComponent>
{
	public WeaponPowerInitSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override PowerComponent GetComponent(WeaponEntity entity)
	{
		return entity.power;
	}

	protected override void InitComponent(PowerComponent comp, BaseWeaponData data)
	{
		comp.Power = data.Power;
		comp.Power2 = data.Power2;
		comp.MaxPower = data.MaxPower;
		comp.MaxPower2 = data.MaxPower2;
		comp.RpgMaxPower = data.RpgMaxPower;
	}

	public override bool ShouldResetAll()
	{
		return false;
	}
}

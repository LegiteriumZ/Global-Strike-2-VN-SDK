using Assets.Sources.Components.Weapon;
using NetData;

namespace Assets.Sources.Modules.Player.PlayerBag;

internal class WeaponSpecialInitSystem : WeaponInitSystemBase<SpecialComponent>
{
	public WeaponSpecialInitSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override SpecialComponent GetComponent(WeaponEntity entity)
	{
		return entity.special;
	}

	protected override void InitComponent(SpecialComponent comp, BaseWeaponData data)
	{
		comp.SpecialMode = data.SpecialMode;
		comp.Durable = data.Durable;
		comp.Level = data.Level;
		comp.Permanent = data.Permanent;
		comp.Kil = data.Kill;
		comp.EffectLevel = data.EffectLevel;
	}

	public override bool ShouldResetAll()
	{
		return false;
	}
}

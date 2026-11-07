using Assets.Sources.Components.Weapon;
using NetData;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class WeaponAttackInitSystem : WeaponInitSystemBase<AttackComponent>
{
	public WeaponAttackInitSystem(Contexts contexts)
		: base(contexts)
	{
	}

	protected override AttackComponent GetComponent(WeaponEntity entity)
	{
		return entity.attack;
	}

	protected override void InitComponent(AttackComponent comp, BaseWeaponData data)
	{
		comp.NextAttackTimer = data.NextAttackTimer;
		comp.NextSecondaryAttackTimer = data.NextSecondaryAttackTimer;
		comp.DelayFire = data.DelayFire;
		comp.DecreaseShotsFired = data.DecreaseShotsFired;
		comp.ShotsFired = data.ShotsFired;
	}
}

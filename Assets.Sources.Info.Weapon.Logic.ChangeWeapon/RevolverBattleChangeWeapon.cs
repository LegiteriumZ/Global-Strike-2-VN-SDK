using Assets.Sources.Components.Interface.Info.Weapon.Logic;

namespace Assets.Sources.Info.Weapon.Logic.ChangeWeapon;

public class RevolverBattleChangeWeapon : IChangeWeapon
{
	public void EnterWeapon(WeaponEntity newentity)
	{
		newentity.special.EffectLevel &= -65;
		newentity.power.Power = 0;
		newentity.power.MaxPower2 = 0;
	}

	public void LeaveWeapon(WeaponEntity currentEntity)
	{
	}
}

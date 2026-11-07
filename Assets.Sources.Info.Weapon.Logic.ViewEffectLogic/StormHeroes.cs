namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class StormHeroes : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		GetSkins(player)["weaponeffect"].gameObject.SetObjectActive(currentWeapon.power.MaxPower == currentWeapon.power.Power);
	}
}

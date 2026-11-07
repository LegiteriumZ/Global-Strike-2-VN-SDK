namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class ElectricPistol : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "weaponeffect1", currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, "weaponeffect2", currentWeapon.special.SpecialMode);
	}
}

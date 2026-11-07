namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class ElectricElement : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "jihuo01", currentWeapon.special.EffectLevel > 0);
		SetParticleActiveParticleName(player, "jihuo", currentWeapon.special.EffectLevel > 0);
	}
}

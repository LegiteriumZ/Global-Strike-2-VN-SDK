namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class ElectricElement : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "jihuo01", player.GetCurrentWeaponEffectLevel() > 0);
		SetParticleActiveParticleName(player, "jihuo", player.GetCurrentWeaponEffectLevel() > 0);
	}
}

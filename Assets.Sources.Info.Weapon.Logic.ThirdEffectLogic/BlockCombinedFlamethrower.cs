namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class BlockCombinedFlamethrower : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "jimu_dianhuo_p1", flag: false);
		SetParticleActiveParticleName(player, "jimu_dianhuo", (player.GetCurrentWeaponEffectLevel() & 1) > 0);
		SetParticleActiveParticleName(player, "jimushangwei_qkhh", (player.GetCurrentWeaponEffectLevel() & 2) > 0);
	}
}

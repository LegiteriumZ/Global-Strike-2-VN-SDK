namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class RiderGrenade : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "fenglei_P3_qiangshen", player.GetCurrentWeaponEffectLevel() != 1);
		SetParticleActiveParticleName(player, "fenglei_P3_jinggao", player.GetCurrentWeaponEffectLevel() == 1);
		SetParticleActiveParticleName(player, "fenglei_P1_qiangshen", flag: false);
		SetParticleActiveParticleName(player, "fenglei_P1_jinggao", flag: false);
	}
}

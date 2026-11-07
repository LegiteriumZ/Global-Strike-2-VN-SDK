namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class RiderGrenade : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "fenglei_P1_qiangshen", player.GetCurrentWeaponEffectLevel() != 1);
		SetParticleActiveParticleName(player, "fenglei_P1_jinggao", player.GetCurrentWeaponEffectLevel() == 1);
		SetParticleActiveParticleName(player, "fenglei_P3_qiangshen", flag: false);
		SetParticleActiveParticleName(player, "fenglei_P3_jinggao", flag: false);
	}
}

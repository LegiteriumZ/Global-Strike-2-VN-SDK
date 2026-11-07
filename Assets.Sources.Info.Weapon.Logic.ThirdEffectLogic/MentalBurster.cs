namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class MentalBurster : AbstractThirdWeaponEffectLogic
{
	private string WEAPONEFFECT1 = "sanshe";

	private string WEAPONEFFECT2 = "shixuekuangchao";

	private string WEAPONEFFECT3 = "jihuo";

	private string WEAPONEFFECT4 = "qiangkouhuohua";

	private string WEAPONEFFECT5 = "sanshe_qiangkouhuohua";

	private string WEAPONEFFECT6 = "qiangshen_0";

	private string WEAPONEFFECT7 = "qiangshen_1";

	private string WEAPONEFFECT8 = "qiangshen";

	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		SetParticleActiveParticleName(player, WEAPONEFFECT8, flag: true);
		SetParticleActiveParticleName(player, WEAPONEFFECT7, flag: true);
		SetParticleActiveParticleName(player, WEAPONEFFECT6, flag: true);
		SetParticleActiveParticleName(player, WEAPONEFFECT1, (currentWeaponEffectLevel & 2) > 0);
		SetParticleActiveParticleName(player, WEAPONEFFECT2, (currentWeaponEffectLevel & 4) > 0);
		SetParticleActiveParticleName(player, WEAPONEFFECT3, (currentWeaponEffectLevel & 8) > 0);
		SetParticleActiveParticleName(player, WEAPONEFFECT4, (currentWeaponEffectLevel & 2) <= 0);
		SetParticleActiveParticleName(player, WEAPONEFFECT5, (currentWeaponEffectLevel & 2) > 0);
	}
}

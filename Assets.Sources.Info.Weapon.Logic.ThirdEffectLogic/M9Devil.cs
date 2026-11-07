namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class M9Devil : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "11000_fx_1_atf", flag: false);
		SetParticleActiveParticleName(player, "11000_daoguang01", flag: false);
		SetParticleActiveParticleName(player, "11000_daoguang02", flag: false);
	}
}

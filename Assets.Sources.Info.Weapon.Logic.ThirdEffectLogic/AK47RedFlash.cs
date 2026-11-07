namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class AK47RedFlash : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "11220_daoren", (player.GetCurrentWeaponEffectLevel() & 1) > 0);
		SetParticleActiveParticleName(player, "11220_daoguang_tuowei", (player.GetCurrentWeaponEffectLevel() & 2) > 0);
		SetParticleActiveParticleName(player, "11220_chudian", player.HasStatus(1155));
	}
}

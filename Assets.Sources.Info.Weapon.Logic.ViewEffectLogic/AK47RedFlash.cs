namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class AK47RedFlash : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "11220_daoren", (currentWeapon.basicInfo.Data.EffectLevel & 1) > 0);
		SetParticleActiveParticleName(player, "11220_daoguang_tuowei", (currentWeapon.basicInfo.Data.EffectLevel & 2) > 0);
		SetParticleActiveParticleName(player, "11220_chudian", player.HasStatus(1155));
	}
}

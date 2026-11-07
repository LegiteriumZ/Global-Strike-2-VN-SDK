namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class RiderDouGun : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		bool flag = player.viewAnim.ViewAnimInfo.StateId == 36 || player.viewAnim.ViewAnimInfo.StateId == 37;
		SetParticleActiveParticleName(player, "qiangshen_dan_p1", player.GetCurrentWeaponEffectLevel() == 1 && !flag);
		SetParticleActiveParticleName(player, "hejin_qiangshen_dan_p1", player.GetCurrentWeaponEffectLevel() == 1 && !flag);
		SetParticleActiveParticleName(player, "qiangshen_shuangchi", player.GetCurrentWeaponEffectLevel() == 0 && !flag);
		SetParticleActiveParticleName(player, "hejin_qiangshen_shuangchi", player.GetCurrentWeaponEffectLevel() == 0 && !flag);
	}
}

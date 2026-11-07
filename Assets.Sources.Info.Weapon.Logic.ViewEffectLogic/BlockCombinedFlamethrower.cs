namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BlockCombinedFlamethrower : AbstractViewWeaponEffectLogic
{
	private bool _isSetQiangkou;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "jimu_dianhuo", flag: false);
		SetParticleActiveParticleName(player, "jimu_dianhuo_p1", (player.GetCurrentWeaponEffectLevel() & 1) > 0);
		SetParticleActiveParticleName(player, "jimushangwei_qkhh", (player.GetCurrentWeaponEffectLevel() & 2) > 0);
		if (!_isSetQiangkou)
		{
			_isSetQiangkou = true;
			DestoryParticleFireControlByParticleName(player, "jimu_dianhuo_p1");
			DestoryParticleFireControlByParticleName(player, "jimushangwei_qkhh");
		}
	}
}

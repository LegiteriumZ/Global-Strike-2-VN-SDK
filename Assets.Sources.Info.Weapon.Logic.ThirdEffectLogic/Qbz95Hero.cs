namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Qbz95Hero : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponLevel = player.GetCurrentWeaponLevel();
		SetParticleActiveParticleName(player, "zsyj_jihuo", currentWeaponLevel == 2);
		SetParticleActiveParticleName(player, "zszr", currentWeaponLevel == 1);
	}
}

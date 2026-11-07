namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Qbz95Hero : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int level = currentWeapon.special.Level;
		SetParticleActiveParticleName(player, "zsyj_jihuo", level == 2);
		SetParticleActiveParticleName(player, "zszr", level == 1);
	}
}

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class DetectiveGrenade : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "jingbao", flag: false);
		SetParticleActiveParticleName(player, "attackjingbao", flag: false);
	}
}

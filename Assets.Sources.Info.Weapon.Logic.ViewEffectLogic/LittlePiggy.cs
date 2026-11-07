namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class LittlePiggy : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveBySkinName(player, "weapon_particle_effect", flag: true);
		SetParticleActiveBySkinName(player, "weapon_particle_fire_effect1", player.GetCurrentWeaponEffectLevel() == 1);
		SetParticleActiveBySkinName(player, "weapon_particle_fire_effect", player.GetCurrentWeaponEffectLevel() != 1);
	}
}

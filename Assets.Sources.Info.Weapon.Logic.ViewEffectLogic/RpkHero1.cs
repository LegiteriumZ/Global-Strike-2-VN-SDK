namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class RpkHero1 : AbstractViewWeaponEffectLogic
{
	private const string WEAPON_PARTICLE_EFFECT1 = "weapon_particle_effect1";

	private const string WEAPON_PARTICLE_EFFECT2 = "weapon_particle_effect2";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "weapon_particle_effect1", !IsSpecial(player));
		SetParticleActiveParticleName(player, "weapon_particle_effect2", IsSpecial(player));
	}

	private bool IsSpecial(PlayerEntity player)
	{
		return player.HasStatus(1503);
	}
}

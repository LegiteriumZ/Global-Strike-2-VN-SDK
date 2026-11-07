using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class VoidJump : AbstractThirdWeaponEffectLogic
{
	private static string WEAPON_EFFECT1 = "jihuo";

	private static string WEAPON_EFFECT2 = "yinshen";

	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		SetParticleActiveParticleName(player, WEAPON_EFFECT1, (currentWeaponEffectLevel & 0x80) > 0);
		SetParticleActiveParticleName(player, WEAPON_EFFECT2, (currentWeaponEffectLevel & 0x20) > 0);
		SetParticleActiveParticleName(player, "weapon_particle_fire_effect", FireUtility.IsFiring(player, isSelf: true));
	}
}

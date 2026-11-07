using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class JudgeEyeRifle : AbstractViewWeaponEffectLogic
{
	private static string WEAPON_EFFECT1 = "qiangshen_1_bianxing";

	private static string WEAPON_EFFECT2 = "qiangshen_2_bianxing";

	private static string WEAPON_EFFECT3 = "qiangshen_3_bianxing";

	private static string WEAPON_EFFECT4 = "qiangshen_1";

	private static string WEAPON_EFFECT5 = "qiangshen_2";

	private static string WEAPON_EFFECT6 = "qiangshen_3";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, WEAPON_EFFECT1, currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, WEAPON_EFFECT2, currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, WEAPON_EFFECT3, currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, WEAPON_EFFECT4, !currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, WEAPON_EFFECT5, !currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, WEAPON_EFFECT6, !currentWeapon.special.SpecialMode);
		SetParticleActiveBySkinName(player, "weapon_particle_fire_effect1", FireUtility.IsFiring(player, isSelf: true));
	}
}

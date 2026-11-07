using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class M4a1Pro : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveBySkinName(player, "weapon_particle_fire_effect1", currentWeapon.special.SpecialMode && FireUtility.IsFiring(player, isSelf: true));
		SetParticleActiveBySkinName(player, "weapon_particle_fire_effect", !currentWeapon.special.SpecialMode && FireUtility.IsFiring(player, isSelf: true));
	}
}

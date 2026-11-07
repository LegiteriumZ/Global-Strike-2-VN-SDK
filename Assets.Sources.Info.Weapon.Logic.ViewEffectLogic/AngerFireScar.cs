namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class AngerFireScar : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "weaponeffect", !currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, "weaponeffect1", currentWeapon.special.SpecialMode);
	}
}

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Aa12HellDragon : AbstractViewWeaponEffectLogic
{
	private const string ParticleName = "skillfireeffect";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "skillfireeffect", currentWeapon.special.SpecialMode);
	}
}

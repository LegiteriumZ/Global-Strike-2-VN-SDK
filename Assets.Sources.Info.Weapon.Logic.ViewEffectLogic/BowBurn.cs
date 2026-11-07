namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BowBurn : AbstractViewWeaponEffectLogic
{
	private static string JIAN_EFFECT = "jian";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, JIAN_EFFECT, currentWeapon.special.EffectLevel != 0);
	}
}

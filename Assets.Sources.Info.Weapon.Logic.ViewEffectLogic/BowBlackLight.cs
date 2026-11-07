namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BowBlackLight : AbstractViewWeaponEffectLogic
{
	private const string SKILL_PARTICLE_EFFECT = "shifa";

	private const string KUANGRE_PARTICLE_EFFECT = "kuangre";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "shifa", player.HasStatus(1078));
		SetParticleActiveParticleName(player, "kuangre", player.HasStatus(1077));
	}
}

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class CrossbowBlack : AbstractViewWeaponEffectLogic
{
	private const string SKILL_PARTICLE_EFFECT = "shifa";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "shifa", player.HasStatus(1011));
	}
}

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Aa12Hero : AbstractViewWeaponEffectLogic
{
	private const string Fire = "fire";

	private const string SkillFire = "skillfire";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "fire", !currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, "skillfire", player.viewAnim.ViewAnimInfo.StateId == 63);
	}
}

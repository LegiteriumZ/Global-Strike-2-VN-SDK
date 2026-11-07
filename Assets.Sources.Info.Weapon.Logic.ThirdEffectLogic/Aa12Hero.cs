namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Aa12Hero : AbstractThirdWeaponEffectLogic
{
	private const string Fire = "fire";

	private const string SkillFire = "skillfire";

	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "skillfire", player.GetCurrentWeaponLevel() == 1);
	}
}

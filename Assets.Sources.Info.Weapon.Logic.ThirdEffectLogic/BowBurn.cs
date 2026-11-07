namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class BowBurn : AbstractThirdWeaponEffectLogic
{
	private static string JIAN_EFFECT = "jian";

	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, JIAN_EFFECT, player.GetCurrentWeaponEffectLevel() != 0);
	}
}

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Aa12HellDragon : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "skillfireeffect", player.GetCurrentWeaponSubType() == 1);
	}
}

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class BowBlack : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "shifa", player.HasStatus(1011));
	}
}

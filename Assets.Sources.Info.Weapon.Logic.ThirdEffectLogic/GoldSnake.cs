namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class GoldSnake : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "sxbc", player.GetCurrentWeaponLevel() > 0);
	}
}

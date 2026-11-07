namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BowBlack : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "shifa", player.HasStatus(1011));
	}
}

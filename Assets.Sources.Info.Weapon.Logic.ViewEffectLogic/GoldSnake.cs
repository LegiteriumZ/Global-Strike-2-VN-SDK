namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class GoldSnake : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "sxbc", currentWeapon.special.Level > 0);
	}
}

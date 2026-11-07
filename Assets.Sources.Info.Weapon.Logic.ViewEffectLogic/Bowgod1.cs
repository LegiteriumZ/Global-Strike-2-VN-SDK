namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Bowgod1 : Bowgod
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		base.Update(player, currentWeapon, raceType);
		SetParticleActiveParticleName(player, "shifa", currentWeapon.special.EffectLevel != 0);
	}
}

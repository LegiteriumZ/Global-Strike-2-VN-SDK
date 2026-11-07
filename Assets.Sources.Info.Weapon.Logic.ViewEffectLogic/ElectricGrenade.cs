namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class ElectricGrenade : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "zhuizongtexiao", flag: false);
		SetParticleActiveParticleName(player, "dimian", flag: false);
	}
}

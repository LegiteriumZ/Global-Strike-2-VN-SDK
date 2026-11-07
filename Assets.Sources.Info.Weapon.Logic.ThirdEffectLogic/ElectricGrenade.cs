namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class ElectricGrenade : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "zhuizongtexiao", flag: false);
		SetParticleActiveParticleName(player, "dimian", flag: false);
	}
}

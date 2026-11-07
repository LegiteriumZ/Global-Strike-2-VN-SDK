namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class DetectiveGrenade : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "jingbao", flag: false);
		SetParticleActiveParticleName(player, "attackjingbao", flag: false);
	}
}

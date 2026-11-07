namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Ak47Legent : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "clipeffect", flag: false);
	}
}

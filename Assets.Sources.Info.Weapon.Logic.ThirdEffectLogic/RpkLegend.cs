namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class RpkLegend : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "danjia", flag: false);
	}
}

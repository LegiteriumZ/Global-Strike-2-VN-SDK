namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class GatlingDouRage : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "qiangshen_1", flag: false);
		SetParticleActiveParticleName(player, "qiangshentexiao_p1", flag: false);
	}
}

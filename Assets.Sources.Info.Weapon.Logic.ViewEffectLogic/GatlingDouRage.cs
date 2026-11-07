namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class GatlingDouRage : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "qiangshen_2jie_p3", flag: false);
		SetParticleActiveParticleName(player, "qiangshentexiao_p3", flag: false);
	}
}

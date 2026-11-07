namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class RpgRedflash : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "11170_shengcheng", currentWeapon.special.EffectLevel == 2);
		SetParticleActiveParticleName(player, "11170_dianqiu", currentWeapon.special.EffectLevel == 4);
	}
}

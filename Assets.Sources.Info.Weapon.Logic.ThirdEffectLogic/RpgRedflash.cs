namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class RpgRedflash : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "11170_shengcheng", player.GetCurrentWeaponEffectLevel() == 2);
		SetParticleActiveParticleName(player, "11170_dianqiu", player.GetCurrentWeaponEffectLevel() == 4);
	}
}

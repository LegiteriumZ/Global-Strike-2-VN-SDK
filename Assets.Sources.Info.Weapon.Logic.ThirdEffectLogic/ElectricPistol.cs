namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class ElectricPistol : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "weaponeffect1", (player.GetCurrentWeaponSubType() & 2) != 0);
		SetParticleActiveParticleName(player, "weaponeffect2", (player.GetCurrentWeaponSubType() & 2) != 0);
	}
}

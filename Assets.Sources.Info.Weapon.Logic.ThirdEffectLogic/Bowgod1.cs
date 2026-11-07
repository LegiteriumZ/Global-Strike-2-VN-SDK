using Assets.Sources.Utils.Player;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class Bowgod1 : Bowgod
{
	public override void Update(PlayerEntity player, int raceType)
	{
		base.Update(player, raceType);
		int bowWeaponState = PlayerUtility.GetBowWeaponState(player);
		SetParticleActiveParticleName(player, "shifa", player.GetCurrentWeaponEffectLevel() != 0);
		SetParticleActiveParticleName(player, "weaponeffect", (bowWeaponState & 2) != 0);
		SetParticleActiveParticleName(player, "qiangshentexiao", (bowWeaponState & 2) != 0);
		SetParticleActiveParticleName(player, "weaponeffect1", (bowWeaponState & 2) == 0);
		SetParticleActiveParticleName(player, "qiangshentexiao_P3", (bowWeaponState & 2) == 0);
	}
}

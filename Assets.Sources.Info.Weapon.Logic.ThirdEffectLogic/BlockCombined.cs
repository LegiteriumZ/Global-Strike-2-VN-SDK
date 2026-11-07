using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class BlockCombined : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "qkhh_0", FireUtility.IsFiring(player, isSelf: false) && (player.GetCurrentWeaponEffectLevel() & 1) == 0);
		SetParticleActiveParticleName(player, "qkhh_1", FireUtility.IsFiring(player, isSelf: false) && (player.GetCurrentWeaponEffectLevel() & 1) > 0);
		SetParticleActiveParticleName(player, "qiangshentexiao_feiji", player.torseAnim.Equals(14));
	}
}

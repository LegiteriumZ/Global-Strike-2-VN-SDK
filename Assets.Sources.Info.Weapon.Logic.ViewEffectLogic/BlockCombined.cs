using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class BlockCombined : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleNoFireControlByParticleName(player, "qkhh_1");
		SetParticleNoFireControlByParticleName(player, "qkhh_0");
		SetParticleActiveParticleName(player, "qkhh_0", FireUtility.IsFiring(player, isSelf: true) && (player.GetCurrentWeaponEffectLevel() & 1) == 0);
		SetParticleActiveParticleName(player, "qkhh_1", FireUtility.IsFiring(player, isSelf: true) && (player.GetCurrentWeaponEffectLevel() & 1) > 0);
		SetParticleActiveParticleName(player, "qiangshentexiao_feiji", player.viewAnim.Equals(14));
	}
}

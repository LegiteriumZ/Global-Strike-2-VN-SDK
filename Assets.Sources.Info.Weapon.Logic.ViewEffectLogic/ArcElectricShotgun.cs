using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class ArcElectricShotgun : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		bool flag = player.viewAnim.Equals(36) || player.viewAnim.Equals(37);
		bool flag2 = (player.GetCurrentWeaponEffectLevel() & 2) > 0;
		bool flag3 = FireUtility.IsFiring(player, isSelf: true, right: true, viewCheckLeftAttackFire: true);
		SetParticleActiveParticleName(player, "qiangshen_1", !flag && flag2);
		SetParticleActiveParticleName(player, "qkhh", !flag && flag2 && flag3);
		SetParticleActiveParticleName(player, "qiangshen_0", !flag && !flag2);
		SetParticleActiveParticleName(player, "qiangkouhuohua_pj", !flag && !flag2 && flag3);
	}
}

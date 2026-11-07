using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class Ak47Unique : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		bool flag = player.viewAnim.ViewAnimInfo.StateId == 36 || player.viewAnim.ViewAnimInfo.StateId == 37;
		SetParticleActiveParticleName(player, "qiangshen_dan_p1", player.GetCurrentWeaponEffectLevel() == 1 && !flag);
		SetParticleActiveParticleName(player, "qiangshen_shuangchi", player.GetCurrentWeaponEffectLevel() == 0 && !flag);
		SetParticleActiveParticleNameGenIndexOf(player, "_qiangshen", flag: true);
		SetParticleActiveParticleNameGenIndexOf(player, "_1", (player.GetCurrentWeaponEffectLevel() & 2) > 0 || (player.GetCurrentWeaponEffectLevel() & 0x200) > 0);
		SetParticleActiveParticleNameGenIndexOf(player, "_2", (player.GetCurrentWeaponEffectLevel() & 4) > 0 || (player.GetCurrentWeaponEffectLevel() & 0x400) > 0);
		SetParticleActiveParticleNameGenIndexOf(player, "_3", (player.GetCurrentWeaponEffectLevel() & 8) > 0 || (player.GetCurrentWeaponEffectLevel() & 0x800) > 0);
		SetParticleActiveParticleNameGenIndexOf(player, "_4", (player.GetCurrentWeaponEffectLevel() & 0x10) > 0 || (player.GetCurrentWeaponEffectLevel() & 0x1000) > 0);
		if ((player.GetCurrentWeaponEffectLevel() & 2) > 0 && (player.GetCurrentWeaponEffectLevel() & 4) > 0 && (player.GetCurrentWeaponEffectLevel() & 8) > 0 && (player.GetCurrentWeaponEffectLevel() & 0x10) > 0)
		{
			SetParticleActiveParticleNameGenIndexOf(player, "jihuodaqiu", flag: true);
		}
		else if ((player.GetCurrentWeaponEffectLevel() & 0x200) > 0 && (player.GetCurrentWeaponEffectLevel() & 0x400) > 0 && (player.GetCurrentWeaponEffectLevel() & 0x800) > 0 && (player.GetCurrentWeaponEffectLevel() & 0x1000) > 0)
		{
			SetParticleActiveParticleNameGenIndexOf(player, "jihuodaqiu", flag: true);
		}
		else
		{
			SetParticleActiveParticleNameGenIndexOf(player, "jihuodaqiu", flag: false);
		}
		SetParticleActiveParticleName(player, "sanshe_qiangkouhuohua", FireUtility.IsFiring(player, isSelf: true, right: true, viewCheckLeftAttackFire: true) && !currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, "11380_qiangkouhuohua_kun", FireUtility.IsFiring(player, isSelf: true, right: true, viewCheckLeftAttackFire: true) && !currentWeapon.special.SpecialMode);
		SetParticleActiveParticleName(player, "11380_qiangkouhuohua", FireUtility.IsFiring(player, isSelf: true, right: true, viewCheckLeftAttackFire: true) && currentWeapon.special.SpecialMode);
	}
}

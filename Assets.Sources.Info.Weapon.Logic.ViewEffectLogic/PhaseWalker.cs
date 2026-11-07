using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class PhaseWalker : AbstractViewWeaponEffectLogic
{
	private const string Fire = "bianxinghou";

	private const string SkillFire = "bianxingqian";

	private const string WeaponEffect1 = "qiangshen_P1";

	private const string WeaponEffect2 = "qiangshen_hou_P1";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		int effectLevel = currentWeapon.special.EffectLevel;
		if (player.viewAnim.ViewAnimInfo.StateId == 36 || player.viewAnim.ViewAnimInfo.StateId == 37)
		{
			SetParticleActiveParticleNameGenIndexOfZero(player, "bianxinghou", flag: false);
			SetParticleActiveParticleNameGenIndexOfZero(player, "bianxingqian", flag: false);
			SetParticleActiveParticleName(player, "qiangshen_P1", flag: false);
			SetParticleActiveParticleName(player, "qiangshen_hou_P1", flag: false);
		}
		else
		{
			SetParticleActiveParticleNameGenIndexOfZero(player, "bianxinghou", (effectLevel & 1) > 0);
			SetParticleActiveParticleNameGenIndexOfZero(player, "bianxingqian", (effectLevel & 1) == 0);
			SetParticleActiveParticleName(player, "qiangshen_hou_P1", (effectLevel & 1) > 0);
			SetParticleActiveParticleName(player, "qiangshen_P1", (effectLevel & 1) == 0);
			SetParticleActiveBySkinName(player, "weapon_particle_fire_effect", FireUtility.IsFiring(player, isSelf: true));
		}
	}
}

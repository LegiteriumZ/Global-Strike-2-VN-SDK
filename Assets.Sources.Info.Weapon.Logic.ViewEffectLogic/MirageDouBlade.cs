namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class MirageDouBlade : AbstractViewWeaponEffectLogic
{
	private const string WEAPON_EFFECT1 = "qiangshen_jujian";

	private const string WEAPON_EFFECT2 = "qiangshen_shuang";

	private const string WEAPON_EFFECT3 = "bianxing";

	private const string WEAPON_EFFECT4 = "zhenhong_qiangshen_jujian";

	private const string WEAPON_EFFECT5 = "zhenhong_qiangshen_shuang";

	private const string WEAPON_EFFECT6 = "zhenhong_bianxing";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, "qiangshen_jujian", (player.GetCurrentWeaponEffectLevel() & 0x20) > 0 && !player.viewAnim.Equals(36));
		SetParticleActiveParticleName(player, "zhenhong_qiangshen_jujian", (player.GetCurrentWeaponEffectLevel() & 0x20) > 0 && !player.viewAnim.Equals(36));
		SetParticleActiveParticleName(player, "qiangshen_shuang", (player.GetCurrentWeaponEffectLevel() & 0x20) == 0 && !player.viewAnim.Equals(36));
		SetParticleActiveParticleName(player, "zhenhong_qiangshen_shuang", (player.GetCurrentWeaponEffectLevel() & 0x20) == 0 && !player.viewAnim.Equals(36));
		SetParticleActiveParticleName(player, "bianxing", (player.GetCurrentWeaponEffectLevel() & 0x20) > 0);
		SetParticleActiveParticleName(player, "zhenhong_bianxing", (player.GetCurrentWeaponEffectLevel() & 0x20) > 0);
	}
}

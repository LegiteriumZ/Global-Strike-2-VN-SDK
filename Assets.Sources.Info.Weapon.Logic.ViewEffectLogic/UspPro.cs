using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

internal class UspPro : AbstractViewWeaponEffectLogic
{
	private static string WEAPON_EFFECT1 = "11240_qiangkouhuohua";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, WEAPON_EFFECT1, (player.GetCurrentWeaponEffectLevel() & 1) > 0 && FireUtility.IsFiring(player, isSelf: true));
	}
}

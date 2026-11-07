namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class PhotonGrenadeCombination : AbstractViewWeaponEffectLogic
{
	private static string QIANGSHEN_PARTICLE_NAME = "qiangshen_0jie";

	private static string QIANGSHEN_PARTICLE_NAME1 = "qiangshen_1jie";

	private bool GetWeaponEffectVisible(PlayerEntity player, WeaponEntity currentWeapon)
	{
		if (player.viewAnim.ViewAnimInfo.StateId != 36)
		{
			return player.viewAnim.ViewAnimInfo.StateId != 37;
		}
		return false;
	}

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleName(player, QIANGSHEN_PARTICLE_NAME, GetWeaponEffectVisible(player, currentWeapon));
		SetParticleActiveParticleName(player, QIANGSHEN_PARTICLE_NAME1, GetWeaponEffectVisible(player, currentWeapon));
	}
}

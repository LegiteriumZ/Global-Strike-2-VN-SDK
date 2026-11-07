namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class GlockHellSnake : AbstractViewWeaponEffectLogic
{
	private bool GetWeaponEffectVisible(PlayerEntity player, WeaponEntity currentWeapo)
	{
		if (currentWeapo.special.EffectLevel == 1 && player.viewAnim.ViewAnimInfo.StateId != 36)
		{
			return player.viewAnim.ViewAnimInfo.StateId != 37;
		}
		return false;
	}

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		GetPaticleBySkinName(player, "weapon_particle_effect")?.SetInsActive(GetWeaponEffectVisible(player, currentWeapon));
	}
}

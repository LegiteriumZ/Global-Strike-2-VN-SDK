using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class ShotGunLaser : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (Func == null)
		{
			Func = UpdateVisible;
		}
		SetParticleActiveBySkinName(player, currentWeapon, UpdateVisible);
	}

	private static int UpdateVisible(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		if (currentWeapon != null && currentWeapon.hasSpecial && currentWeapon.special.SpecialMode)
		{
			if (skin == "weapon_particle_fire_effect")
			{
				return 0;
			}
			if (skin == "weapon_particle_fire_effect1")
			{
				if (!FireUtility.IsFiring(player, isSelf: true, right: true, viewCheckLeftAttackFire: true))
				{
					return 0;
				}
				return 1;
			}
		}
		else
		{
			if (skin == "weapon_particle_fire_effect1")
			{
				return 0;
			}
			if (skin == "weapon_particle_fire_effect")
			{
				if (!FireUtility.IsFiring(player, isSelf: true, right: true, viewCheckLeftAttackFire: true))
				{
					return 0;
				}
				return 1;
			}
		}
		return -1;
	}
}

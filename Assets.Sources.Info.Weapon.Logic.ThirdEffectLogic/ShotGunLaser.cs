using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class ShotGunLaser : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		if (Func == null)
		{
			Func = UpdateVisible;
		}
		SetParticleActiveBySkinName(player, Func);
	}

	private static int UpdateVisible(PlayerEntity player, string skin, string particle)
	{
		WeaponEntity currentWeapon = WeaponUtility.GetCurrentWeapon(player);
		if (currentWeapon != null && currentWeapon.hasSpecial && currentWeapon.special.SpecialMode)
		{
			if (skin == "weapon_left_particle_fire_effect")
			{
				return 0;
			}
			if (skin == "weapon_left_particle_fire_effect1")
			{
				if (!FireUtility.IsFiring(player, isSelf: false))
				{
					return 0;
				}
				return 1;
			}
		}
		else
		{
			if (skin == "weapon_left_particle_fire_effect1")
			{
				return 0;
			}
			if (skin == "weapon_left_particle_fire_effect")
			{
				if (!FireUtility.IsFiring(player, isSelf: false))
				{
					return 0;
				}
				return 1;
			}
		}
		return -1;
	}
}

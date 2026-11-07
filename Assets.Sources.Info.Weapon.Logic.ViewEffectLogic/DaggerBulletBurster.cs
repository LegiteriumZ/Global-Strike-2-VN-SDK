using System;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class DaggerBulletBurster : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		if (Func == null)
		{
			Func = SetEffectFlag;
		}
		SetParticleActiveBySkinName(player, currentWeapon, Func);
	}

	private int SetEffectFlag(PlayerEntity player, WeaponEntity currentWeapon, string skin, string particle)
	{
		if (particle.IndexOf("jihuo_effect", StringComparison.Ordinal) != -1)
		{
			if (currentWeapon.special.SpecialMode)
			{
				return 1;
			}
			return 0;
		}
		return 1;
	}
}

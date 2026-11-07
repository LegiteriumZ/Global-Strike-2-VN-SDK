using System;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class DaggerBulletBurster : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		if (Func == null)
		{
			Func = SetEffectFlag;
		}
		SetParticleActiveBySkinName(player, Func);
	}

	private int SetEffectFlag(PlayerEntity player, string skin, string particle)
	{
		if (particle.IndexOf("jihuo_effect", StringComparison.Ordinal) != -1)
		{
			if ((player.GetCurrentWeaponEffectLevel() & 2) > 0)
			{
				return 1;
			}
			return 0;
		}
		return 1;
	}
}

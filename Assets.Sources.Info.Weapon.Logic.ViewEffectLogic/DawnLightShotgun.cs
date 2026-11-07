using System;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class DawnLightShotgun : AbstractViewWeaponEffectLogic
{
	private Func<PlayerEntity, WeaponEntity, string, string, int> _func;

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		SetParticleActiveParticleNameGenIndexOf(player, "_gaoneng", (player.GetCurrentWeaponEffectLevel() & 1) > 0);
		if (_func == null)
		{
			_func = SetActive;
		}
		SetParticleActiveBySkinName(player, currentWeapon, _func);
	}

	private int SetActive(PlayerEntity player, WeaponEntity weapon, string joint, string particle)
	{
		if (joint.Equals("weapon_particle_fire_effect"))
		{
			if (particle.IndexOf("jiguang_qiangkou", StringComparison.Ordinal) >= 0)
			{
				if ((player.GetCurrentWeaponEffectLevel() & 2) > 0)
				{
					return 1;
				}
				return 0;
			}
			if (particle.IndexOf("QiangKouHuoHua", StringComparison.Ordinal) >= 0)
			{
				if ((player.GetCurrentWeaponEffectLevel() & 2) > 0)
				{
					return 0;
				}
				return 1;
			}
		}
		return -1;
	}
}

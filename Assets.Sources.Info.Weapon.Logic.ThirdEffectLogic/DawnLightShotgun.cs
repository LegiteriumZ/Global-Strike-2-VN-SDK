using System;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class DawnLightShotgun : AbstractThirdWeaponEffectLogic
{
	private Func<PlayerEntity, string, string, int> _func;

	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleNameGenIndexOf(player, "_gaoneng", (player.GetCurrentWeaponEffectLevel() & 1) > 0);
		if (_func == null)
		{
			_func = SetActive;
		}
		SetParticleActiveBySkinName(player, _func);
	}

	private int SetActive(PlayerEntity player, string joint, string particle)
	{
		if (joint.Equals("weapon_particle_fire_effect") && particle.IndexOf("jiguang_qiangkou", StringComparison.Ordinal) >= 0)
		{
			if ((player.GetCurrentWeaponEffectLevel() & 2) > 0)
			{
				return 1;
			}
			return 0;
		}
		return -1;
	}
}

using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class ShadowLessSword : AbstractViewWeaponEffectLogic
{
	private const string WeaponEffect = "jianshentx";

	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals("jianshentx"))
			{
				particle.Value.GetIns().transform.localScale = new Vector3((float)currentWeapon.power.Power / 100f, 1f, 1f);
				if (currentWeapon.power.Power == 0)
				{
					particle.Value.SetInsActive(flag: false);
				}
				else
				{
					particle.Value.SetInsActive(flag: true);
				}
			}
		}
	}
}

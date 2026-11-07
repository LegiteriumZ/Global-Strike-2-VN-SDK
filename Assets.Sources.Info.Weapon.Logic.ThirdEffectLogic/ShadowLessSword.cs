using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class ShadowLessSword : AbstractThirdWeaponEffectLogic
{
	private const string WEAPON_EFFECT = "jianshentx";

	private float showX;

	public override void Update(PlayerEntity player, int raceType)
	{
		int currentWeaponEffectLevel = player.GetCurrentWeaponEffectLevel();
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals("jianshentx"))
			{
				if ((currentWeaponEffectLevel & 2) > 0)
				{
					showX = 1f;
				}
				else if ((currentWeaponEffectLevel & 1) > 0)
				{
					showX = 0.4f;
				}
				else
				{
					showX = 0f;
				}
				if (showX == 0f)
				{
					particle.Value.SetInsActive(flag: false);
				}
				else
				{
					particle.Value.SetInsActive(flag: true);
				}
				particle.Value.GetIns().transform.localScale = new Vector3(showX, 1f, 1f);
			}
		}
	}
}

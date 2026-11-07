using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class DartsRedflash : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponanchor"].enabled = true;
		skins["weaponanchor3"].enabled = true;
		if ((player.GetCurrentWeaponEffectLevel() & 1) > 0)
		{
			skins["weaponanchor3"].enabled = false;
		}
		if ((player.GetCurrentWeaponEffectLevel() & 2) > 0)
		{
			skins["weaponanchor"].enabled = false;
		}
		if ((player.GetCurrentWeaponEffectLevel() & 4) > 0)
		{
			skins["weaponanchor"].enabled = false;
			skins["weaponanchor3"].enabled = false;
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals("11180-wuqi00"))
			{
				particle.Value.SetInsActive((player.GetCurrentWeaponEffectLevel() & 1) > 0);
			}
			if (particle.Key.PatricleName.Equals("11180-shouzhang"))
			{
				particle.Value.SetInsActive((player.GetCurrentWeaponEffectLevel() & 4) > 0);
			}
			if (particle.Key.PatricleName.Equals("11180-wuqi01"))
			{
				particle.Value.SetInsActive((player.GetCurrentWeaponEffectLevel() & 2) > 0);
			}
		}
	}
}

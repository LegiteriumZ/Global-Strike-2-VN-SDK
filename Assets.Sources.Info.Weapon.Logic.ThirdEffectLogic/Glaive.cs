using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

internal class Glaive : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		bool flag = (player.GetCurrentWeaponEffectLevel() & 1) > 0;
		skins["weaponanchor"].enabled = !flag;
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			particle.Value.SetInsActive(!flag);
		}
	}
}

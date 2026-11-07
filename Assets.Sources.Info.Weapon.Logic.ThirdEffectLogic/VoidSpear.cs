using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class VoidSpear : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		bool flag = (player.GetCurrentWeaponEffectLevel() & 4) > 0;
		skins["weaponanchor3"].enabled = flag;
		if (flag)
		{
			SetParticleActiveBySkinName(player, "weapon_particle_effect1", flag: false);
			SetParticleActiveBySkinName(player, "weapon_left_particle_effect1", flag: false);
			SetParticleActiveBySkinName(player, "weapon_particle_effect2", flag: true);
			SetParticleActiveBySkinName(player, "weapon_particle_effect3", flag: true);
		}
		else
		{
			SetParticleActiveBySkinName(player, "weapon_particle_effect2", flag: false);
			SetParticleActiveBySkinName(player, "weapon_particle_effect3", flag: false);
			SetParticleActiveBySkinName(player, "weapon_particle_effect1", flag: true);
			SetParticleActiveBySkinName(player, "weapon_left_particle_effect1", flag: true);
		}
		skins["weaponanchor"].enabled = !flag;
		skins["weaponanchor2"].enabled = !flag;
	}
}

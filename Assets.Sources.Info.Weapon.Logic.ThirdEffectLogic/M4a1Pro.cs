using System.Collections.Generic;
using Assets.Sources.Utils.Weapon;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class M4a1Pro : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		SetParticleActiveParticleName(player, "weapon_particle_fire_effect1", (player.GetCurrentWeaponEffectLevel() & 1) > 0 && FireUtility.IsFiring(player, isSelf: true));
		SetParticleActiveParticleName(player, "weapon_particle_fire_effect", (player.GetCurrentWeaponEffectLevel() & 1) == 0 && FireUtility.IsFiring(player, isSelf: true));
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		SetSkinVisible(skins, "weaponanchor3", (player.GetCurrentWeaponEffectLevel() & 1) > 0);
	}
}

using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class HeroBlade : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (skins.ContainsKey("weaponeffect21"))
		{
			skins["weaponeffect21"].enabled = (player.GetCurrentWeaponEffectLevel() & 2) > 0;
		}
		if (skins.ContainsKey("weaponeffect22"))
		{
			skins["weaponeffect22"].enabled = (player.GetCurrentWeaponEffectLevel() & 8) > 0;
		}
		if (skins.ContainsKey("weaponeffect23"))
		{
			skins["weaponeffect23"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x20) > 0;
		}
		if (skins.ContainsKey("weaponeffect24"))
		{
			skins["weaponeffect24"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x80) > 0;
		}
		if (skins.ContainsKey("weaponeffect25"))
		{
			skins["weaponeffect25"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x200) > 0;
		}
		if (skins.ContainsKey("weaponeffect26"))
		{
			skins["weaponeffect26"].enabled = (player.GetCurrentWeaponEffectLevel() & 0x800) > 0;
		}
		SetParticleActiveBySkinName(player, "weapon_particle_effect", (player.GetCurrentWeaponEffectLevel() & 0x2000) > 0);
		SetParticleActiveBySkinName(player, "weapon_particle_effect1", (player.GetCurrentWeaponEffectLevel() & 0x8000) > 0);
	}
}

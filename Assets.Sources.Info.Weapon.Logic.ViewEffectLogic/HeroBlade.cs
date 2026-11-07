using System.Collections.Generic;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public class HeroBlade : AbstractViewWeaponEffectLogic
{
	public override void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		skins["weaponeffect21"].enabled = (currentWeapon.special.EffectLevel & 2) > 0;
		skins["weaponeffect22"].enabled = (currentWeapon.special.EffectLevel & 8) > 0;
		skins["weaponeffect23"].enabled = (currentWeapon.special.EffectLevel & 0x20) > 0;
		skins["weaponeffect24"].enabled = (currentWeapon.special.EffectLevel & 0x80) > 0;
		skins["weaponeffect25"].enabled = (currentWeapon.special.EffectLevel & 0x200) > 0;
		skins["weaponeffect26"].enabled = (currentWeapon.special.EffectLevel & 0x800) > 0;
		SetParticleActiveBySkinName(player, "weapon_particle_effect", (currentWeapon.special.EffectLevel & 0x2000) > 0);
		SetParticleActiveBySkinName(player, "weapon_particle_effect1", (currentWeapon.special.EffectLevel & 0x8000) > 0);
	}
}

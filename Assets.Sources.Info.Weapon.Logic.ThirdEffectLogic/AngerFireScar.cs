using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Utils.Player;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class AngerFireScar : AbstractThirdWeaponEffectLogic
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		IPaticlePrefabInstancecs paticleBySkinName = GetPaticleBySkinName(player, "weapon_particle_effect1");
		IPaticlePrefabInstancecs paticleBySkinName2 = GetPaticleBySkinName(player, "weapon_particle_effect2");
		IPaticlePrefabInstancecs paticleBySkinName3 = GetPaticleBySkinName(player, "weapon_particle_fire_effect");
		bool flag = (PlayerUtility.GetBowWeaponState(player) & 1) != 0;
		if (skins.ContainsKey("weaponanchor"))
		{
			skins["weaponanchor"].gameObject.SetObjectActive(flag);
		}
		if (skins.ContainsKey("weaponanchor3"))
		{
			skins["weaponanchor3"].gameObject.SetObjectActive(!flag);
		}
		paticleBySkinName?.SetInsActive(flag);
		paticleBySkinName2?.SetInsActive(!flag);
		paticleBySkinName3?.SetInsActive(flag);
	}
}

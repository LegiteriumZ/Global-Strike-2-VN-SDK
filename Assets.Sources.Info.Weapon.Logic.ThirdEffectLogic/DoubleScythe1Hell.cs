using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ThirdEffectLogic;

public class DoubleScythe1Hell : DoubleScythe
{
	public override void Update(PlayerEntity player, int raceType)
	{
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins = GetSkins(player);
		if (skins == null)
		{
			return;
		}
		SkinnedMeshRenderer skinnedMeshRenderer = skins["weaponanchor"];
		SkinnedMeshRenderer skinnedMeshRenderer2 = skins["weaponanchor2"];
		SkinnedMeshRenderer skinnedMeshRenderer3 = skins["weaponanchor3"];
		PaticlePrefabInstancecs paticlePrefabInstancecs = GetPaticleBySkinName(player, "weapon_particle_effect") as PaticlePrefabInstancecs;
		PaticlePrefabInstancecs paticlePrefabInstancecs2 = GetPaticleBySkinName(player, "weapon_left_particle_effect") as PaticlePrefabInstancecs;
		PaticlePrefabInstancecs paticlePrefabInstancecs3 = GetPaticleBySkinName(player, "weapon_particle_effect1") as PaticlePrefabInstancecs;
		PaticlePrefabInstancecs paticlePrefabInstancecs4 = GetPaticleBySkinName(player, "weapon_particle_effect2") as PaticlePrefabInstancecs;
		if (IsSpecial(player))
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
			skinnedMeshRenderer3.gameObject.SetObjectActive(isactive: true);
			if (paticlePrefabInstancecs != null)
			{
				paticlePrefabInstancecs.gameObject.SetObjectActive(isactive: false);
			}
			if (paticlePrefabInstancecs2 != null)
			{
				paticlePrefabInstancecs2.gameObject.SetObjectActive(isactive: false);
			}
			if (paticlePrefabInstancecs3 != null)
			{
				paticlePrefabInstancecs3.gameObject.SetObjectActive(isactive: true);
			}
			if (paticlePrefabInstancecs4 != null)
			{
				paticlePrefabInstancecs4.gameObject.SetObjectActive(isactive: true);
			}
		}
		else
		{
			skinnedMeshRenderer.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: true);
			skinnedMeshRenderer3.gameObject.SetObjectActive(isactive: false);
			if (paticlePrefabInstancecs != null)
			{
				paticlePrefabInstancecs.gameObject.SetObjectActive(isactive: true);
			}
			if (paticlePrefabInstancecs2 != null)
			{
				paticlePrefabInstancecs2.gameObject.SetObjectActive(isactive: true);
			}
			if (paticlePrefabInstancecs3 != null)
			{
				paticlePrefabInstancecs3.gameObject.SetObjectActive(isactive: false);
			}
			if (paticlePrefabInstancecs4 != null)
			{
				paticlePrefabInstancecs4.gameObject.SetObjectActive(isactive: false);
			}
		}
	}
}

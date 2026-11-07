using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson.Utility;

public class QianglingWeaponModelUtility
{
	private static Dictionary<string, SkinnedMeshRenderer> getSkins(GameObject model)
	{
		Dictionary<string, SkinnedMeshRenderer> dictionary = new Dictionary<string, SkinnedMeshRenderer>();
		SkinnedMeshRenderer[] componentsInChildren = model.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
		{
			if ((bool)skinnedMeshRenderer.rootBone)
			{
				string key = skinnedMeshRenderer.rootBone.name.ToLower();
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(skinnedMeshRenderer.rootBone.name.ToLower(), skinnedMeshRenderer);
				}
			}
		}
		return dictionary;
	}

	private static Dictionary<string, PaticlePrefabInstancecs> getParticleGameObjects(GameObject model)
	{
		Dictionary<string, PaticlePrefabInstancecs> dictionary = new Dictionary<string, PaticlePrefabInstancecs>();
		PaticlePrefabInstancecs[] componentsInChildren = model.GetComponentsInChildren<PaticlePrefabInstancecs>();
		foreach (PaticlePrefabInstancecs paticlePrefabInstancecs in componentsInChildren)
		{
			string key = paticlePrefabInstancecs.gameObject.name.ToLower();
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, paticlePrefabInstancecs);
			}
		}
		return dictionary;
	}

	public static void qianglingWeaponModelShow(string weaponName, GameObject model)
	{
		Dictionary<string, SkinnedMeshRenderer> skins = getSkins(model);
		Dictionary<string, PaticlePrefabInstancecs> particleGameObjects = getParticleGameObjects(model);
		SetSkinVisible(skins, "weaponanchor2", vis: false);
		SetSkinVisible(skins, "weaponanchor3", vis: false);
		SetParticleActive(particleGameObjects, "weapon_left_particle_effect", vis: false);
		SetParticleActive(particleGameObjects, "weapon_left_particle_fire_effect", vis: false);
		switch (weaponName)
		{
		case "infinite_hand1_change_1":
		case "infinite_hand2_change_1":
		case "infinite_hand3_change_1":
			SetParticleActive(particleGameObjects, "weapon_particle_effect", vis: false);
			SetParticleActive(particleGameObjects, "weapon_left_particle_fire_effect", vis: true);
			break;
		case "angerfirescar":
		case "angerfirescar1":
		case "double_scythe_hell1":
			SetParticleActive(particleGameObjects, "weapon_particle_effect2", vis: false);
			break;
		case "double_scythe_hell":
			SetSkinVisible(skins, "weaponeffect2", vis: false);
			SetSkinVisible(skins, "weaponeffect3", vis: false);
			break;
		case "rider_dou_gun":
			SetParticleActive(particleGameObjects, "weapon_particle_effect1", vis: false);
			SetParticleActive(particleGameObjects, "weapon_particle_fire_effect1", vis: false);
			break;
		}
		skins.Clear();
		skins = null;
		particleGameObjects.Clear();
		skins = null;
	}

	private static void SetSkinVisible(Dictionary<string, SkinnedMeshRenderer> skins, string jointname, bool vis)
	{
		skins.TryGetValue(jointname.ToLower(), out var value);
		if (value != null)
		{
			value.gameObject.SetActive(vis);
		}
	}

	private static void SetParticleActive(Dictionary<string, PaticlePrefabInstancecs> skins, string jointname, bool vis)
	{
		skins.TryGetValue(jointname.ToLower(), out var value);
		if (value != null)
		{
			value.gameObject.SetActive(vis);
		}
	}
}

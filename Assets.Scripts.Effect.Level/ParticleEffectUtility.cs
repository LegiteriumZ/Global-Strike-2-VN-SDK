using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using SSJJBase.Singleton;
using SSJJParticle;
using UnityEngine;

namespace Assets.Scripts.Effect.Level;

public class ParticleEffectUtility
{
	private static bool _isOnlyWeapon = false;

	private static Dictionary<string, string> _assetInfoPathCache = new Dictionary<string, string>();

	public static void InitNpcParticle(GameObject npcObj, string npcName)
	{
		if (!_isOnlyWeapon && MonoBehaviourSingleton<ParticleEffectManager>.Instance.IsOpen && !(npcObj == null) && !string.IsNullOrEmpty(npcName))
		{
			PaticlePrefabInstancecs[] componentsInChildren = npcObj.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
			foreach (PaticlePrefabInstancecs instance in componentsInChildren)
			{
				MonoBehaviourSingleton<ParticleEffectManager>.Instance.RegisterParticleInstance(instance, PaticleInstanceType.npc, npcName);
			}
		}
	}

	public static void InitAccessoryParticle(GameObject accessoryObj, string accessoryName)
	{
		if (!_isOnlyWeapon && MonoBehaviourSingleton<ParticleEffectManager>.Instance.IsOpen && !(accessoryObj == null) && !string.IsNullOrEmpty(accessoryName))
		{
			PaticlePrefabInstancecs[] componentsInChildren = accessoryObj.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
			foreach (PaticlePrefabInstancecs instance in componentsInChildren)
			{
				MonoBehaviourSingleton<ParticleEffectManager>.Instance.RegisterParticleInstance(instance, PaticleInstanceType.accessory, accessoryName);
			}
		}
	}

	public static void InitWeaponParticle(GameObject weaponObj, string weaponName)
	{
		if (MonoBehaviourSingleton<ParticleEffectManager>.Instance.IsOpen && !(weaponObj == null) && !string.IsNullOrEmpty(weaponName))
		{
			PaticlePrefabInstancecs[] componentsInChildren = weaponObj.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
			foreach (PaticlePrefabInstancecs instance in componentsInChildren)
			{
				MonoBehaviourSingleton<ParticleEffectManager>.Instance.RegisterParticleInstance(instance, PaticleInstanceType.weapon, weaponName);
			}
		}
	}

	public static void InitPlayerParticle(GameObject playerObj, string playerName)
	{
		if (!_isOnlyWeapon && MonoBehaviourSingleton<ParticleEffectManager>.Instance.IsOpen && !(playerObj == null) && !string.IsNullOrEmpty(playerName))
		{
			PaticlePrefabInstancecs[] componentsInChildren = playerObj.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
			foreach (PaticlePrefabInstancecs instance in componentsInChildren)
			{
				MonoBehaviourSingleton<ParticleEffectManager>.Instance.RegisterParticleInstance(instance, PaticleInstanceType.player, playerName);
			}
		}
	}

	public static void InitSceneParticle(GameObject sceneObj, string assetInfoPath)
	{
		if (!MonoBehaviourSingleton<ParticleEffectManager>.Instance.IsOpen || sceneObj == null || string.IsNullOrEmpty(assetInfoPath))
		{
			return;
		}
		string codeName = "defaultWeaponCodeName";
		string value = null;
		if (assetInfoPath.Contains("/weapon/"))
		{
			if (!_assetInfoPathCache.TryGetValue(assetInfoPath, out value))
			{
				codeName = GetTypeName(assetInfoPath, "/weapon/");
			}
			PaticlePrefabInstancecs[] componentsInChildren = sceneObj.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
			foreach (PaticlePrefabInstancecs instance in componentsInChildren)
			{
				MonoBehaviourSingleton<ParticleEffectManager>.Instance.RegisterParticleInstance(instance, PaticleInstanceType.scene, codeName);
			}
		}
		if (assetInfoPath.Contains("/weaponskin/"))
		{
			if (!_assetInfoPathCache.TryGetValue(assetInfoPath, out value))
			{
				codeName = GetTypeName(assetInfoPath, "/weaponskin/");
			}
			PaticlePrefabInstancecs[] componentsInChildren = sceneObj.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
			foreach (PaticlePrefabInstancecs instance2 in componentsInChildren)
			{
				MonoBehaviourSingleton<ParticleEffectManager>.Instance.RegisterParticleInstance(instance2, PaticleInstanceType.scene, codeName);
			}
		}
		SSJJParticleSystem[] componentsInChildren2 = sceneObj.GetComponentsInChildren<SSJJParticleSystem>(includeInactive: true);
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			componentsInChildren2[i].Play();
		}
	}

	private static string GetTypeName(string path, string matchSign)
	{
		int num = path.IndexOf(matchSign, StringComparison.InvariantCultureIgnoreCase);
		string text = path.Substring(num, path.Length - num);
		text = text.Substring(matchSign.Length, text.Length - matchSign.Length);
		return text.Substring(0, text.IndexOf('/'));
	}
}

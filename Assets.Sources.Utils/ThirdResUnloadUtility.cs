using System.Collections.Generic;
using Assets.Scripts;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Particle.Config;
using Assets.Sources.XmlAsset;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJAsset.AssetLoader.Sound;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJRunTimeDataSample;
using UnityEngine;

namespace Assets.Sources.Utils;

public class ThirdResUnloadUtility
{
	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(ThirdResUnloadUtility));

	private static readonly List<string> DontDestoryWeaponList = new List<string>();

	public static void AddToDontDestoryWeaponList(string weaponName)
	{
		DontDestoryWeaponList.Add(weaponName);
	}

	public static void LoadThirdRes(PlayerEntity playerEntity, IEntitsWeaponInfo weaponInfo, ICareerInfo careerInfo, PlayerSkinInfo playerSkinInfo, WeaponSkinInfo skinInfo)
	{
		if (!RuleUtilty.SupportUnloadThirdRes())
		{
			return;
		}
		LobbyInfoComponent lobbyInfo = Contexts.sharedInstance.battleRoom.lobbyInfo;
		Dictionary<int, List<string>> id2PlayerResDic = lobbyInfo.Id2PlayerResDic;
		Dictionary<int, List<string>> id2WeaponResDic = lobbyInfo.Id2WeaponResDic;
		Dictionary<int, Dictionary<string, string>> id2WeaponSkinResDic = lobbyInfo.Id2WeaponSkinResDic;
		Dictionary<int, List<string>> id2PlayerSkinResDic = lobbyInfo.Id2PlayerSkinResDic;
		int value = playerEntity.entityId.Value;
		if (lobbyInfo.NotBotPlayerEntityLoginInList.Contains(value))
		{
			string name = weaponInfo.Name;
			string name2 = careerInfo.Name;
			AddToDict(name, value, id2WeaponResDic);
			AddToDict(name2, value, id2PlayerResDic);
			if (skinInfo != null)
			{
				AddToDict(skinInfo.Name, name, value, id2WeaponSkinResDic);
			}
			if (playerSkinInfo != null)
			{
				AddToDict(playerSkinInfo.Name, value, id2PlayerSkinResDic);
			}
		}
	}

	public static void ThirdLogOut(int entityId)
	{
		if (RuleUtilty.SupportUnloadThirdRes())
		{
			List<int> notBotPlayerEntiyLoginOutList = Contexts.sharedInstance.battleRoom.lobbyInfo.NotBotPlayerEntiyLoginOutList;
			if (notBotPlayerEntiyLoginOutList.Contains(entityId))
			{
				Contexts.sharedInstance.unload.CreateEntity().AddUnloadThirdRes(Time.frameCount, entityId, newStartUnload: false);
				notBotPlayerEntiyLoginOutList.Remove(entityId);
			}
		}
	}

	public static bool UnloadRes(int entityId)
	{
		LobbyInfoComponent lobbyInfo = Contexts.sharedInstance.battleRoom.lobbyInfo;
		Dictionary<int, List<string>> id2PlayerResDic = lobbyInfo.Id2PlayerResDic;
		Dictionary<int, List<string>> id2WeaponResDic = lobbyInfo.Id2WeaponResDic;
		Dictionary<int, Dictionary<string, string>> id2WeaponSkinResDic = lobbyInfo.Id2WeaponSkinResDic;
		Dictionary<int, List<string>> id2PlayerSkinResDic = lobbyInfo.Id2PlayerSkinResDic;
		List<string> resList = GetResList(entityId, id2PlayerResDic);
		List<string> resList2 = GetResList(entityId, id2WeaponResDic);
		Dictionary<string, string> resDictionary = GetResDictionary(entityId, id2WeaponSkinResDic);
		List<string> resList3 = GetResList(entityId, id2PlayerSkinResDic);
		UnloadPlayers(entityId, resList);
		UnloadPlayerSkins(entityId, resList3);
		UnloadWeaponSkins(entityId, resDictionary);
		return UnloadWeapons(entityId, resList2);
	}

	public static bool UnloadWeapons(int entityId, List<string> list)
	{
		List<string> unUseList = GetUnUseList(entityId, list, Contexts.sharedInstance.battleRoom.lobbyInfo.Id2WeaponResDic, DontDestoryWeaponList);
		foreach (string item in unUseList)
		{
			UnloadWeapon(item);
			Contexts.sharedInstance.unload.unloadThirdWeaponResEntity.unloadThirdWeaponRes.RecircleWeapons?.Remove(item);
		}
		return unUseList.Count > 0;
	}

	public static void UnloadWeapon(string weapon)
	{
		if (DontDestoryWeaponList.Contains(weapon))
		{
			return;
		}
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weapon);
		if (weaponInfo == null)
		{
			return;
		}
		foreach (AssetInfo unloadAssetInfo in weaponInfo.GetUnloadAssetInfos())
		{
			CommonUnloadRes(unloadAssetInfo);
		}
		object orNull = Contexts.sharedInstance.battleRoom.assetPool.Pool.GetOrNull(new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ParticleXmlAssetName, typeof(ParticleXmlAsset)));
		if (orNull is ParticleXmlAsset)
		{
			foreach (BaseEffectData item in (orNull as ParticleXmlAsset).List)
			{
				CommonUnloadRes(item.ParticleAssetInfo);
				CommonUnloadRes(item.AssetInfo);
			}
		}
		foreach (AssetInfo unloadUiAssetInfo in weaponInfo.GetUnloadUiAssetInfos())
		{
			CommonUnloadRes(unloadUiAssetInfo);
		}
		foreach (AssetInfo unloadAudioAssetInfo in weaponInfo.GetUnloadAudioAssetInfos())
		{
			CommonUnloadRes(unloadAudioAssetInfo);
			SoundAssetCache.UnloadClip(unloadAudioAssetInfo);
		}
		MonoBehaviourSingleton<GarbageDestoryer>.Instance.UnloadAssetBundle(weaponInfo.AssetBundleName);
	}

	public static void UnloadWeaponSkins(int entityId, Dictionary<string, string> weaponSkins)
	{
		foreach (KeyValuePair<string, string> item in GetUnUseDictionary(entityId, weaponSkins, Contexts.sharedInstance.battleRoom.lobbyInfo.Id2WeaponSkinResDic, null))
		{
			WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(item.Key);
			if (skinInfo == null)
			{
				continue;
			}
			foreach (AssetInfo unloadAssetInfo in skinInfo.GetUnloadAssetInfos(item.Value))
			{
				CommonUnloadRes(unloadAssetInfo);
			}
			MonoBehaviourSingleton<GarbageDestoryer>.Instance.UnloadAssetBundle("weaponskin/" + skinInfo.Name);
		}
	}

	public static void UnloadPlayerSkins(int entityId, List<string> list)
	{
		foreach (string unUse in GetUnUseList(entityId, list, Contexts.sharedInstance.battleRoom.lobbyInfo.Id2PlayerSkinResDic, null))
		{
			PlayerSkinInfo skinInfo = PlayerSkinInfoFactory.Instance.GetSkinInfo(unUse);
			if (skinInfo == null)
			{
				continue;
			}
			foreach (AssetInfo unloadAssetInfo in skinInfo.GetUnloadAssetInfos())
			{
				CommonUnloadRes(unloadAssetInfo);
			}
			MonoBehaviourSingleton<GarbageDestoryer>.Instance.UnloadAssetBundle(skinInfo.ThirdModelAsset.BundleName);
		}
	}

	public static void UnloadPlayers(int entityId, List<string> list)
	{
		foreach (string unUse in GetUnUseList(entityId, list, Contexts.sharedInstance.battleRoom.lobbyInfo.Id2PlayerResDic, null))
		{
			ICareerInfo careerInfo = CareerInfoFactory.Instance.GetCareerInfo(unUse);
			if (careerInfo == null)
			{
				continue;
			}
			foreach (AssetInfo unloadAssetInfo in careerInfo.GetUnloadAssetInfos())
			{
				CommonUnloadRes(unloadAssetInfo);
			}
			MonoBehaviourSingleton<GarbageDestoryer>.Instance.UnloadAssetBundle(careerInfo.PrefabBundleName);
		}
	}

	private static void CommonUnloadRes(AssetInfo info)
	{
		Contexts.sharedInstance.battleRoom.gameObjectPool.Pool.Delete(info);
		MonoBehaviourSingleton<GarbageDestoryer>.Instance.RemoveLinker(info);
		if (SingletonInstance<DataSampleContexts>.Instance.UnloadThirdResAction != null)
		{
			SingletonInstance<DataSampleContexts>.Instance.UnloadThirdResAction(info);
		}
	}

	private static List<string> GetUnUseList(int entityId, List<string> list, Dictionary<int, List<string>> dictionary, List<string> dontDestoryList)
	{
		List<string> list2 = new List<string>();
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = true;
				foreach (KeyValuePair<int, List<string>> item in dictionary)
				{
					if (item.Key != entityId && item.Value.Contains(list[i]))
					{
						flag = false;
						break;
					}
				}
				if (flag && (dontDestoryList == null || !dontDestoryList.Contains(list[i])))
				{
					list2.Add(list[i]);
				}
			}
		}
		dictionary.Remove(entityId);
		return list2;
	}

	private static Dictionary<string, string> GetUnUseDictionary(int entityId, Dictionary<string, string> dic, Dictionary<int, Dictionary<string, string>> allDictionary, List<string> dontDestoryList)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (dic != null)
		{
			foreach (KeyValuePair<string, string> item in dic)
			{
				bool flag = true;
				foreach (KeyValuePair<int, Dictionary<string, string>> item2 in allDictionary)
				{
					if (item2.Key != entityId && item2.Value.ContainsKey(item.Key))
					{
						flag = false;
						break;
					}
				}
				if (flag && (dontDestoryList == null || !dontDestoryList.Contains(item.Key)))
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
		}
		allDictionary.Remove(entityId);
		return dictionary;
	}

	private static List<string> GetResList(int entity, Dictionary<int, List<string>> dictionary)
	{
		dictionary.TryGetValue(entity, out var value);
		return value;
	}

	private static Dictionary<string, string> GetResDictionary(int entity, Dictionary<int, Dictionary<string, string>> dictionary)
	{
		dictionary.TryGetValue(entity, out var value);
		return value;
	}

	private static void AddToDict(string sign, int entityId, Dictionary<int, List<string>> dictionary)
	{
		if (!dictionary.TryGetValue(entityId, out var value))
		{
			value = new List<string> { sign };
			dictionary.Add(entityId, value);
		}
		else if (!value.Contains(sign))
		{
			value.Add(sign);
		}
	}

	private static void AddToDict(string signKey, string signValue, int entityId, Dictionary<int, Dictionary<string, string>> dictionary)
	{
		if (!dictionary.TryGetValue(entityId, out var value))
		{
			value = new Dictionary<string, string>();
			value.Add(signKey, signValue);
			dictionary.Add(entityId, value);
		}
		else if (!value.ContainsKey(signKey))
		{
			value.Add(signKey, signValue);
		}
	}
}

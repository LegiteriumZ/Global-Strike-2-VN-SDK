using System;
using System.Collections.Generic;
using Assets.Scripts.Utility.Pool;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Pool;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Scripts.Utility;

public class ForceUnloadResUtility
{
	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(ForceUnloadResUtility));

	public static void UnloadRes()
	{
		Logger.Info("Before UnloadRes >> " + TotalMemoryUtility.GetCurrentMemory() + " AllGameObject >> " + TotalMemoryUtility.GetAllObjects().Count + " Particle >>  " + TotalMemoryUtility.GetAllParticles());
		GC.Collect();
		Resources.UnloadUnusedAssets();
		UnityGameObjectPool unityGameObjectPool = Contexts.sharedInstance.battleRoom.gameObjectPool.Pool as UnityGameObjectPool;
		foreach (KeyValuePair<AssetInfo, StackObjectPool<GameObject>> poo in unityGameObjectPool.Poos)
		{
			int count = poo.Value.Count();
			AssetInfo key = poo.Key;
			unityGameObjectPool.UnloadImmediate(key, count);
			CommonUnloadRes(key);
		}
		GC.Collect();
		Resources.UnloadUnusedAssets();
		Logger.Info("After UnloadRes >> " + TotalMemoryUtility.GetCurrentMemory() + " AllGameObject >> " + TotalMemoryUtility.GetAllObjects().Count + " Particle >>  " + TotalMemoryUtility.GetAllParticles());
	}

	private static void CommonUnloadRes(AssetInfo info)
	{
		Contexts.sharedInstance.battleRoom.gameObjectPool.Pool.Delete(info);
		MonoBehaviourSingleton<GarbageDestoryer>.Instance.RemoveLinker(info, isAlsoUnloadAb: true);
	}
}

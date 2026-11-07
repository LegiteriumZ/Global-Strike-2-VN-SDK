using System.Collections.Generic;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Pool;
using SSJJBase.Singleton;
using SSJJRunTimeDataSample;
using UnityEngine;

namespace Assets.Scripts.Utility.Pool;

public abstract class AbstractUnityObjectPool<PT, T> : MonoBehaviourSingleton<PT> where PT : MonoBehaviour where T : Object
{
	private readonly Dictionary<AssetInfo, StackObjectPool<T>> _poolDict = new Dictionary<AssetInfo, StackObjectPool<T>>();

	public Dictionary<AssetInfo, StackObjectPool<T>> Poos => _poolDict;

	public virtual void Add(AssetInfo key, T go)
	{
		StackObjectPool<T> stackObjectPool = _poolDict.GetOrDefault(key);
		if (stackObjectPool == null)
		{
			stackObjectPool = new StackObjectPool<T>();
			_poolDict.Add(key, stackObjectPool);
		}
		stackObjectPool.Add(go);
		if (SingletonInstance<DataSampleContexts>.Instance.GameObjectExistRefreshAction != null)
		{
			SingletonInstance<DataSampleContexts>.Instance.GameObjectExistRefreshAction(go, key);
		}
	}

	public virtual T GetOrNull(AssetInfo key)
	{
		StackObjectPool<T> orDefault = _poolDict.GetOrDefault(key);
		if (orDefault == null)
		{
			return null;
		}
		return orDefault.GetOrNull();
	}

	public bool Exists(AssetInfo key)
	{
		StackObjectPool<T> orDefault = _poolDict.GetOrDefault(key);
		if (orDefault == null)
		{
			return false;
		}
		return orDefault.Count() > 0;
	}

	public void Delete(AssetInfo key)
	{
		StackObjectPool<T> orDefault = _poolDict.GetOrDefault(key);
		if (orDefault == null)
		{
			return;
		}
		foreach (T item in orDefault.GetAll())
		{
			Object.Destroy(item);
		}
		orDefault.Clear();
	}

	public void Unload(AssetInfo info, int count)
	{
		for (int i = 0; i < count; i++)
		{
			Unload(info);
		}
		if (SingletonInstance<DataSampleContexts>.Instance.UnloadGameDataAction != null)
		{
			SingletonInstance<DataSampleContexts>.Instance.UnloadGameDataAction(info, count);
		}
	}

	public void UnloadImmediate(AssetInfo info, int count)
	{
		for (int i = 0; i < count; i++)
		{
			UnloadImmediate(info);
		}
	}

	public abstract void Unload(AssetInfo info);

	public abstract void UnloadImmediate(AssetInfo info);
}

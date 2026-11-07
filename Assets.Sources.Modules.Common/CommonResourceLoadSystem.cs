using System;
using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJRunTimeDataSample;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Modules.Common;

public class CommonResourceLoadSystem : IResourceLoadSystem
{
	private readonly IContextResourceInfo _resourceInfo;

	private IAssetPool _assetPool;

	private IGameObjectPool _gameObjectPool;

	private GameObject _parent;

	private Dictionary<int, float> _resCost = new Dictionary<int, float>();

	public CommonResourceLoadSystem(Contexts contexts, IContextResourceInfo resourceInfo)
	{
		_resourceInfo = resourceInfo;
		_assetPool = contexts.battleRoom.assetPool.Pool;
		_gameObjectPool = contexts.battleRoom.gameObjectPool.Pool;
		_parent = new GameObject("CommonResource");
	}

	private void EndLoad(IEntity entity, int componentId, string assetInfo)
	{
		int key = entity.GetHashCode() + componentId * 31;
		float value = 0f;
		if (_resCost.TryGetValue(key, out value))
		{
			_resCost.Remove(key);
		}
	}

	private void UpdateLoadCheck(IEntity entity, int componentId, string assetInfo)
	{
		int key = entity.GetHashCode() + componentId * 31;
		float value = 0f;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (_resCost.TryGetValue(key, out value))
		{
			if (realtimeSinceStartup - value > 10f)
			{
				this.LogErrorFormat("Load Res {0}, Cost Much Time !", assetInfo);
				_resCost.Remove(key);
			}
		}
		else
		{
			_resCost.Add(key, realtimeSinceStartup);
		}
	}

	private object GetObject(AssetInfo assetInfo)
	{
		object obj = _gameObjectPool.GetOrNull(assetInfo);
		if (obj == null)
		{
			obj = _assetPool.GetOrNull(assetInfo);
			if (obj is GameObject)
			{
				obj = (obj as GameObject).CreateInstance();
			}
		}
		if (obj != null && obj is GameObject)
		{
			(obj as GameObject).transform.parent = _parent.transform;
			(obj as GameObject).SetObjectActive(isactive: false);
		}
		if (SingletonInstance<DataSampleContexts>.Instance.GameObjectExistRefreshAction != null)
		{
			SingletonInstance<DataSampleContexts>.Instance.GameObjectExistRefreshAction(obj, assetInfo);
		}
		return obj;
	}

	private static void UpdateMaterial(UnityEngine.Object unityasset)
	{
		if (!(unityasset is Graphic) && !(unityasset is Renderer))
		{
			_ = unityasset is GameObject;
		}
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (IEntity loadResourceEntity in _resourceInfo.LoadResourceEntities)
		{
			for (int i = 0; i < _resourceInfo.LoadComponentIds.Length; i++)
			{
				try
				{
					int index = _resourceInfo.LoadComponentIds[i];
					int unityCompId = _resourceInfo.UnityComponentIds[i];
					if (!loadResourceEntity.HasComponent(index))
					{
						continue;
					}
					ILoadUnityObjectsComponent loadUnityObjectsComponent = loadResourceEntity.GetComponent(index) as ILoadUnityObjectsComponent;
					int count = loadUnityObjectsComponent.LoadRequests.Count;
					int num = 0;
					bool flag = false;
					foreach (LoadRequests.MultiTV loadRequest in loadUnityObjectsComponent.LoadRequests)
					{
						LoadRequest value = loadRequest.Value;
						if (_gameObjectPool.Exists(value.AssetInfo))
						{
							num++;
						}
						else if (_assetPool.GetOrNull(value.AssetInfo) != null)
						{
							num++;
						}
						else if (_assetPool.IsLoadFailed(value.AssetInfo))
						{
							if (!value.AssetInfo.Optional)
							{
								flag = true;
								break;
							}
							num++;
						}
						else
						{
							_assetPool.LoadAndAdd(value.AssetInfo, coRoutineManager);
						}
					}
					if (flag)
					{
						loadResourceEntity.RemoveComponent(index);
					}
					if (num != count)
					{
						continue;
					}
					LoadResults loadResults = new LoadResults(count + 1);
					foreach (LoadRequests.MultiTV loadRequest2 in loadUnityObjectsComponent.LoadRequests)
					{
						object @object = GetObject(loadRequest2.Value.AssetInfo);
						if (@object == null)
						{
							continue;
						}
						if (@object is GameObject && loadRequest2.Value.ReusableType != null)
						{
							GameObject gameObject = (GameObject)@object;
							if (gameObject.GetComponent(loadRequest2.Value.ReusableType) == null)
							{
								((IReusableGameObject)gameObject.AddComponent(loadRequest2.Value.ReusableType)).Init(loadRequest2.Value.AssetInfo, gameObject);
							}
						}
						int num2 = 0;
						if (loadRequest2.IntKey.HasValue)
						{
							loadResults[loadRequest2.IntKey.Value] = new LoadResult(loadResults, loadRequest2.IntKey, loadRequest2.Value.AssetInfo, @object);
							num2++;
						}
						if (!string.IsNullOrEmpty(loadRequest2.StringKey))
						{
							loadResults[loadRequest2.StringKey] = new LoadResult(loadResults, loadRequest2.StringKey, loadRequest2.Value.AssetInfo, @object);
							num2++;
						}
						_ = 1;
					}
					InitComponent(unityCompId, loadResourceEntity, loadResults, loadUnityObjectsComponent.Identifier);
					loadResourceEntity.RemoveComponent(index);
				}
				catch (Exception args)
				{
					this.LogErrorFormat("LoadResource exception {0}", args);
				}
			}
		}
	}

	private void InitComponent(int unityCompId, IEntity entity, LoadResults results, object identifier)
	{
		Type type = _resourceInfo.ComponentTypes[unityCompId];
		if (entity.HasComponent(unityCompId))
		{
			entity.RemoveComponent(unityCompId);
		}
		IComponent component = entity.CreateComponent(unityCompId, type);
		((IUnityObjectsComponent)component).LoadResults = results;
		((IUnityObjectsComponent)component).Identifier = identifier;
		entity.AddComponent(unityCompId, component);
	}
}

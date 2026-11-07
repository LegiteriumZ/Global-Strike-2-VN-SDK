using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Modules.Common;

public class CommonResourceDestroySystem : IEntityDestroySystem
{
	private readonly IContextDestroyInfo _destroyInfo;

	private readonly IContextResourceInfo _resourceInfo;

	private IGameObjectPool _gameObjectPool;

	public CommonResourceDestroySystem(Contexts contexts, IContextResourceInfo resourceInfo, IContextDestroyInfo destroyInfo)
	{
		_resourceInfo = resourceInfo;
		_destroyInfo = destroyInfo;
		_gameObjectPool = contexts.battleRoom.gameObjectPool.Pool;
	}

	public void OnEntityDestroy()
	{
		foreach (IEntity destoryEntity in _destroyInfo.DestoryEntities)
		{
			int[] unityComponentIds = _resourceInfo.UnityComponentIds;
			foreach (int compId in unityComponentIds)
			{
				Clean(destoryEntity, compId);
			}
		}
	}

	private void Clean(IEntity entity, int compId)
	{
		if (!entity.HasComponent(compId))
		{
			return;
		}
		foreach (KeyValuePair<AssetInfo, GameObject> reusableGameObject in (entity.GetComponent(compId) as IReusableGameObjects).GetReusableGameObjects())
		{
			_gameObjectPool.Add(reusableGameObject.Key, reusableGameObject.Value);
		}
		entity.RemoveComponent(compId);
	}
}

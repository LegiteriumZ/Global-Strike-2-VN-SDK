using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.MoveObject;
using Assets.Sources.Components.Interface.SceneBuffAttach;
using Assets.Sources.Framework;
using Assets.Sources.Info.MoveObject;
using Assets.Sources.Info.SceneBuffAttach;
using Assets.Sources.Utils;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.MoveObject;

internal class MoveObjectInitSystem : IPlaybackInitSystem
{
	private readonly IGroup<SceneObjectEntity> _moveObjects;

	private readonly IGroup<SceneObjectEntity> _sceneBufferMoveObjects;

	private readonly SceneObjectContext _sceneObjectContext;

	private readonly SnapshotContext _snapshotContext;

	public MoveObjectInitSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_moveObjects = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.MoveObject).NoneOf(SceneObjectMatcher.Destroy));
		_sceneBufferMoveObjects = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneBuffAttach).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlaybackInit()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null || nextSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, MoveEntityData> item in nowSnapshot.MoveEntityDataDict)
		{
			MoveEntityData value = item.Value;
			nextSnapshot.MoveEntityDataDict.TryGetValue(value.Id, out var value2);
			if (value2 == null)
			{
				value2 = value;
			}
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.GetEntityWithEntityId(value.Id);
			if (sceneObjectEntity == null)
			{
				sceneObjectEntity = _sceneObjectContext.CreateEntity();
				sceneObjectEntity.AddEtype(6);
				sceneObjectEntity.AddEntityId(value.Id);
				sceneObjectEntity.AddPosition(Vector3.zero);
				sceneObjectEntity.AddRotation(Vector3.zero);
				if (value.Scale > 0f)
				{
					sceneObjectEntity.AddScale(new Vector3(value.Scale, value.Scale, value.Scale));
				}
				else
				{
					sceneObjectEntity.AddScale(new Vector3(1f, 1f, 1f));
				}
				if (value.ScaleX > 0f)
				{
					sceneObjectEntity.scale.Scale.x *= value.ScaleX;
				}
				if (value.ScaleY > 0f)
				{
					sceneObjectEntity.scale.Scale.z *= value.ScaleY;
				}
				if (value.ScaleZ > 0f)
				{
					sceneObjectEntity.scale.Scale.y *= value.ScaleZ;
				}
				if (value.Name == "freemove" || value.Name == "freecube")
				{
					sceneObjectEntity.AddMoveObject(value, value2, null, Vector3.zero, value.Name);
				}
				else
				{
					IMoveObjectInfo moveObjectInfo = BattleSingletonInstance<MoveObjectInfoFactory>.Instance.GetMoveObjectInfo(value);
					sceneObjectEntity.AddMoveObject(value, value2, moveObjectInfo, Vector3.zero, value.Name);
					sceneObjectEntity.moveObject.Info.InitEntity(sceneObjectEntity);
				}
				MoveEntityAttach(value.Name, value.Id, value);
			}
			sceneObjectEntity.moveObject.Current = value;
			sceneObjectEntity.moveObject.Next = value2;
		}
		foreach (SceneObjectEntity moveObject in _moveObjects)
		{
			if (!nowSnapshot.MoveEntityDataDict.ContainsKey(moveObject.entityId.Value) && !moveObject.hasGravityTailHide)
			{
				if (moveObject.hasAddParticleLod && moveObject.hasUnityObjects && moveObject.unityObjects.LoadResults != null && moveObject.unityObjects.LoadResults.ContainsKey(0))
				{
					LodUtility.RemoveInstanceLod(moveObject.unityObjects.LoadResults[0].GameObject);
				}
				moveObject.isDestroy = true;
			}
			else if (moveObject.moveObject.Current.Name != moveObject.moveObject.Next.Name || moveObject.moveObject.Current.Name != moveObject.moveObject.CurrentName)
			{
				moveObject.isDestroy = true;
			}
		}
		foreach (SceneObjectEntity sceneBufferMoveObject in _sceneBufferMoveObjects)
		{
			if (sceneBufferMoveObject.sceneBuffAttach.MoveEntityData == null)
			{
				continue;
			}
			foreach (KeyValuePair<int, MoveEntityData> item2 in nowSnapshot.MoveEntityDataDict)
			{
				MoveEntityData value3 = item2.Value;
				if (value3.Id == sceneBufferMoveObject.sceneBuffAttach.MoveEntityData.Id)
				{
					sceneBufferMoveObject.sceneBuffAttach.MoveEntityData = value3;
					break;
				}
			}
		}
	}

	private void MoveEntityAttach(string moveEntityName, int entityId, MoveEntityData data)
	{
		ISceneBuffAttach buffAttach = SingletonInstance<SceneBufferAttachFactory>.Instance.GetBuffAttach(moveEntityName);
		if (buffAttach != null)
		{
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
			sceneObjectEntity.AddSceneBuffAttach(entityId, buffAttach, data);
			sceneObjectEntity.AddPosition(Vector3.zero);
			sceneObjectEntity.AddScale(Vector3.one);
			sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(buffAttach.GetEffectAssetInfo()), moveEntityName + "SceneAttach");
		}
	}
}

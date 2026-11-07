using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.CameraEntity;

public class CameraEntitySystem : IPlaybackSystem, IEntityCreateSystem
{
	private SnapshotContext _snapshotContext;

	private SceneObjectContext _sceneObjectContext;

	private TimeComponent _time;

	private IGroup<SceneObjectEntity> _group;

	public CameraEntitySystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_time = contexts.time.time;
		_group = _sceneObjectContext.GetGroup(SceneObjectMatcher.CameraObject);
	}

	public void OnPlayback()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, CameraEntityData> item in nowSnapshot.CameraEntityDataDict)
		{
			CameraEntityData value = item.Value;
			CameraEntityData value2 = null;
			nextSnapshot?.CameraEntityDataDict.TryGetValue(item.Key, out value2);
			if (value2 == null)
			{
				value2 = value;
			}
			SceneObjectEntity sceneObjectEntity = _sceneObjectContext.GetEntityWithEntityId(item.Key);
			if (sceneObjectEntity == null)
			{
				sceneObjectEntity = _sceneObjectContext.CreateEntity();
				sceneObjectEntity.AddEntityId(item.Key);
				sceneObjectEntity.AddCameraObject(null, null);
				sceneObjectEntity.AddPosition(Vector3.zero);
				sceneObjectEntity.AddRotation(Vector3.zero);
			}
			sceneObjectEntity.cameraObject.Current = value;
			sceneObjectEntity.cameraObject.Next = value2;
			sceneObjectEntity.position.Origin = Vector3.Lerp(new Vector3(value.X, value.Y, value.Z), new Vector3(value2.X, value2.Y, value2.Z), _time.FrameInterpolation);
			float z = Mathf.Lerp(value.Yaw, value2.Yaw, _time.FrameInterpolation);
			float y = Mathf.Lerp(value.Pitch, value2.Pitch, _time.FrameInterpolation);
			sceneObjectEntity.rotation.EulerAngles = new Vector3(0f, y, z);
		}
	}

	public void OnEntityCreate()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		foreach (SceneObjectEntity item in _group)
		{
			if (!nowSnapshot.CameraEntityDataDict.ContainsKey(item.entityId.Value))
			{
				item.isDestroy = true;
			}
		}
	}
}

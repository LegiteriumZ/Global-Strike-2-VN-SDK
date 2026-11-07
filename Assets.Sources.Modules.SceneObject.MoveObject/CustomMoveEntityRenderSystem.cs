using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using NetData;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.MoveObject;

internal class CustomMoveEntityRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	private readonly SnapshotContext _snapshotContext;

	private readonly TimeContext _timeContext;

	public CustomMoveEntityRenderSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_timeContext = contexts.time;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.CustomMoveEntity, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Rotation, SceneObjectMatcher.Position).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null || nextSnapshot == null)
		{
			return;
		}
		foreach (SceneObjectEntity item in _group)
		{
			float timedelta = Mathf.Lerp(nowSnapshot.ServerTime, nextSnapshot.ServerTime, _timeContext.time.FrameInterpolation);
			Update(item, timedelta);
		}
	}

	private void Update(SceneObjectEntity moveentity, float timedelta)
	{
		CustomMoveEntityData data = moveentity.customMoveEntity.Data;
		if (moveentity.unityObjects.LoadResults == null || moveentity.unityObjects.LoadResults.Count <= 0)
		{
			return;
		}
		GameObject gameObject = moveentity.unityObjects.LoadResults[0].GameObject;
		if (gameObject != null)
		{
			Vector3 vector = new Vector3(data.X, data.Y, data.Z);
			Vector3 vector2 = new Vector3(data.DirX, data.DirY, data.DirZ);
			Vector3 inv = moveentity.position.Origin;
			int num = Mathf.Max(0, _timeContext.time.RenderTime - data.CreateTime);
			if (num > 0)
			{
				float num2 = (float)num * 0.001f * data.Speed;
				inv = vector + vector2 * num2;
			}
			Vector3 vector3 = VectorCoordConverter.SsjjRotationToUnity(vector2);
			Vector3 position = VectorCoordConverter.SsjjToUnity(inv);
			Vector3 localScale = VectorCoordConverter.SsjjScaleToUnity(moveentity.scale.Scale);
			gameObject.transform.localScale = localScale;
			gameObject.transform.position = position;
			gameObject.transform.rotation = Quaternion.LookRotation(-vector3);
			gameObject.transform.localEulerAngles = new Vector3(0f - moveentity.customMoveEntity.PitchTrim + gameObject.transform.localEulerAngles.x, moveentity.customMoveEntity.YawTrim + gameObject.transform.localEulerAngles.y, gameObject.transform.localEulerAngles.z);
			if (!moveentity.hasAddParticleLod)
			{
				moveentity.AddAddParticleLod(newIsAdd: true);
				LodUtility.AddInstanceLod(gameObject);
			}
		}
	}
}

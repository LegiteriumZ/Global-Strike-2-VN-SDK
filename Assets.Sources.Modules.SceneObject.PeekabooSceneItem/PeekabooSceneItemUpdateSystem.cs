using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PeekabooSceneItem;

public class PeekabooSceneItemUpdateSystem : IPlaybackSystem
{
	private MessageContext _msgContext;

	private SnapshotContext _snapContext;

	private TimeComponent _time;

	private IGroup<SceneObjectEntity> _group;

	public PeekabooSceneItemUpdateSystem(Contexts contexts)
	{
		_snapContext = contexts.snapshot;
		_msgContext = contexts.message;
		_time = contexts.time.time;
		SceneObjectContext sceneObject = contexts.sceneObject;
		_group = sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PeekabooSceneItem).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		if (_msgContext.peekabooMessageData.sceneItems == null)
		{
			return;
		}
		ISnapshot nowSnapshot = _snapContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapContext.snapshots.NextSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		foreach (SceneObjectEntity item in _group)
		{
			SceneItemEntityData value = null;
			bool flag = false;
			_msgContext.peekabooMessageData.sceneItems.TryGetValue(item.entityId.Value, out var value2);
			if (value2 == null)
			{
				nowSnapshot.SceneItemEntityDataDict.TryGetValue(item.entityId.Value, out value2);
				nextSnapshot?.SceneItemEntityDataDict.TryGetValue(item.entityId.Value, out value);
				flag = true;
			}
			if (value2 != null)
			{
				if (value == null)
				{
					value = value2;
				}
				item.peekabooSceneItem.Data.EType = value2.EType;
				item.position.Origin = Vector3.Lerp(new Vector3(value2.X, value2.Y, value2.Z), new Vector3(value.X, value.Y, value.Z), _time.FrameInterpolation);
				float x = InterpolateUtility.LinearInterpolateAngel(value2.RotationX, value.RotationX, _time.FrameInterpolation);
				float num = InterpolateUtility.LinearInterpolateAngel(value2.RotationZ, value.RotationZ, _time.FrameInterpolation);
				float y = InterpolateUtility.LinearInterpolateAngel(value2.RotationY, value.RotationY, _time.FrameInterpolation);
				if (flag)
				{
					num += 90f;
				}
				item.rotation.EulerAngles = new Vector3(x, y, num);
			}
		}
		foreach (SceneObjectEntity item2 in _group)
		{
			bool num2 = _msgContext.peekabooMessageData.sceneItems.ContainsKey(item2.entityId.Value);
			bool flag2 = nowSnapshot.SceneItemEntityDataDict.ContainsKey(item2.entityId.Value);
			if (!num2 && !flag2)
			{
				item2.isDestroy = true;
			}
		}
	}
}

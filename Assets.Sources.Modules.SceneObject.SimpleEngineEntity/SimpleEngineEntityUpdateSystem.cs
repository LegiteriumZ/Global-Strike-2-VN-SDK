using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SimpleEngineEntity;

internal class SimpleEngineEntityUpdateSystem : IPlaybackSystem
{
	private SnapshotContext _snapshotContext;

	private SceneObjectContext _sceneObjectContext;

	private TimeComponent _time;

	private IGroup<SceneObjectEntity> _group;

	public SimpleEngineEntityUpdateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_time = contexts.time.time;
		_group = _sceneObjectContext.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SimpleEngineEntity, SceneObjectMatcher.Position, SceneObjectMatcher.Rotation).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot snapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		if (snapshot == null)
		{
			snapshot = nowSnapshot;
		}
		foreach (SceneObjectEntity item in _group)
		{
			nowSnapshot.SimpleEngineEntityDataDict.TryGetValue(item.simpleEngineEntity.data.Id, out var value);
			snapshot.SimpleEngineEntityDataDict.TryGetValue(item.simpleEngineEntity.data.Id, out var value2);
			if (value == null)
			{
				continue;
			}
			if (value2 == null)
			{
				value2 = value;
			}
			float frameInterpolation = _time.FrameInterpolation;
			float x = InterpolateUtility.LinearInterpolate(value.X, value2.X, frameInterpolation);
			float y = InterpolateUtility.LinearInterpolate(value.Y, value2.Y, frameInterpolation);
			float z = InterpolateUtility.LinearInterpolate(value.Z, value2.Z, frameInterpolation);
			Quaternion a = Quaternion.Euler(VectorCoordConverter.SsjjRotationToUnity(new Vector3(value.RotationX, value.RotationY, value.RotationZ)));
			Quaternion b = Quaternion.Euler(VectorCoordConverter.SsjjRotationToUnity(new Vector3(value2.RotationX, value2.RotationY, value2.RotationZ)));
			Quaternion quaternion = Quaternion.Lerp(a, b, frameInterpolation);
			item.position.Origin = new Vector3(x, y, z);
			item.rotation.EulerAngles = new Vector3(0f - quaternion.eulerAngles.z, quaternion.eulerAngles.x, 0f - quaternion.eulerAngles.y);
			item.simpleEngineEntity.data.Hp = value.Hp;
			item.simpleEngineEntity.data.MaxHp = value.MaxHp;
			item.simpleEngineEntity.data.IsStandPlayer = value.IsStandPlayer;
			if (item.hasUpdateColor)
			{
				float num = (float)item.simpleEngineEntity.data.Hp / (float)item.simpleEngineEntity.data.MaxHp;
				if ((double)num > 0.5)
				{
					item.updateColor.ToColor = item.updateColor.OriginColor;
				}
				else if ((double)num > 0.2)
				{
					item.updateColor.ToColor = new Color(1f, 0.72f, 0.444f, 1f);
				}
				else if (num > 0f)
				{
					item.updateColor.ToColor = new Color(1f, 0.5f, 0.5f, 1f);
				}
			}
		}
	}
}

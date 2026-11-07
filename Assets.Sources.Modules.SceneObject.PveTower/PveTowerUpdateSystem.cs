using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PveTower;

public class PveTowerUpdateSystem : IPlaybackSystem
{
	private SnapshotContext _snapshotContext;

	private IGroup<SceneObjectEntity> _group;

	public PveTowerUpdateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		SceneObjectContext sceneObject = contexts.sceneObject;
		_group = sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PveTower).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		foreach (SceneObjectEntity item in _group)
		{
			nowSnapshot.PveTowerEntityDataDict.TryGetValue(item.entityId.Value, out var value);
			if (value != null)
			{
				item.pveTower.Data.Hp = value.Hp;
				item.pveTower.Data.EType = value.EType;
				item.pveTower.Data.MaxHp = value.MaxHp;
				item.pveTower.Data.State = value.State;
				if (value.Flag > 0)
				{
					item.pveTower.Data.Flag = value.Flag;
				}
				item.position.Origin = new Vector3(value.X, value.Y, value.Z);
				item.rotation.EulerAngles = new Vector3(value.RotationX, 0f, value.RotationZ);
			}
		}
		foreach (SceneObjectEntity item2 in _group)
		{
			if (!nowSnapshot.PveTowerEntityDataDict.ContainsKey(item2.entityId.Value))
			{
				item2.isDestroy = true;
			}
		}
	}
}

using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using NetData;
using SSJJMath;

namespace Assets.Sources.Modules.SceneObject.BulletRail;

public class BulletRailEntityCreateSystem : IPlaybackInitSystem
{
	private readonly SnapshotContext _snapshotContext;

	private readonly SceneObjectContext _bulletRailContext;

	public BulletRailEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_bulletRailContext = contexts.sceneObject;
	}

	public void OnPlaybackInit()
	{
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, BulletRailEventEntityData> item in latestSnapshot.BulletRailEventEntityDataDict)
		{
			BulletRailEventEntityData value = item.Value;
			SceneObjectEntity entityWithEntityId = _bulletRailContext.GetEntityWithEntityId(value.BaseEventEntity.Id);
			if (entityWithEntityId == null)
			{
				((value.BaseEventEntity.EventId == 22) ? SceneObjectFactory.Instance.CreateBowRailEntity(value.BaseEventEntity.OwnerId, VectorTypeConverter.Net2Unity(value.StartPos), VectorTypeConverter.Net2Unity(value.EndPos), value.ResTypeID, value.BaseEventEntity.EventId) : SceneObjectFactory.Instance.CreateBulletRailEntity(value.BaseEventEntity.OwnerId, VectorTypeConverter.Net2Unity(value.StartPos), VectorTypeConverter.Net2Unity(value.EndPos), value.ResTypeID, value.BaseEventEntity.EventId))?.AddEntityId(value.BaseEventEntity.Id);
			}
		}
	}
}

using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.SceneObject.BulletHole;

public class BulletHoleEntityCreateSystem : IEntityCreateSystem
{
	private readonly SnapshotContext _snapshotContext;

	private readonly SceneObjectContext _sceneObjectContext;

	private readonly BattleServerContext _battleServerContext;

	private readonly PlayerContext _playerContext;

	public BulletHoleEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneObjectContext = contexts.sceneObject;
		_battleServerContext = contexts.battleServer;
		_playerContext = contexts.player;
	}

	public void OnEntityCreate()
	{
		if (!_playerContext.isMyPlayer || !_snapshotContext.hasSnapshots)
		{
			return;
		}
		foreach (ISnapshot snapshot in _snapshotContext.snapshots.SnapshotList)
		{
			if (snapshot.BulletHoleCreated)
			{
				continue;
			}
			snapshot.BulletHoleCreated = true;
			foreach (KeyValuePair<int, BulletHitWallEventEntityData> item in snapshot.BulletHitWallEventEntityDataDict)
			{
				BulletHitWallEventEntityData value = item.Value;
				if (RuleUtilty.IsFlyingKnife(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType) || _battleServerContext.battleServer.Server.IsInLocalNetwork || value.BaseEventEntity.OwnerId != _playerContext.myPlayerEntity.entityId.Value)
				{
					SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(value.BaseEventEntity.Id);
					if (entityWithEntityId == null)
					{
						SceneObjectFactory.Instance.CreateBulletHoleEntity(value.CollisionPoint, value.CollisionNormal, value.BaseEventEntity.OwnerId, value.ResTypeID, isServer: true)?.AddEntityId(value.BaseEventEntity.Id);
					}
				}
			}
		}
	}
}

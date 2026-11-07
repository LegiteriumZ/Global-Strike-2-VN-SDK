using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject.iTweenMove;
using Assets.Sources.Framework;
using Assets.Sources.Utils.SceneObject;
using Entitas;
using NetData;
using SSJJUserCmd;

namespace Assets.Sources.Modules.SceneObject.iTweenMove;

public class iTweenPredicateSystem : IPredicateSystem
{
	private IGroup<SceneObjectEntity> _group;

	private SnapshotContext _snapshotContext;

	public iTweenPredicateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.iTweenMove, SceneObjectMatcher.Position, SceneObjectMatcher.Rotation, SceneObjectMatcher.TweenMoveHistory));
	}

	private void PredicateEntity(SceneObjectEntity entity, IUserCmd cmd, int clientTime)
	{
		if (entity.hasiTweenMove && cmd.PredicatedOnce)
		{
			return;
		}
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (latestSnapshot == null)
		{
			return;
		}
		int num = 0;
		if (latestSnapshot.SelfClientTimeLastDiff > 0)
		{
			num = latestSnapshot.SelfClientTimeLastDiff - 100;
		}
		int num2 = clientTime - latestSnapshot.SelfClientTime + num;
		int serverTime = latestSnapshot.ServerTime + num2;
		iTweenMoveComponent iTweenMove = entity.iTweenMove;
		if (iTweenMove != null)
		{
			foreach (KeyValuePair<int, SceneItweenEntityData> item in latestSnapshot.SceneItweenEntityDataDict)
			{
				if (entity.entityId.Value == item.Key && item.Value.MoveItweenInfo != null)
				{
					int lastFrameServerTime = item.Value.MoveItweenInfo.LastFrameServerTime + num2;
					iTweenMove.MoveToTweenEntity.SetLastFrameServerTime(lastFrameServerTime);
				}
			}
		}
		entity.tweenMoveHistory.LastOrigin = entity.position.Origin;
		entity.tweenMoveHistory.LastAngle = entity.rotation.EulerAngles;
		iTweenMoveEntityUtility.Update(entity, cmd.FrameInterval, serverTime);
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		foreach (SceneObjectEntity item in _group)
		{
			PredicateEntity(item, cmd, player.clientTime.ClientTime);
		}
	}
}

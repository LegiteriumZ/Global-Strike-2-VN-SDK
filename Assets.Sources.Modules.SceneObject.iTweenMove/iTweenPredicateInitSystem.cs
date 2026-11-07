using Assets.Sources.Framework;
using Assets.Sources.Utils.SceneObject;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.iTweenMove;

public class iTweenPredicateInitSystem : IPredicationInitSystem
{
	private IGroup<SceneObjectEntity> _moveEntityGroup;

	private SnapshotContext _snapshotContext;

	public string LastErrorMsg { get; private set; }

	public iTweenPredicateInitSystem(Contexts contexts)
	{
		_moveEntityGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.iTweenMove, SceneObjectMatcher.TweenMoveHistory));
		_snapshotContext = contexts.snapshot;
	}

	public void OnPredicatoinInit()
	{
		foreach (SceneObjectEntity item in _moveEntityGroup)
		{
			iTweenMoveEntityUtility.Update(item, 0, _snapshotContext.snapshots.LatestSnapshot.ServerTime);
			item.tweenMoveHistory.LastOrigin = item.position.Origin;
			item.tweenMoveHistory.LastAngle = item.rotation.EulerAngles;
		}
	}

	public void SavePredicationState(int cmdSeq)
	{
	}

	public bool HasPredicatonError(int cmdSeq)
	{
		return false;
	}

	public void OnPredicatoinError(int cmdSeq)
	{
	}

	public void OnPredicatoinSucc(int cmdSeq)
	{
	}

	public bool ShouldResetAll()
	{
		return false;
	}
}

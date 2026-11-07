using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Snapshots;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.iTweenMove;

public class ITweenMoveEntityDestorySystem : IPlaybackSystem
{
	private SnapshotContext _snapshotContext;

	private readonly IGroup<SceneObjectEntity> _group;

	public ITweenMoveEntityDestorySystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.iTweenMove).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null || nextSnapshot == null)
		{
			return;
		}
		foreach (SceneObjectEntity item in _group)
		{
			if (!nowSnapshot.SceneItweenEntityDataDict.ContainsKey(item.entityId.Value))
			{
				if (item.hasiTweenMove)
				{
					Snapshot.ItweenRecords.Remove(item.iTweenMove.Data);
				}
				item.isDestroy = true;
			}
		}
	}
}

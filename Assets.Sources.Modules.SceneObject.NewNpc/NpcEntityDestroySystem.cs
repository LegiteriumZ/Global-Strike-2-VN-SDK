using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NpcEntityDestroySystem : IEntityPreDestroySystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	private readonly SnapshotContext _snapshotContext;

	public NpcEntityDestroySystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo));
	}

	public void OnEntityPreDestroy()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		foreach (SceneObjectEntity item in _group)
		{
			if (!nowSnapshot.NpcEntityDataDict.ContainsKey(item.entityId.Value))
			{
				item.isDestroy = true;
			}
		}
	}
}

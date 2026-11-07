using Assets.Sources.Framework;
using Assets.Sources.Utils.ComponentInit;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NpcCleanupSystem : IEntityDestroySystem
{
	private IGroup<SceneObjectEntity> _group;

	public NpcCleanupSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo, SceneObjectMatcher.Destroy));
	}

	public void OnEntityDestroy()
	{
		foreach (SceneObjectEntity item in _group)
		{
			PlayerEntityUtility.CleanupNpcUnityObjects(item);
			PlayerEntityUtility.CleanupChickenUnityObjects(item);
		}
	}
}

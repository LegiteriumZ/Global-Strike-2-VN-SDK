using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.EngineEntity;

internal class EngineEntityHpBarDestroySystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	public EngineEntityHpBarDestroySystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.EngineEntityHpBar));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			if (Contexts.sharedInstance.sceneObject.GetEntityWithEntityId(item.engineEntityHpBar.EntityId) == null)
			{
				item.isDestroy = true;
			}
		}
	}
}

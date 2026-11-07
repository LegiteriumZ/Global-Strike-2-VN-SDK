using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.CameraEntity;

public class CameraEntityEffectDestroySystem : IPlaybackSystem
{
	private IGroup<SceneObjectEntity> _group;

	private SceneObjectContext _sceneObjectContext;

	public CameraEntityEffectDestroySystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.CameraEffect));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(item.cameraEffect.CameraEntityId);
			if (entityWithEntityId == null)
			{
				item.isDestroy = true;
			}
			else if (!item.cameraEffect.EffectInfo.IsEffectOn(entityWithEntityId))
			{
				item.isDestroy = true;
			}
		}
	}
}

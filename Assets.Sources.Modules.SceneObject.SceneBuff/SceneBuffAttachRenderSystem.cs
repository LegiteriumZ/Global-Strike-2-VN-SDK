using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.SceneBuff;

public class SceneBuffAttachRenderSystem : IRenderSystem
{
	private readonly TimeContext _timeContext;

	private readonly SceneObjectContext _sceneObjectContext;

	private IGroup<SceneObjectEntity> _effectGroup;

	public SceneBuffAttachRenderSystem(Contexts contexts)
	{
		_timeContext = contexts.time;
		_sceneObjectContext = contexts.sceneObject;
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneBuffAttach, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position, SceneObjectMatcher.Scale).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _effectGroup)
		{
			SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(item.sceneBuffAttach.AttachTargetId);
			if (entityWithEntityId == null)
			{
				item.isDestroy = true;
			}
			else
			{
				item.sceneBuffAttach.SceneBuffAttach.Render(_timeContext.time.FrameInterval, item, entityWithEntityId);
			}
		}
	}
}

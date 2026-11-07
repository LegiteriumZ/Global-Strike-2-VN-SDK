using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class MapEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _renderGroup;

	private TimeContext _time;

	public MapEffectRenderSystem(Contexts contexts)
	{
		_renderGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.MapEffect, SceneObjectMatcher.UnityObjects));
		_time = Contexts.sharedInstance.time;
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _renderGroup)
		{
			if (item.mapEffect.Render != null)
			{
				item.mapEffect.Render.Render(_time.time.FrameInterval, item);
			}
		}
	}
}

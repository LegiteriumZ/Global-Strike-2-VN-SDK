using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.LinkObject;

internal class LinkObjectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	public LinkObjectRenderSystem(Contexts context)
	{
		_group = context.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.LinkObject, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			item.linkObject.Info.RenderEntity(item);
		}
	}
}

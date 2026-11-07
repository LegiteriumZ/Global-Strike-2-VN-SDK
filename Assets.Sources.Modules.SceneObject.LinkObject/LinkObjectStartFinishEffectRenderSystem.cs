using Assets.Sources.Framework;
using Entitas;
using SSJJMath;

namespace Assets.Sources.Modules.SceneObject.LinkObject;

public class LinkObjectStartFinishEffectRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	public LinkObjectStartFinishEffectRenderSystem(Contexts context)
	{
		_group = context.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.LinkObject).AnyOf(SceneObjectMatcher.Extend1Resource, SceneObjectMatcher.Extend2Resource).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			if (item.hasExtend1Resource)
			{
				item.extend1Resource.LoadResults[0].GameObject.transform.position = VectorCoordConverter.SsjjToUnity(item.position.Origin);
			}
			if (item.hasExtend2Resource)
			{
				item.extend2Resource.LoadResults[0].GameObject.transform.position = VectorCoordConverter.SsjjToUnity(item.linkObject.LerpEnd);
			}
		}
	}
}

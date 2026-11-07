using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.BulletRail;

public class BulletRailRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	public BulletRailRenderSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.BulletRail, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.LifeTime));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			if (!item.hasPosition)
			{
				item.AddPosition(item.bulletRail.StartPosition);
			}
			if (item.hasBulletRef)
			{
				IBaseRailEffect railEffect = item.bulletRef.RailEffect;
				if (railEffect != null)
				{
					railEffect.Render();
					if (railEffect.IsEnd())
					{
						item.lifeTime.LifeTime = 0;
					}
				}
			}
			else
			{
				item.lifeTime.LifeTime = 0;
			}
		}
	}
}

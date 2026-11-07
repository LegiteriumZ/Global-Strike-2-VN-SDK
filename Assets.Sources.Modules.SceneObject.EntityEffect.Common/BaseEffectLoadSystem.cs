using Assets.Sources.Components.EntityEffect;
using Assets.Sources.Framework;
using Entitas;
using SSJJAsset.Asset;
using SSJJBase.Thread;

namespace Assets.Sources.Modules.SceneObject.EntityEffect.Common;

public abstract class BaseEffectLoadSystem<TEntityComponent, TEntityData> : IResourceLoadSystem where TEntityComponent : IEntityEffectComponent<TEntityData>
{
	protected SceneObjectContext sceneObjectContext;

	protected IGroup<SceneObjectEntity> entityGroup;

	protected BaseEffectLoadSystem(Contexts contexts)
	{
		sceneObjectContext = contexts.sceneObject;
		entityGroup = sceneObjectContext.GetGroup(GetLoadMatcher());
	}

	protected abstract IMatcher<SceneObjectEntity> GetLoadMatcher();

	protected abstract TEntityComponent GetEntityComponent(SceneObjectEntity entity);

	protected abstract LoadRequests GetLoadRequests(TEntityData entityData);

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (SceneObjectEntity item in entityGroup)
		{
			if (!item.hasLoadUnityObjects && !item.hasUnityObjects)
			{
				LoadRequests loadRequests = GetLoadRequests(GetEntityComponent(item).GetEntityData());
				if (loadRequests != null)
				{
					item.AddLoadUnityObjects(loadRequests, null);
				}
			}
		}
	}
}

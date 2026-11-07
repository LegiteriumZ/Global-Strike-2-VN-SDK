using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.EntityEffect.Common;

public abstract class BaseEffectEntityCreateSystem<TEntityData> : IEntityCreateSystem
{
	protected SnapshotContext snapshotContext;

	protected SceneObjectContext sceneObjectContext;

	protected BaseEffectEntityCreateSystem(Contexts contexts)
	{
		snapshotContext = contexts.snapshot;
		sceneObjectContext = contexts.sceneObject;
	}

	protected abstract Dictionary<int, TEntityData> GetCurrentEntities();

	protected abstract void InitEntity(SceneObjectEntity entity, int entityId, TEntityData data);

	public void OnEntityCreate()
	{
		foreach (KeyValuePair<int, TEntityData> currentEntity in GetCurrentEntities())
		{
			int key = currentEntity.Key;
			TEntityData value = currentEntity.Value;
			SceneObjectEntity entityWithEntityId = sceneObjectContext.GetEntityWithEntityId(key);
			if (entityWithEntityId == null)
			{
				entityWithEntityId = sceneObjectContext.CreateEntity();
				InitEntity(entityWithEntityId, key, value);
			}
		}
	}
}

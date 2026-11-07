using System.Collections.Generic;
using Assets.Sources.Framework.System;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.Spary;

internal class SparyResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	public SparyResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.SparyResource.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		return entity.hasSpary;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			AddEffect(entity);
		}
	}

	private void AddEffect(SceneObjectEntity entity)
	{
		SparyTextures componentInChildren = entity.sparyResource.LoadResults[0].GameObject.GetComponentInChildren<SparyTextures>();
		componentInChildren.mesh = entity.spary.Mesh;
		componentInChildren.Name = entity.spary.Data.PlayerName;
	}
}

using System;
using System.Collections.Generic;
using Assets.Sources.Framework.System;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.Spary;

internal class WallBloodResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	public WallBloodResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		return entity.hasWallBlood;
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
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.GetComponentInChildren<WallBloodEffect>().mesh = entity.wallBlood.Mesh;
		entity.AddLifeTime(DateTime.Now, 15000);
	}
}

using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.SceneObject.Tail;
using Assets.Sources.Framework.System;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.Tail;

internal class TailResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	private readonly SceneObjectContext _sceneObjectContext;

	public TailResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		_sceneObjectContext = contexts.sceneObject;
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		if (entity.hasTail)
		{
			return entity.hasUnityObjects;
		}
		return false;
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
		TailComponent tail = entity.tail;
		if (!entity.unityObjects.LoadResults.ContainsKey(0))
		{
			return;
		}
		SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(tail.FollowEntityId);
		if (entityWithEntityId == null || entityWithEntityId.isDestroy)
		{
			return;
		}
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		if (!gameObject)
		{
			return;
		}
		entity.ReplacePosition(tail.Start);
		TrailRenderer componentInChildren = gameObject.GetComponentInChildren<TrailRenderer>();
		if (componentInChildren != null)
		{
			componentInChildren.Clear();
			if (gameObject.GetComponentInChildren<TextureList>() != null)
			{
				Texture2D[] textures = gameObject.GetComponentInChildren<TextureList>().Textures;
				if (tail.TailResId < textures.Length)
				{
					componentInChildren.material.mainTexture = textures[tail.TailResId];
				}
			}
			componentInChildren.startWidth = tail.Width;
			componentInChildren.endWidth = tail.Width;
			componentInChildren.time = tail.Time;
		}
		entity.isTailRemain = false;
		gameObject.transform.position = VectorCoordConverter.SsjjToUnity(tail.Start);
		tail.FirstRender = false;
	}
}

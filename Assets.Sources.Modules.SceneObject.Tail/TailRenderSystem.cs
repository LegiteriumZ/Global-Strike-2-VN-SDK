using System;
using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.Tail;

internal class TailRenderSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _tails;

	private readonly SceneObjectContext _sceneObjectContext;

	public TailRenderSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_tails = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.Tail, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position).NoneOf(SceneObjectMatcher.TailRemain));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity tail in _tails)
		{
			SceneObjectEntity entityWithEntityId = _sceneObjectContext.GetEntityWithEntityId(tail.tail.FollowEntityId);
			GameObject gameObject = tail.unityObjects.LoadResults[0].GameObject;
			TrailController component = gameObject.transform.GetChild(0).gameObject.GetComponent<TrailController>();
			if (entityWithEntityId == null)
			{
				if ((bool)component)
				{
					component.isFading = true;
					component.fadingTime = (float)tail.tail.RemainTime / 1000f;
				}
				tail.isTailRemain = true;
				tail.AddLifeTime(DateTime.Now, tail.tail.RemainTime);
				continue;
			}
			if ((bool)component)
			{
				component.isFading = false;
				component.SetAlpha(tail.tail.Alpha);
			}
			if (!tail.tail.FirstRender)
			{
				tail.tail.FirstRender = true;
				continue;
			}
			if (entityWithEntityId != null)
			{
				tail.ReplacePosition(entityWithEntityId.position.Origin);
			}
			VectorCoordConverter.SsjjToUnity(tail.position.Origin, out var dest);
			gameObject.transform.position = dest;
			if (tail.hasRotation)
			{
				gameObject.transform.eulerAngles = tail.rotation.EulerAngles;
			}
		}
	}
}

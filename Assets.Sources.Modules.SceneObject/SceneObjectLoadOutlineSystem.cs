using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;
using cakeslice;

namespace Assets.Sources.Modules.SceneObject;

public class SceneObjectLoadOutlineSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	public SceneObjectLoadOutlineSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
		Activate();
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.Outline.AddedOrRemoved());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		return entity.hasUnityObjects;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			if (entity.isOutline)
			{
				SkinnedMeshRenderer[] componentsInChildren = entity.unityObjects.LoadResults[0].GameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.AddComponent<Outline>();
				}
			}
			else
			{
				Outline[] componentsInChildren2 = entity.unityObjects.LoadResults[0].GameObject.GetComponentsInChildren<Outline>();
				for (int i = 0; i < componentsInChildren2.Length; i++)
				{
					Object.Destroy(componentsInChildren2[i]);
				}
			}
		}
	}

	public void OnPlayback()
	{
		Execute();
	}
}

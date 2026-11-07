using System;
using System.Collections.Generic;
using Assets.Sources.Framework.System;
using Assets.Sources.Info.Res;
using Assets.Sources.Utils;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.HitEffect;

public class HitEffectResourceInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	public HitEffectResourceInitSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		if (entity.isHitEffect)
		{
			return entity.hasUnityObjects;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
			gameObject.transform.position = entity.position.Origin;
			LodUtility.AddInstanceLod(gameObject);
			if (entity.unityObjects.Identifier != null && entity.unityObjects.Identifier is HitResConfig)
			{
				HitResConfig hitResConfig = entity.unityObjects.Identifier as HitResConfig;
				entity.AddLifeTime(DateTime.Now, hitResConfig.RamainTime);
			}
			else
			{
				entity.AddLifeTime(DateTime.Now, 2000);
			}
		}
	}
}

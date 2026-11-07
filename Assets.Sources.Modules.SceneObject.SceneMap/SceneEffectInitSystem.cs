using System.Collections.Generic;
using Assets.Sources.Framework.System;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class SceneEffectInitSystem : ReactiveResourceInitSystem<SceneObjectEntity>
{
	public SceneEffectInitSystem(IContext<SceneObjectEntity> context)
		: base(context)
	{
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		if (entity.hasSceneEffect)
		{
			return entity.hasUnityObjects;
		}
		return false;
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			Transform transform = entity.unityObjects.LoadResults[0].GameObject.transform;
			Quaternion quaternion = Quaternion.Euler(VectorCoordConverter.SsjjRotationToUnity(entity.rotation.EulerAngles));
			transform.gameObject.name = entity.rotation.EulerAngles.ToString();
			if (entity.isUf3DResource)
			{
				quaternion = quaternion * Quaternion.Euler(0f, 90f, 0f) * transform.localRotation;
			}
			transform.position = VectorCoordConverter.SsjjToUnity(entity.position.Origin);
			transform.rotation = quaternion;
			transform.localScale = VectorCoordConverter.SsjjScaleToUnity(entity.scale.Scale);
			Component[] componentsInChildren = transform.GetComponentsInChildren<Component>(includeInactive: true);
			foreach (Component component in componentsInChildren)
			{
				if (!(component == null) && component is ParticleSystem)
				{
					ParticleSystem.MainModule main = (component as ParticleSystem).main;
					main.scalingMode = ParticleSystemScalingMode.Hierarchy;
				}
			}
		}
	}
}
